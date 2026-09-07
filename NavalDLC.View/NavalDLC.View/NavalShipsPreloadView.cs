using System.Collections.Generic;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.ObjectSystem;

namespace NavalDLC.View;

public class NavalShipsPreloadView : MissionView
{
	private PreloadHelper _helperInstance;

	public override void OnBehaviorInitialize()
	{
		Mission.Current.Scene.SetDoNotAddEntitiesToTickList(true);
		DefaultNavalMissionLogic missionBehavior = ((MissionBehavior)this).Mission.GetMissionBehavior<DefaultNavalMissionLogic>();
		if (missionBehavior != null)
		{
			if (missionBehavior.PlayerShips != null)
			{
				foreach (IShipOrigin item in (List<IShipOrigin>)(object)missionBehavior.PlayerShips)
				{
					PreloadShip(item);
				}
			}
			if (missionBehavior.PlayerAllyShips != null)
			{
				foreach (IShipOrigin item2 in (List<IShipOrigin>)(object)missionBehavior.PlayerAllyShips)
				{
					PreloadShip(item2);
				}
			}
			if (missionBehavior.PlayerEnemyShips != null)
			{
				foreach (IShipOrigin item3 in (List<IShipOrigin>)(object)missionBehavior.PlayerEnemyShips)
				{
					PreloadShip(item3);
				}
			}
			_helperInstance.PreloadMeshesAndPhysics();
		}
		Mission.Current.Scene.SetDoNotAddEntitiesToTickList(false);
	}

	public override void OnSceneRenderingStarted()
	{
		_helperInstance.WaitForMeshesToBeLoaded();
	}

	public void PreloadShip(IShipOrigin ship)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		MissionShipObject val = MBObjectManager.Instance.GetObject<MissionShipObject>(ship.OriginShipId);
		GameEntity val2 = GameEntity.InstantiateWithRestOffset(((MissionBehavior)this).Mission.Scene, val.Prefab, true, MatrixFrame.Identity, -0.1f, false, "");
		MissionShipFactory.CleanNonExistingUpgrades(val2.WeakEntity, ship.GetShipVisualSlotInfos());
		List<WeakGameEntity> list = new List<WeakGameEntity>();
		WeakGameEntity weakEntity = val2.WeakEntity;
		((WeakGameEntity)(ref weakEntity)).GetChildrenRecursive(ref list);
		list.Add(val2.WeakEntity);
		_helperInstance.PreloadEntities(list);
		val2.Remove(76);
	}

	public NavalShipsPreloadView()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		_helperInstance = new PreloadHelper();
		((MissionView)this)._002Ector();
	}
}

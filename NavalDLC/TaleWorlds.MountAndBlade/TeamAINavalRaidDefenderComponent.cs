using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TeamAINavalRaidDefenderComponent : TeamAIComponent
{
	private bool _hasLandingStarted;

	private bool _hasAttackersBreachedDesignatedPoint;

	private MBList<VolumeBox> _volumeBoxes;

	public bool LandingCompleted { get; private set; }

	public TeamAINavalRaidDefenderComponent(Mission currentMission, Team currentTeam, float thinkTimerTime = 10f, float applyTimerTime = 1f)
		: base(currentMission, currentTeam, thinkTimerTime, applyTimerTime)
	{
		_volumeBoxes = new MBList<VolumeBox>();
		List<GameEntity> list = new List<GameEntity>();
		currentMission.Scene.GetAllEntitiesWithScriptComponent<VolumeBox>(ref list);
		foreach (GameEntity item in list)
		{
			((List<VolumeBox>)(object)_volumeBoxes).Add(item.GetFirstScriptOfType<VolumeBox>());
		}
	}

	public override void TickOccasionally()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (!_hasAttackersBreachedDesignatedPoint)
		{
			foreach (VolumeBox item in (List<VolumeBox>)(object)_volumeBoxes)
			{
				if (!item.HasAgentsInAttackerSide())
				{
					continue;
				}
				_hasAttackersBreachedDesignatedPoint = true;
				MBList<StrategicArea> val = new MBList<StrategicArea>();
				foreach (StrategicArea item2 in (List<StrategicArea>)(object)((TeamAIComponent)this).StrategicAreas)
				{
					WeakGameEntity gameEntity = ((ScriptComponentBehavior)item2).GameEntity;
					if (((WeakGameEntity)(ref gameEntity)).HasTag("volume_box_archer_point"))
					{
						((List<StrategicArea>)(object)val).Add(item2);
					}
				}
				foreach (StrategicArea item3 in (List<StrategicArea>)(object)val)
				{
					item3.IsActive = false;
				}
				break;
			}
		}
		((TeamAIComponent)this).TickOccasionally();
	}

	public void OnLandingCompleted()
	{
		LandingCompleted = true;
	}

	public void OnShipLanded()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		if (_hasLandingStarted)
		{
			return;
		}
		_hasLandingStarted = true;
		MBList<StrategicArea> val = new MBList<StrategicArea>();
		foreach (StrategicArea item in (List<StrategicArea>)(object)((TeamAIComponent)this).StrategicAreas)
		{
			WeakGameEntity gameEntity = ((ScriptComponentBehavior)item).GameEntity;
			if (((WeakGameEntity)(ref gameEntity)).HasTag("unsafe_archer_point"))
			{
				((List<StrategicArea>)(object)val).Add(item);
			}
		}
		foreach (StrategicArea item2 in (List<StrategicArea>)(object)val)
		{
			item2.IsActive = false;
		}
		MBReadOnlyList<Agent> activeAgents = Mission.Current.DefenderTeam.ActiveAgents;
		if (((List<Agent>)(object)activeAgents).Count > 0)
		{
			Agent val2 = ((List<Agent>)(object)activeAgents)[MBRandom.RandomInt(((List<Agent>)(object)activeAgents).Count)];
			Vec3 position = val2.Position;
			SoundManager.StartOneShotEvent("event:/alerts/nods/stop", ref position);
		}
	}

	public override void OnUnitAddedToFormationForTheFirstTime(Formation formation)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Invalid comparison between Unknown and I4
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		if (GameNetwork.IsServer)
		{
			formation.ForceCalculateCaches();
			if (formation.AI.GetBehavior<BehaviorCharge>() == null)
			{
				if ((int)formation.FormationIndex == 8)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorGeneral(formation));
				}
				else if ((int)formation.FormationIndex == 9)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorProtectGeneral(formation));
				}
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorPullBack(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRegroup(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorReserve(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRetreat(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorStop(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorTacticalCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPInfantry(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPLastFlagLastStand(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPMounted(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPMountedRanged(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPRanged(formation));
			}
		}
		else
		{
			if (GameNetwork.IsClientOrReplay)
			{
				return;
			}
			formation.ForceCalculateCaches();
			if (formation.AI.GetBehavior<BehaviorCharge>() == null)
			{
				if ((int)formation.FormationIndex == 8)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorGeneral(formation));
				}
				else if ((int)formation.FormationIndex == 9)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorProtectGeneral(formation));
				}
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorPullBack(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRegroup(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorReserve(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRetreat(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorStop(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorTacticalCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorAdvance(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCautiousAdvance(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCavalryScreen(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorDefensiveRing(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorFireFromInfantryCover(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorFlank(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorHoldHighGround(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorHorseArcherSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorMountedSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorProtectFlank(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorScreenedSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSkirmishBehindFormation(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSkirmishLine(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorVanguard(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorShootFromCliff(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)(object)new BehaviorNavalRaidCliffShooting(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)(object)new BehaviorNavalRaidHoldChokePoint(formation));
			}
		}
	}
}

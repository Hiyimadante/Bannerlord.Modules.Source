using System.Collections.Generic;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace NavalDLC.ComponentInterfaces;

public class NavalCustomBattleInitializationModel : BattleInitializationModel
{
	public override List<FormationClass> GetAllAvailableTroopTypes()
	{
		return ((MBGameModel<BattleInitializationModel>)this).BaseModel.GetAllAvailableTroopTypes();
	}

	protected override bool CanPlayerSideDeployWithOrderOfBattleAux()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		IMissionAgentSpawnLogic missionBehavior = Mission.Current.GetMissionBehavior<IMissionAgentSpawnLogic>();
		if (missionBehavior is DefaultNavalMissionAgentSpawnLogic defaultNavalMissionAgentSpawnLogic)
		{
			return defaultNavalMissionAgentSpawnLogic.DeployablePlayerShipCount > 1;
		}
		if (missionBehavior is NavalRaidMissionAgentSpawnLogic navalRaidMissionAgentSpawnLogic)
		{
			if ((int)navalRaidMissionAgentSpawnLogic.PlayerSide == 1)
			{
				return navalRaidMissionAgentSpawnLogic.DeployablePlayerShipCount > 1;
			}
			return navalRaidMissionAgentSpawnLogic.GetNumberOfPlayerControllableTroops() >= 20;
		}
		Debug.FailedAssert("Unable to retrieve mission agent spawn logic behavior for custom mission", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\ComponentInterfaces\\NavalCustomBattleInitializationModel.cs", "CanPlayerSideDeployWithOrderOfBattleAux", 42);
		return false;
	}
}

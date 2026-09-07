using System;
using System.Collections.Generic;
using NavalDLC.Missions;
using NavalDLC.Missions.Deployment;
using NavalDLC.Missions.Handlers;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Source.Missions;
using TaleWorlds.MountAndBlade.Source.Missions.Handlers.Logic;

namespace NavalDLC.CustomBattle;

[MissionManager]
public static class CustomNavalMissions
{
	public static AtmosphereInfo CreateAtmosphereInfoForMission(string seasonId, int timeOfDay, float windStrength, Vec2 windDirection, TerrainType terrain)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Invalid comparison between Unknown and I4
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Invalid comparison between Unknown and I4
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Invalid comparison between Unknown and I4
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		dictionary.Add("spring", 0);
		dictionary.Add("summer", 1);
		dictionary.Add("fall", 2);
		dictionary.Add("winter", 3);
		dictionary.TryGetValue(seasonId, out var value);
		if (!((Vec2)(ref windDirection)).IsNonZero())
		{
			windDirection = Vec2.Side;
		}
		return new AtmosphereInfo
		{
			TimeInfo = new TimeInformation
			{
				Season = value,
				TimeOfDay = timeOfDay
			},
			NauticalInfo = new NauticalInformation
			{
				WindVector = windStrength * ((Vec2)(ref windDirection)).Normalized(),
				CanUseLowAltitudeAtmosphere = 1,
				IsRiverBattle = (((int)terrain == 11) ? 1 : 0),
				UsesNavalSimulatedWater = (((int)terrain == 11 || (int)terrain == 10 || (int)terrain == 19 || (int)terrain == 18) ? 1 : 0)
			}
		};
	}

	[MissionMethod]
	public static Mission OpenNavalBattleForCustomMission(string scene, BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, MBList<IShipOrigin> playerTeamShips, CustomBattleCombatant enemyParty, MBList<IShipOrigin> enemyTeamShips, bool isPlayerGeneral, string seasonString, float timeOfDay, float windStrength, NavalCustomBattleWindConfig.Direction windDirection, TerrainType terrain, string forcedSceneLevel)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected I4, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		BattleSideEnum playerSide = playerParty.Side;
		bool isPlayerAttacker = (int)playerSide == 1;
		IMissionTroopSupplier[] troopSuppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2];
		CustomBattleTroopSupplier val = new CustomBattleTroopSupplier(playerParty, true, isPlayerGeneral, false, (Func<BasicCharacterObject, bool>)null);
		troopSuppliers[playerParty.Side] = (IMissionTroopSupplier)(object)val;
		CustomBattleTroopSupplier val2 = new CustomBattleTroopSupplier(enemyParty, false, false, false, (Func<BasicCharacterObject, bool>)null);
		troopSuppliers[enemyParty.Side] = (IMissionTroopSupplier)(object)val2;
		bool isPlayerSergeant = !isPlayerGeneral;
		MissionInitializerRecord rec = default(MissionInitializerRecord);
		((MissionInitializerRecord)(ref rec))._002Ector(scene);
		TerrainType terrainType = terrain;
		rec.TerrainType = (int)terrainType;
		rec.NeedsRandomTerrain = false;
		rec.PlayingInCampaignMode = false;
		rec.AtmosphereOnCampaign = CreateAtmosphereInfoForMission(seasonString, (int)timeOfDay, windStrength, new Vec2(0f, 1f), terrain);
		rec.SceneHasMapPatch = false;
		rec.PlayingInCampaignMode = true;
		rec.DecalAtlasGroup = 2;
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		rec.SceneLevels = forcedSceneLevel;
		int maximumDeployableTroopCountForTeam = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(playerTeamShips, isPlayerTeam: true);
		int maximumDeployableTroopCountForTeam2 = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(enemyTeamShips);
		int[] maxDeployableTroopCountPerTeam = new int[3] { maximumDeployableTroopCountForTeam, 0, maximumDeployableTroopCountForTeam2 };
		int deployablePlayerShipCount = MathF.Min(((List<IShipOrigin>)(object)playerTeamShips).Count, NavalShipDeploymentLimit.Max().NetDeploymentLimit);
		Mission obj = NavalMissionState.OpenNew("NavalCustomBattle", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Expected O, but got Unknown
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Expected O, but got Unknown
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Expected O, but got Unknown
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[31]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new DefaultNavalMissionLogic(playerTeamShips, null, enemyTeamShips, NavalShipDeploymentLimit.Max(), NavalShipDeploymentLimit.Invalid(), NavalShipDeploymentLimit.Max()),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new DefaultNavalMissionAgentSpawnLogic(troopSuppliers, playerSide, deployablePlayerShipCount, maxDeployableTroopCountPerTeam),
				(MissionBehavior)new NavalMissionDeploymentPlanningLogic(mission),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new CustomBattleAgentLogic(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new NavalAgentMoraleInteractionLogic(),
				(MissionBehavior)new NavalBattleEndLogic(),
				(MissionBehavior)new NavalBoundaryForceFieldLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)new List<CustomBattleCombatant> { playerParty, enemyParty }, (IBattleCombatant)(object)playerParty, (IBattleCombatant)(object)((!isPlayerAttacker) ? playerParty : enemyParty), (IBattleCombatant)(object)(isPlayerAttacker ? playerParty : enemyParty), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new ShipRetreatLogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new NavalAssignPlayerRoleInTeamMissionController(!isPlayerSergeant, isPlayerSergeant, isPlayerInArmy: false),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController(),
				(MissionBehavior)new NavalDeploymentMissionController(isPlayerAttacker),
				(MissionBehavior)new NavalDeploymentHandler(isPlayerAttacker),
				(MissionBehavior)new NavalCustomBattleWindAndWaveLogic(windDirection, terrainType)
			};
		});
		obj.SetPlayerCanTakeControlOfAnotherAgentWhenDead();
		return obj;
	}

	[MissionMethod]
	public static Mission OpenNavalRaidBattleForCustomMission(string scene, BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, CustomBattleCombatant enemyParty, MBList<IShipOrigin> attackerShips, bool isPlayerGeneral, string seasonString, float timeOfDay, float windStrength, NavalCustomBattleWindConfig.Direction windDirection, TerrainType terrain, string forcedSceneLevel)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected I4, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		BattleSideEnum playerSide = playerParty.Side;
		bool isPlayerAttacker = (int)playerSide == 1;
		IMissionTroopSupplier[] troopSuppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2];
		CustomBattleTroopSupplier val = new CustomBattleTroopSupplier(playerParty, true, isPlayerGeneral, false, (Func<BasicCharacterObject, bool>)null);
		troopSuppliers[playerParty.Side] = (IMissionTroopSupplier)(object)val;
		CustomBattleTroopSupplier val2 = new CustomBattleTroopSupplier(enemyParty, false, false, false, (Func<BasicCharacterObject, bool>)null);
		troopSuppliers[enemyParty.Side] = (IMissionTroopSupplier)(object)val2;
		bool isPlayerSergeant = !isPlayerGeneral;
		MissionInitializerRecord rec = default(MissionInitializerRecord);
		((MissionInitializerRecord)(ref rec))._002Ector(scene);
		TerrainType terrainType = terrain;
		rec.TerrainType = (int)terrainType;
		rec.NeedsRandomTerrain = false;
		rec.PlayingInCampaignMode = false;
		rec.AtmosphereOnCampaign = CreateAtmosphereInfoForMission(seasonString, (int)timeOfDay, windStrength, new Vec2(0f, 1f), terrain);
		rec.SceneHasMapPatch = false;
		rec.PlayingInCampaignMode = true;
		rec.DecalAtlasGroup = 2;
		rec.SceneLevels = "naval_raid";
		int attackerTeamMaxDeployableTroopCount = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(attackerShips, isPlayerAttacker);
		attackerTeamMaxDeployableTroopCount = MathF.Min(troopSuppliers[1].NumTroopsNotSupplied, attackerTeamMaxDeployableTroopCount);
		int commonLimit = MathF.Min(((List<IShipOrigin>)(object)attackerShips).Count, NavalShipDeploymentLimit.Max().NetDeploymentLimit);
		NavalShipDeploymentLimit attackerShipsDeploymentLimit = new NavalShipDeploymentLimit(commonLimit);
		CustomBattleCombatant val3 = (isPlayerAttacker ? enemyParty : playerParty);
		int defenderTeamMaxDeployableTroopCount = val3.NumberOfHealthyMembers;
		Mission obj = NavalMissionState.OpenNew("NavalRaidCustomBattle", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Expected O, but got Unknown
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Expected O, but got Unknown
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Expected O, but got Unknown
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[30]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new NavalRaidMissionController(),
				(MissionBehavior)new NavalRaidMissionAgentSpawnLogic(troopSuppliers, playerSide, attackerShips, attackerShipsDeploymentLimit, attackerTeamMaxDeployableTroopCount, defenderTeamMaxDeployableTroopCount),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new NavalRaidMissionDeploymentPlanningLogic(),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new CustomBattleAgentLogic(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new NavalAgentMoraleInteractionLogic(),
				(MissionBehavior)new BattleEndLogic(),
				(MissionBehavior)new NavalBoundaryForceFieldLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)new List<CustomBattleCombatant> { playerParty, enemyParty }, (IBattleCombatant)(object)playerParty, (IBattleCombatant)(object)((!isPlayerAttacker) ? playerParty : enemyParty), (IBattleCombatant)(object)(isPlayerAttacker ? playerParty : enemyParty), (MissionTeamAITypeEnum)5, isPlayerSergeant),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new NavalAssignPlayerRoleInTeamMissionController(!isPlayerSergeant, isPlayerSergeant, isPlayerInArmy: false),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController(),
				(MissionBehavior)new NavalRaidDeploymentMissionController(isPlayerAttacker),
				(MissionBehavior)new NavalRaidDeploymentHandler(isPlayerAttacker),
				(MissionBehavior)new NavalCustomBattleWindAndWaveLogic(windDirection, terrainType)
			};
		});
		obj.SetPlayerCanTakeControlOfAnotherAgentWhenDead();
		return obj;
	}
}

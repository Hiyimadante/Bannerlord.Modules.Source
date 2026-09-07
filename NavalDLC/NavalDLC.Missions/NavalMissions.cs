using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Helpers;
using NavalDLC.Missions.Deployment;
using NavalDLC.Missions.Handlers;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Storyline;
using NavalDLC.Storyline.MissionControllers;
using SandBox;
using SandBox.Conversation.MissionLogics;
using SandBox.Missions;
using SandBox.Missions.MissionLogics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.CampaignSystem.TroopSuppliers;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;
using TaleWorlds.MountAndBlade.Source.Missions;
using TaleWorlds.MountAndBlade.Source.Missions.Handlers;
using TaleWorlds.MountAndBlade.Source.Missions.Handlers.Logic;

namespace NavalDLC.Missions;

[MissionManager]
public static class NavalMissions
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<MapEventParty, bool> _003C_003E9__2_0;

		public static Func<MapEventParty, bool> _003C_003E9__3_0;

		public static InitializeMissionBehaviorsDelegate _003C_003E9__11_0;

		internal bool _003COpenNavalSetPieceBattleMission_003Eb__2_0(MapEventParty p)
		{
			return p.Party == MobileParty.MainParty.Party;
		}

		internal bool _003COpenBlockedEstuaryMission_003Eb__3_0(MapEventParty p)
		{
			return p.Party == MobileParty.MainParty.Party;
		}

		internal IEnumerable<MissionBehavior> _003COpenNavalStorylineAlleyFightMission_003Eb__11_0(Mission mission)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			return new List<MissionBehavior>
			{
				(MissionBehavior)(object)new NavalStorylineAlleyFightMissionController(),
				(MissionBehavior)(object)new NavalStorylineAlleyFightCinematicController(),
				(MissionBehavior)new MissionHintLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionAgentHandler(),
				(MissionBehavior)new MissionFightHandler(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(10f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController(),
				(MissionBehavior)new EquipmentControllerLeaveLogic()
			}.ToArray();
		}
	}

	[MissionMethod]
	public static Mission OpenNavalBattleMission(MissionInitializerRecord rec)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		MobileParty mainParty = MobileParty.MainParty;
		MapEvent mapEvent = mainParty.MapEvent;
		bool isPlayerSergeant = mapEvent.IsPlayerSergeant();
		bool isPlayerInArmy = mainParty.Army != null;
		bool isPlayerAttacker = !Extensions.IsEmpty<MapEventParty>(((IEnumerable<MapEventParty>)mapEvent.AttackerSide.Parties).Where((MapEventParty p) => p.Party == mainParty.Party));
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		Mission obj = NavalMissionState.OpenNew("NavalBattle", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Expected O, but got Unknown
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Expected O, but got Unknown
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Expected O, but got Unknown
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Expected O, but got Unknown
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Expected O, but got Unknown
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Expected O, but got Unknown
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Expected O, but got Unknown
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Expected O, but got Unknown
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_033b: Expected O, but got Unknown
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Expected O, but got Unknown
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_034d: Expected O, but got Unknown
			IMissionTroopSupplier[] suppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			BattleSideEnum playerSide = mapEvent.PlayerSide;
			BattleSideEnum otherSide = mapEvent.GetOtherSide(playerSide);
			MBReadOnlyList<MapEventParty> parties = mapEvent.GetMapEventSide(playerSide).Parties;
			NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMapEventPartiesOfPlayerTeams(parties, isPlayerSergeant, out var playerMapEventParty, out var playerTeamMapEventParties, out var playerAllyTeamMapEventParties);
			NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetShipDeploymentLimitsOfPlayerTeams(playerTeamMapEventParties, playerAllyTeamMapEventParties, out var playerTeamDeploymentLimit, out var playerAllyTeamDeploymentLimit);
			MBList<IShipOrigin> val = new MBList<IShipOrigin>();
			Ship suitablePlayerShip = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetSuitablePlayerShip(playerMapEventParty, playerTeamMapEventParties);
			((List<IShipOrigin>)(object)val).Add((IShipOrigin)(object)suitablePlayerShip);
			NavalDLCManager.Instance.GameModels.ShipDeploymentModel.FillShipsOfTeamParties((MBReadOnlyList<MapEventParty>)(object)playerTeamMapEventParties, playerTeamDeploymentLimit, val);
			NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetOrderedCaptainsForPlayerTeamShips((MBReadOnlyList<MapEventParty>)(object)playerTeamMapEventParties, (MBReadOnlyList<IShipOrigin>)(object)val, out var playerTeamCaptainsByPriority);
			MBList<IShipOrigin> val2 = new MBList<IShipOrigin>();
			if (!Extensions.IsEmpty<MapEventParty>((IEnumerable<MapEventParty>)playerAllyTeamMapEventParties))
			{
				NavalDLCManager.Instance.GameModels.ShipDeploymentModel.FillShipsOfTeamParties((MBReadOnlyList<MapEventParty>)(object)playerAllyTeamMapEventParties, playerAllyTeamDeploymentLimit, val2);
			}
			MBList<MapEventParty> teamMapEventParties = Extensions.ToMBList<MapEventParty>((List<MapEventParty>)(object)mapEvent.GetMapEventSide(otherSide).Parties);
			NavalShipDeploymentLimit teamShipDeploymentLimit = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetTeamShipDeploymentLimit((MBReadOnlyList<MapEventParty>)(object)teamMapEventParties);
			MBList<IShipOrigin> val3 = new MBList<IShipOrigin>();
			NavalDLCManager.Instance.GameModels.ShipDeploymentModel.FillShipsOfTeamParties((MBReadOnlyList<MapEventParty>)(object)teamMapEventParties, teamShipDeploymentLimit, val3);
			int deployablePlayerShipCount = MathF.Min(((List<IShipOrigin>)(object)val).Count, playerTeamDeploymentLimit.NetDeploymentLimit);
			int maximumDeployableTroopCountForTeam = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(val, isPlayerTeam: true);
			int maximumDeployableTroopCountForTeam2 = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(val2);
			int maximumDeployableTroopCountForTeam3 = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(val3);
			int[] maxDeployableTroopCountPerTeam = new int[3] { maximumDeployableTroopCountForTeam, maximumDeployableTroopCountForTeam2, maximumDeployableTroopCountForTeam3 };
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[31]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new DefaultNavalMissionLogic(val, val2, val3, playerTeamDeploymentLimit, playerAllyTeamDeploymentLimit, teamShipDeploymentLimit),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new DefaultNavalMissionAgentSpawnLogic(suppliers, playerSide, deployablePlayerShipCount, maxDeployableTroopCountPerTeam),
				(MissionBehavior)new NavalMissionDeploymentPlanningLogic(mission),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new NavalAgentMoraleInteractionLogic(),
				(MissionBehavior)new NavalBattleEndLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new ShipRetreatLogic(),
				(MissionBehavior)new NavalBoundaryForceFieldLogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new NavalAssignPlayerRoleInTeamMissionController(!isPlayerSergeant, isPlayerSergeant, isPlayerInArmy, playerTeamCaptainsByPriority),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController(),
				(MissionBehavior)new NavalDeploymentMissionController(isPlayerAttacker),
				(MissionBehavior)new NavalDeploymentHandler(isPlayerAttacker)
			};
		});
		obj.SetPlayerCanTakeControlOfAnotherAgentWhenDead();
		return obj;
	}

	[MissionMethod]
	public static Mission OpenNavalRaidMission(TroopRoster navalRaidTroops, BattleSideEnum navalSide, List<Ship> allShips)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		Settlement mapEventSettlement = PlayerEncounter.Battle.MapEventSettlement;
		string scene = mapEventSettlement.LocationComplex.GetScene("village_center", 1);
		MissionInitializerRecord val = default(MissionInitializerRecord);
		((MissionInitializerRecord)(ref val))._002Ector(scene);
		val.TerrainType = 11;
		val.DamageToFriendsMultiplier = Campaign.Current.Models.DifficultyModel.GetPlayerTroopsReceivedDamageMultiplier();
		val.DamageFromPlayerToFriendsMultiplier = Campaign.Current.Models.DifficultyModel.GetPlayerTroopsReceivedDamageMultiplier();
		val.NeedsRandomTerrain = false;
		val.PlayingInCampaignMode = true;
		val.AtmosphereOnCampaign = Campaign.Current.Models.MapWeatherModel.GetAtmosphereModel(mapEventSettlement.Position);
		val.SceneHasMapPatch = false;
		val.DecalAtlasGroup = 2;
		MissionInitializerRecord rec = val;
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		rec.SceneLevels = "naval_raid";
		MBList<IShipOrigin> navalSideShips = new MBList<IShipOrigin>();
		foreach (Ship allShip in allShips)
		{
			((List<IShipOrigin>)(object)navalSideShips).Add((IShipOrigin)(object)allShip);
		}
		Mission obj = NavalMissionState.OpenNew("NavalRaid", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Invalid comparison between Unknown and I4
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Invalid comparison between Unknown and I4
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected O, but got Unknown
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected O, but got Unknown
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected O, but got Unknown
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Expected O, but got Unknown
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Expected O, but got Unknown
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Expected O, but got Unknown
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Expected O, but got Unknown
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Expected O, but got Unknown
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Expected O, but got Unknown
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Expected O, but got Unknown
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Expected O, but got Unknown
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Expected O, but got Unknown
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Expected O, but got Unknown
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			MapEvent mapEvent = MobileParty.MainParty.MapEvent;
			BattleSideEnum otherSide = mapEvent.GetOtherSide(navalSide);
			IMissionTroopSupplier[] array = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2];
			array[otherSide] = (IMissionTroopSupplier)new PartyGroupTroopSupplier(mapEvent, otherSide, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null);
			array[navalSide] = (IMissionTroopSupplier)new PartyGroupTroopSupplier(mapEvent, navalSide, navalRaidTroops.ToFlattenedRoster(), (Func<UniqueTroopDescriptor, MapEventParty, bool>)null);
			NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetOrderedCaptainsForPlayerTeamShips(mapEvent.PartiesOnSide(navalSide), (MBReadOnlyList<IShipOrigin>)(object)navalSideShips, out var playerTeamCaptainsByPriority);
			int totalManCount = navalRaidTroops.TotalManCount;
			int totalHealthyTroopCountOfSide = mapEvent.GetMapEventSide(otherSide).GetTotalHealthyTroopCountOfSide();
			bool flag = (int)navalSide == 1;
			bool isPlayerAttacker = (int)mapEvent.PlayerSide == 1;
			NavalRaidMissionAgentSpawnLogic.ComputeInitialTroopCounts(flag ? totalManCount : totalHealthyTroopCountOfSide, flag ? totalHealthyTroopCountOfSide : totalManCount, out var initialAttackerTroopCount, out var initialDefenderTroopCount);
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[30]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new NavalRaidMissionController(),
				(MissionBehavior)new NavalRaidMissionAgentSpawnLogic(array, mapEvent.PlayerSide, navalSideShips, new NavalShipDeploymentLimit(((List<IShipOrigin>)(object)navalSideShips).Count), initialAttackerTroopCount, initialDefenderTroopCount),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new NavalRaidMissionDeploymentPlanningLogic(),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new NavalAgentMoraleInteractionLogic(),
				(MissionBehavior)new BattleEndLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)mapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)(flag ? mapEvent.GetLeaderParty(otherSide) : mapEvent.GetLeaderParty(navalSide)), (IBattleCombatant)(object)(flag ? mapEvent.GetLeaderParty(navalSide) : mapEvent.GetLeaderParty(otherSide)), (MissionTeamAITypeEnum)5, mapEvent.IsPlayerSergeant()),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new NavalBoundaryForceFieldLogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new NavalAssignPlayerRoleInTeamMissionController(!mapEvent.IsPlayerSergeant(), mapEvent.IsPlayerSergeant(), MobileParty.MainParty.Army != null, playerTeamCaptainsByPriority),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController(),
				(MissionBehavior)new NavalRaidDeploymentMissionController(isPlayerAttacker),
				(MissionBehavior)new NavalRaidDeploymentHandler(isPlayerAttacker)
			};
		});
		obj.SetPlayerCanTakeControlOfAnotherAgentWhenDead();
		return obj;
	}

	[MissionMethod]
	public static Mission OpenNavalSetPieceBattleMission(MissionInitializerRecord rec, MBList<IShipOrigin> playerShips, MBList<IShipOrigin> playerAllyShips, MBList<IShipOrigin> enemyShips)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		bool isPlayerSergeant = MobileParty.MainParty.MapEvent.IsPlayerSergeant();
		bool isPlayerInArmy = MobileParty.MainParty.Army != null;
		List<string> heroesOnPlayerSideByPriority = HeroHelper.OrderHeroesOnPlayerSideByPriority(false, false);
		bool isPlayerAttacker = !Extensions.IsEmpty<MapEventParty>(((IEnumerable<MapEventParty>)MobileParty.MainParty.MapEvent.AttackerSide.Parties).Where((MapEventParty p) => p.Party == MobileParty.MainParty.Party));
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		return NavalMissionState.OpenNew("NavalBattle", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Expected O, but got Unknown
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Expected O, but got Unknown
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Expected O, but got Unknown
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Expected O, but got Unknown
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			IMissionTroopSupplier[] suppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			BattleSideEnum playerSide = MobileParty.MainParty.MapEvent.PlayerSide;
			NavalShipDeploymentLimit playerTeamShipDeploymentLimit = NavalShipDeploymentLimit.Max();
			NavalShipDeploymentLimit playerAllyTeamShipDeploymentLimit = NavalShipDeploymentLimit.Max();
			NavalShipDeploymentLimit enemyTeamShipDeploymentLimit = NavalShipDeploymentLimit.Max();
			int deployablePlayerShipCount = MathF.Min(((List<IShipOrigin>)(object)playerShips).Count, NavalShipDeploymentLimit.Max().NetDeploymentLimit);
			int maximumDeployableTroopCountForTeam = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(playerShips, isPlayerTeam: true);
			int maximumDeployableTroopCountForTeam2 = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(playerAllyShips);
			int maximumDeployableTroopCountForTeam3 = NavalDLCManager.Instance.GameModels.ShipDeploymentModel.GetMaximumDeployableTroopCountForTeam(enemyShips);
			int[] maxDeployableTroopCountPerTeam = new int[3] { maximumDeployableTroopCountForTeam, maximumDeployableTroopCountForTeam2, maximumDeployableTroopCountForTeam3 };
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[28]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new DefaultNavalMissionLogic(playerShips, playerAllyShips, enemyShips, playerTeamShipDeploymentLimit, playerAllyTeamShipDeploymentLimit, enemyTeamShipDeploymentLimit),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new DefaultNavalMissionAgentSpawnLogic(suppliers, playerSide, deployablePlayerShipCount, maxDeployableTroopCountPerTeam),
				(MissionBehavior)new NavalMissionDeploymentPlanningLogic(mission),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new NavalBattleEndLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new NavalAssignPlayerRoleInTeamMissionController(!isPlayerSergeant, isPlayerSergeant, isPlayerInArmy, heroesOnPlayerSideByPriority),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController(),
				(MissionBehavior)new NavalDeploymentMissionController(isPlayerAttacker),
				(MissionBehavior)new NavalDeploymentHandler(isPlayerAttacker)
			};
		});
	}

	[MissionMethod]
	public static Mission OpenBlockedEstuaryMission(MissionInitializerRecord rec, MobileParty enemyParty, bool startFromCheckPoint)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		NavalStorylineData.SetNavalStorylineSetPieceBattleMissionType(NavalStorylineData.NavalStorylineSetPieceBattleMissionTypes.Act3Quest4);
		bool isPlayerSergeant = MobileParty.MainParty.MapEvent.IsPlayerSergeant();
		bool isPlayerInArmy = MobileParty.MainParty.Army != null;
		List<string> heroesOnPlayerSideByPriority = HeroHelper.OrderHeroesOnPlayerSideByPriority(false, false);
		Extensions.IsEmpty<MapEventParty>(((IEnumerable<MapEventParty>)MobileParty.MainParty.MapEvent.AttackerSide.Parties).Where((MapEventParty p) => p.Party == MobileParty.MainParty.Party));
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		return NavalMissionState.OpenNew("BlockedEstuary", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
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
			IMissionTroopSupplier[] suppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			BattleSideEnum playerSide = MobileParty.MainParty.MapEvent.PlayerSide;
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[25]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new DefaultNavalMissionAgentSpawnLogic(suppliers, playerSide),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new BlockedEstuaryMissionController(enemyParty, startFromCheckPoint),
				(MissionBehavior)new BlockedEstuaryBattleEndLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new MissionObjectiveLogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new NavalAssignPlayerRoleInTeamMissionController(!isPlayerSergeant, isPlayerSergeant, isPlayerInArmy, heroesOnPlayerSideByPriority),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController()
			};
		});
	}

	[MissionMethod]
	public static Mission OpenNavalStorylineCaptivityMission(MissionInitializerRecord rec, CharacterObject allyCharacter, CharacterObject enemyCharacter, CharacterObject crewCharacter)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		NavalStorylineData.SetNavalStorylineSetPieceBattleMissionType(NavalStorylineData.NavalStorylineSetPieceBattleMissionTypes.Act1);
		bool isPlayerSergeant = MobileParty.MainParty.MapEvent.IsPlayerSergeant();
		_ = MobileParty.MainParty.Army;
		HeroHelper.OrderHeroesOnPlayerSideByPriority(false, false);
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		return NavalMissionState.OpenNew("NavalCaptivityBattle", rec, (InitializeMissionBehaviorsDelegate)delegate
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Expected O, but got Unknown
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Expected O, but got Unknown
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Expected O, but got Unknown
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Expected O, but got Unknown
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected O, but got Unknown
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Expected O, but got Unknown
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Expected O, but got Unknown
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Expected O, but got Unknown
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Expected O, but got Unknown
			_ = new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			BattleSideEnum playerSide = MobileParty.MainParty.MapEvent.PlayerSide;
			BattleSideEnum otherSide = MobileParty.MainParty.MapEvent.GetOtherSide(playerSide);
			MBList<IShipOrigin> obj = new MBList<IShipOrigin>();
			MBList<IShipOrigin> val = new MBList<IShipOrigin>();
			MBList<IShipOrigin> val2 = new MBList<IShipOrigin>();
			((List<IShipOrigin>)(object)obj).AddRange((IEnumerable<IShipOrigin>)MobileParty.MainParty.Ships);
			foreach (MapEventParty item in (List<MapEventParty>)(object)MobileParty.MainParty.MapEvent.GetMapEventSide(playerSide).Parties)
			{
				if (item.IsNpcParty)
				{
					((List<IShipOrigin>)(object)val).AddRange((IEnumerable<IShipOrigin>)item.Party.Ships);
				}
			}
			foreach (MapEventParty item2 in (List<MapEventParty>)(object)MobileParty.MainParty.MapEvent.GetMapEventSide(otherSide).Parties)
			{
				((List<IShipOrigin>)(object)val2).AddRange((IEnumerable<IShipOrigin>)item2.Party.Ships);
			}
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[21]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new NavalStorylineCaptivityMissionController(allyCharacter, (BasicCharacterObject)(object)enemyCharacter, crewCharacter),
				(MissionBehavior)new MissionHintLogic(),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new VisualTrackerMissionBehavior(),
				(MissionBehavior)new MissionFightHandler(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new MissionObjectiveLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new MissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController()
			};
		});
	}

	[MissionMethod]
	public static Mission OpenNavalStorylinePirateBattleMission(MissionInitializerRecord rec, MobileParty pirateParty, int pirateTroopCount)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		NavalStorylineData.SetNavalStorylineSetPieceBattleMissionType(NavalStorylineData.NavalStorylineSetPieceBattleMissionTypes.Act2);
		bool isPlayerSergeant = MobileParty.MainParty.MapEvent.IsPlayerSergeant();
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		return NavalMissionState.OpenNew("NavalStorylinePirateBattle", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Expected O, but got Unknown
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Expected O, but got Unknown
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Expected O, but got Unknown
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Expected O, but got Unknown
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Expected O, but got Unknown
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Expected O, but got Unknown
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Expected O, but got Unknown
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Expected O, but got Unknown
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Expected O, but got Unknown
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Expected O, but got Unknown
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Expected O, but got Unknown
			IMissionTroopSupplier[] suppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			BattleSideEnum playerSide = MobileParty.MainParty.MapEvent.PlayerSide;
			BattleSideEnum otherSide = MobileParty.MainParty.MapEvent.GetOtherSide(playerSide);
			MBList<IShipOrigin> obj = new MBList<IShipOrigin>();
			MBList<IShipOrigin> val = new MBList<IShipOrigin>();
			MBList<IShipOrigin> val2 = new MBList<IShipOrigin>();
			((List<IShipOrigin>)(object)obj).AddRange((IEnumerable<IShipOrigin>)MobileParty.MainParty.Ships);
			foreach (MapEventParty item in (List<MapEventParty>)(object)MobileParty.MainParty.MapEvent.GetMapEventSide(playerSide).Parties)
			{
				if (item.IsNpcParty)
				{
					((List<IShipOrigin>)(object)val).AddRange((IEnumerable<IShipOrigin>)item.Party.Ships);
				}
			}
			foreach (MapEventParty item2 in (List<MapEventParty>)(object)MobileParty.MainParty.MapEvent.GetMapEventSide(otherSide).Parties)
			{
				((List<IShipOrigin>)(object)val2).AddRange((IEnumerable<IShipOrigin>)item2.Party.Ships);
			}
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[25]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new PirateBattleMissionController(pirateParty, pirateTroopCount),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new MissionFightHandler(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new DefaultNavalMissionAgentSpawnLogic(suppliers, playerSide),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new NavalAgentMoraleInteractionLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new MissionObjectiveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController()
			};
		});
	}

	[MissionMethod]
	public static Mission OpenNavalStorylineQuest5SetPieceBattleMission(MissionInitializerRecord rec, MobileParty enemyParty, Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState lastHitCheckpoint = Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState.InitializePhase1Part1)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		NavalStorylineData.SetNavalStorylineSetPieceBattleMissionType(NavalStorylineData.NavalStorylineSetPieceBattleMissionTypes.Act3Quest5);
		bool isPlayerSergeant = MobileParty.MainParty.MapEvent.IsPlayerSergeant();
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		return NavalMissionState.OpenNew("NavalStorylineQuest5SetPieceBattleMission", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Expected O, but got Unknown
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Expected O, but got Unknown
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Expected O, but got Unknown
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Expected O, but got Unknown
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Expected O, but got Unknown
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Expected O, but got Unknown
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Expected O, but got Unknown
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Expected O, but got Unknown
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Expected O, but got Unknown
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Expected O, but got Unknown
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Expected O, but got Unknown
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Expected O, but got Unknown
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Expected O, but got Unknown
			_ = new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			BattleSideEnum playerSide = MobileParty.MainParty.MapEvent.PlayerSide;
			BattleSideEnum otherSide = MobileParty.MainParty.MapEvent.GetOtherSide(playerSide);
			MBList<IShipOrigin> obj = new MBList<IShipOrigin>();
			MBList<IShipOrigin> val = new MBList<IShipOrigin>();
			MBList<IShipOrigin> val2 = new MBList<IShipOrigin>();
			((List<IShipOrigin>)(object)obj).AddRange((IEnumerable<IShipOrigin>)MobileParty.MainParty.Ships);
			foreach (MapEventParty item in (List<MapEventParty>)(object)MobileParty.MainParty.MapEvent.GetMapEventSide(playerSide).Parties)
			{
				if (item.IsNpcParty)
				{
					((List<IShipOrigin>)(object)val).AddRange((IEnumerable<IShipOrigin>)item.Party.Ships);
				}
			}
			foreach (MapEventParty item2 in (List<MapEventParty>)(object)MobileParty.MainParty.MapEvent.GetMapEventSide(otherSide).Parties)
			{
				((List<IShipOrigin>)(object)val2).AddRange((IEnumerable<IShipOrigin>)item2.Party.Ships);
			}
			List<MissionBehavior> result = new List<MissionBehavior>
			{
				(MissionBehavior)(object)new NavalShipsLogic(),
				(MissionBehavior)(object)new NavalFloatsamLogic(),
				(MissionBehavior)(object)new NavalAgentsLogic(),
				(MissionBehavior)new MissionObjectiveLogic(),
				(MissionBehavior)(object)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)(object)new Quest5NavalMissionDeploymentPlanningLogic(mission),
				(MissionBehavior)(object)new Quest5SetPieceBattleMissionController(lastHitCheckpoint, enemyParty),
				(MissionBehavior)(object)new NavalBattleAgentLogic(),
				(MissionBehavior)new MissionFightHandler(),
				(MissionBehavior)(object)new CosmeticShipSpawnMissionLogic(),
				(MissionBehavior)(object)new LightScriptedFiresMissionController(),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)(object)new Quest5BattleObserverMissionLogic(),
				(MissionBehavior)new MissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionConversationLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController(),
				(MissionBehavior)new StealthPatrolPointMissionLogic()
			};
			if (lastHitCheckpoint != Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState.InitializePhase1Part1)
			{
				_ = lastHitCheckpoint;
				_ = 5;
			}
			return result;
		});
	}

	[MissionMethod]
	public static Mission OpenNavalFinalConversationMission()
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		int wallLevel = Settlement.CurrentSettlement.Town.GetWallLevel();
		string civilianUpgradeLevelTag = Campaign.Current.Models.LocationModel.GetCivilianUpgradeLevelTag(wallLevel);
		Location location = Settlement.CurrentSettlement.LocationComplex.GetLocationWithId("port");
		List<Ship> townLordShips = new List<Ship>();
		List<Ship> mainPartyShips = ((IEnumerable<Ship>)MobileParty.MainParty.Ships).ToList();
		foreach (MobileParty item in (List<MobileParty>)(object)Settlement.CurrentSettlement.Parties)
		{
			townLordShips.AddRange((IEnumerable<Ship>)item.Ships);
		}
		return MissionState.OpenNew("NavalFinalConversationMission", SandBoxMissions.CreateSandBoxMissionInitializerRecord(location.GetSceneName(wallLevel), civilianUpgradeLevelTag, true, (DecalAtlasGroup)3), (InitializeMissionBehaviorsDelegate)delegate
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Expected O, but got Unknown
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Expected O, but got Unknown
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[23]
			{
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new MissionBasicTeamLogic(),
				(MissionBehavior)new BasicLeaveMissionLogic(),
				(MissionBehavior)new LeaveMissionLogic("settlement_player_unconscious"),
				(MissionBehavior)new SandBoxMissionHandler(),
				(MissionBehavior)new MissionAgentLookHandler(),
				(MissionBehavior)new MissionConversationLogic(),
				(MissionBehavior)new MissionAgentHandler(),
				(MissionBehavior)new MissionLocationLogic(location, (string)null),
				(MissionBehavior)new HeroSkillHandler(),
				(MissionBehavior)new MissionFightHandler(),
				(MissionBehavior)new BattleAgentLogic(),
				(MissionBehavior)new MountAgentLogic(),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new MissionCrimeHandler(),
				(MissionBehavior)new MissionFacialAnimationHandler(),
				(MissionBehavior)new LocationItemSpawnHandler(),
				(MissionBehavior)new IndoorMissionController(),
				(MissionBehavior)new VisualTrackerMissionBehavior(),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new BattleSurgeonLogic(),
				(MissionBehavior)new CivilianPortShipSpawnMissionLogic(mainPartyShips, townLordShips)
			};
		}, true, true);
	}

	[MissionMethod]
	public static Mission OpenNavalStorylineWoundedBeastBattleMission(MissionInitializerRecord rec)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		NavalStorylineData.SetNavalStorylineSetPieceBattleMissionType(NavalStorylineData.NavalStorylineSetPieceBattleMissionTypes.Act3Quest2);
		bool isPlayerSergeant = true;
		HeroHelper.OrderHeroesOnPlayerSideByPriority(false, false);
		IMissionTroopSupplier[] suppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2];
		suppliers[0] = (IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null);
		suppliers[1] = (IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null);
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		BattleSideEnum playerSide = MobileParty.MainParty.MapEvent.PlayerSide;
		return NavalMissionState.OpenNew("NavalStorylineWoundedBeastBattle", rec, (InitializeMissionBehaviorsDelegate)delegate(Mission mission)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Expected O, but got Unknown
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[27]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new MissionObjectiveLogic(),
				(MissionBehavior)new WoundedBeastMissionController(),
				(MissionBehavior)new BattleAgentLogic(),
				(MissionBehavior)new MissionFightHandler(),
				(MissionBehavior)new WaveParametersComputerLogic(),
				(MissionBehavior)new DefaultNavalMissionAgentSpawnLogic(suppliers, playerSide),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new NavalAgentMoraleInteractionLogic(),
				(MissionBehavior)new ShipCollisionOutcomeLogic(mission),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new NavalBattleEndLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController()
			};
		});
	}

	[MissionMethod]
	public static Mission OpenHelpingAnAllySetPieceBattleMission(MissionInitializerRecord rec, MobileParty merchantParty, MobileParty seaHoundsParty)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		NavalStorylineData.SetNavalStorylineSetPieceBattleMissionType(NavalStorylineData.NavalStorylineSetPieceBattleMissionTypes.Act3Quest1);
		bool isPlayerSergeant = MobileParty.MainParty.MapEvent.IsPlayerSergeant();
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		return NavalMissionState.OpenNew("HelpAnAllySetPieceBattle", rec, (InitializeMissionBehaviorsDelegate)delegate
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Expected O, but got Unknown
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Expected O, but got Unknown
			_ = new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[21]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new MissionObjectiveLogic(),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new HelpingAnAllySetPieceBattleMissionController(merchantParty, seaHoundsParty),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new MissionFightHandler(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController()
			};
		});
	}

	[MissionMethod]
	public static Mission OpenFloatingFortressSetPieceBattleMission(MissionInitializerRecord rec, bool startFromCheckpoint)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		NavalStorylineData.SetNavalStorylineSetPieceBattleMissionType(NavalStorylineData.NavalStorylineSetPieceBattleMissionTypes.Act3Quest4);
		bool isPlayerSergeant = MobileParty.MainParty.MapEvent.IsPlayerSergeant();
		rec.AtmosphereOnCampaign.NauticalInfo.UsesNavalSimulatedWater = 1;
		return NavalMissionState.OpenNew("FloatingFortressSetPieceBattleMission", rec, (InitializeMissionBehaviorsDelegate)delegate
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Expected O, but got Unknown
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Expected O, but got Unknown
			IMissionTroopSupplier[] suppliers = (IMissionTroopSupplier[])(object)new IMissionTroopSupplier[2]
			{
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)0, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null),
				(IMissionTroopSupplier)new PartyGroupTroopSupplier(MapEvent.PlayerMapEvent, (BattleSideEnum)1, (FlattenedTroopRoster)null, (Func<UniqueTroopDescriptor, MapEventParty, bool>)null)
			};
			BattleSideEnum playerSide = MobileParty.MainParty.MapEvent.PlayerSide;
			return (IEnumerable<MissionBehavior>)(object)new MissionBehavior[24]
			{
				(MissionBehavior)new NavalShipsLogic(),
				(MissionBehavior)new NavalFloatsamLogic(),
				(MissionBehavior)new NavalAgentsLogic(),
				(MissionBehavior)new NavalTrajectoryPlanningLogic(),
				(MissionBehavior)new BattlePowerCalculationLogic(),
				(MissionBehavior)new NavalBattleAgentLogic(),
				(MissionBehavior)new MissionOptionsComponent(),
				(MissionBehavior)new CampaignMissionComponent(),
				(MissionBehavior)new BattleObserverMissionLogic(),
				(MissionBehavior)new NavalMissionCombatantsLogic((IEnumerable<IBattleCombatant>)MobileParty.MainParty.MapEvent.InvolvedParties, (IBattleCombatant)(object)PartyBase.MainParty, (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)0), (IBattleCombatant)(object)MobileParty.MainParty.MapEvent.GetLeaderParty((BattleSideEnum)1), (MissionTeamAITypeEnum)4, isPlayerSergeant),
				(MissionBehavior)new FloatingFortressSetPieceBattleMissionController(startFromCheckpoint),
				(MissionBehavior)new AgentHumanAILogic(),
				(MissionBehavior)new BattleMissionAgentInteractionLogic(),
				(MissionBehavior)new EquipmentControllerLeaveLogic(),
				(MissionBehavior)new DefaultNavalMissionAgentSpawnLogic(suppliers, playerSide),
				(MissionBehavior)new MissionHintLogic(),
				(MissionBehavior)new MissionObjectiveLogic(),
				(MissionBehavior)new AgentVictoryLogic(),
				(MissionBehavior)new NavalBattleEndLogic(),
				(MissionBehavior)new MissionHardBorderPlacer(),
				(MissionBehavior)new MissionBoundaryPlacer(),
				(MissionBehavior)new MissionBoundaryCrossingHandler(30f),
				(MissionBehavior)new HighlightsController(),
				(MissionBehavior)new BattleHighlightsController()
			};
		});
	}

	[MissionMethod]
	public static Mission OpenNavalStorylineAlleyFightMission(MissionInitializerRecord rec)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		object obj = _003C_003Ec._003C_003E9__11_0;
		if (obj == null)
		{
			InitializeMissionBehaviorsDelegate val = delegate
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0026: Expected O, but got Unknown
				//IL_0027: Unknown result type (might be due to invalid IL or missing references)
				//IL_0031: Expected O, but got Unknown
				//IL_0032: Unknown result type (might be due to invalid IL or missing references)
				//IL_003c: Expected O, but got Unknown
				//IL_003d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0047: Expected O, but got Unknown
				//IL_0048: Unknown result type (might be due to invalid IL or missing references)
				//IL_0052: Expected O, but got Unknown
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				//IL_005e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0068: Expected O, but got Unknown
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_0073: Expected O, but got Unknown
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_007e: Expected O, but got Unknown
				//IL_007f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0089: Expected O, but got Unknown
				//IL_008a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0094: Expected O, but got Unknown
				//IL_009a: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a4: Expected O, but got Unknown
				//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00af: Expected O, but got Unknown
				//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ba: Expected O, but got Unknown
				//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c5: Expected O, but got Unknown
				return new List<MissionBehavior>
				{
					(MissionBehavior)(object)new NavalStorylineAlleyFightMissionController(),
					(MissionBehavior)(object)new NavalStorylineAlleyFightCinematicController(),
					(MissionBehavior)new MissionHintLogic(),
					(MissionBehavior)new MissionOptionsComponent(),
					(MissionBehavior)new AgentHumanAILogic(),
					(MissionBehavior)new BattlePowerCalculationLogic(),
					(MissionBehavior)new CampaignMissionComponent(),
					(MissionBehavior)new BattleObserverMissionLogic(),
					(MissionBehavior)new AgentVictoryLogic(),
					(MissionBehavior)new MissionHardBorderPlacer(),
					(MissionBehavior)new MissionAgentHandler(),
					(MissionBehavior)new MissionFightHandler(),
					(MissionBehavior)new MissionBoundaryPlacer(),
					(MissionBehavior)new MissionBoundaryCrossingHandler(10f),
					(MissionBehavior)new HighlightsController(),
					(MissionBehavior)new BattleHighlightsController(),
					(MissionBehavior)new EquipmentControllerLeaveLogic()
				}.ToArray();
			};
			_003C_003Ec._003C_003E9__11_0 = val;
			obj = (object)val;
		}
		return MissionState.OpenNew("NavalStorylineAlleyFight", rec, (InitializeMissionBehaviorsDelegate)obj, true, true);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using NavalDLC.Missions.AI.TeamAI;
using NavalDLC.Missions.Deployment;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.ShipActuators;
using NavalDLC.Missions.ShipControl;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace NavalDLC.Missions.MissionLogics;

public class NavalRaidMissionAgentSpawnLogic : MissionLogic, IBattleMissionAgentSpawnLogic, IMissionAgentSpawnLogic, IMissionBehavior, INavalMissionAgentSpawnLogic, IAgentStateDecider
{
	private const float DefenderGlobalReinforcementSpawnInterval = 3f;

	private const float DefenderReinforcementBatchPercentage = 0.1f;

	private const float DefenderDesiredReinforcementPercentage = 0.2f;

	private NavalAgentsLogic _navalAgentsLogic;

	private NavalShipsLogic _navalShipsLogic;

	private BannerBearerLogic _bannerBearerLogic;

	private NavalRaidMissionDeploymentPlanningLogic _deploymentPlan;

	private IMissionTroopSupplier[] _battleSideTroopSuppliers;

	private readonly int _battleSize;

	private NavalTeamSideSpawnContext _attackerTeamSpawnContext;

	private MissionBattleSideSpawnContext _defenderSideSpawnContext;

	private readonly BattleSideEnum _playerSide;

	private readonly TeamSideEnum _attackerTeamSide;

	private readonly int _attackerInitialTroopCount;

	private readonly int _defenderInitialTroopCount;

	private readonly int _defenderTotalTroopCount;

	private BasicMissionTimer _defenderReinforcementSpawnTimer;

	private MissionSpawnSettings _defenderSpawnSettings;

	private MissionSpawnPhase _defenderSpawnPhase;

	private bool _defenderReinforcementSpawnEnabled;

	private bool _defenderSideSpawningReinforcements;

	private bool _setReassignCaptainsOfRemovedShips;

	private bool _isAttackerSideDeployed;

	private bool _isDefenderSideDeployed;

	private readonly MBList<IShipOrigin> _attackerTeamShips;

	private readonly NavalShipDeploymentLimit _attackerTeamShipDeploymentLimit;

	public BattleSideEnum PlayerSide
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _playerSide;
		}
	}

	public int TotalSpawnNumber => ((_defenderSpawnPhase != null) ? _defenderSpawnPhase.TotalSpawnNumber : 0) + _attackerTeamSpawnContext.TotalSpawnNumber;

	public int BattleSize => _battleSize;

	public int NumberOfAgents => ((List<Agent>)(object)((MissionBehavior)this).Mission.AllAgents).Count;

	public MissionSpawnPhase DefenderActivePhase => _defenderSpawnPhase;

	public MissionSpawnPhase AttackerActivePhase
	{
		get
		{
			Debug.FailedAssert("Naval raid missions does not use phase system for attacker (naval) side", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\MissionLogics\\NavalRaidMissionAgentSpawnLogic.cs", "AttackerActivePhase", 92);
			return null;
		}
	}

	public ref readonly MissionSpawnSettings SpawnSettings => ref _defenderSpawnSettings;

	public IMissionDeploymentPlan DeploymentPlan => (IMissionDeploymentPlan)(object)_deploymentPlan;

	public bool ReassignCaptainsOfRemovedShips => _setReassignCaptainsOfRemovedShips;

	public int DeployablePlayerShipCount
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			if ((int)_playerSide != 1)
			{
				return 0;
			}
			return _attackerTeamShipDeploymentLimit.NetDeploymentLimit;
		}
	}

	public bool IsInitialSpawnOver
	{
		get
		{
			if (DefenderActivePhase.InitialSpawnNumber == 0)
			{
				return _attackerTeamSpawnContext.IsInitialSpawnOver;
			}
			return false;
		}
	}

	public bool IsDeploymentOver
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			if ((int)((MissionBehavior)this).Mission.Mode != 6)
			{
				return IsInitialSpawnOver;
			}
			return false;
		}
	}

	public MBReadOnlyList<IShipOrigin> AttackerTeamShips => (MBReadOnlyList<IShipOrigin>)(object)_attackerTeamShips;

	public MBReadOnlyList<IShipOrigin> PlayerShips
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			if ((int)_playerSide == 1)
			{
				return (MBReadOnlyList<IShipOrigin>)(object)_attackerTeamShips;
			}
			return null;
		}
	}

	public event Action PlayerShipsUpdated;

	public NavalRaidMissionAgentSpawnLogic(IMissionTroopSupplier[] suppliers, BattleSideEnum playerSide, MBList<IShipOrigin> attackerSideShips, NavalShipDeploymentLimit attackerSideShipDeploymentLimit, int attackerTroopCount, int defenderTroopCount)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		_defenderReinforcementSpawnEnabled = true;
		_setReassignCaptainsOfRemovedShips = true;
		((MissionLogic)this)._002Ector();
		_playerSide = playerSide;
		_battleSize = BannerlordConfig.GetRealBattleSize();
		_battleSize = MathF.Min(_battleSize, DefaultBattleMissionAgentSpawnLogic.MaxNumberOfTroopsForMission);
		_battleSideTroopSuppliers = suppliers;
		_attackerTeamSide = (TeamSideEnum)(((int)_playerSide != 1) ? 2 : 0);
		_attackerTeamShips = attackerSideShips;
		_attackerTeamShipDeploymentLimit = attackerSideShipDeploymentLimit;
		ComputeInitialTroopCounts(attackerTroopCount, defenderTroopCount, out var initialAttackerTroopCount, out var initialDefenderTroopCount);
		if (attackerTroopCount > initialAttackerTroopCount)
		{
			MBDebug.ShowWarning("Attacker deployable troop count is not supported by current battle size. Make sure UI side clamps this number w.r.t. battle size");
			_attackerInitialTroopCount = initialAttackerTroopCount;
		}
		else
		{
			_attackerInitialTroopCount = attackerTroopCount;
		}
		_defenderInitialTroopCount = initialDefenderTroopCount;
		_defenderTotalTroopCount = defenderTroopCount;
		_isAttackerSideDeployed = false;
		_isDefenderSideDeployed = false;
	}

	public override void OnBehaviorInitialize()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		((MissionBehavior)this).OnBehaviorInitialize();
		_navalAgentsLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalAgentsLogic>();
		_navalAgentsLogic.SetDeploymentMode(value: true);
		_navalShipsLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalShipsLogic>();
		_navalShipsLogic.SetDeploymentMode(value: true);
		_navalShipsLogic.SetTeamShipDeploymentLimit(_attackerTeamSide, _attackerTeamShipDeploymentLimit);
		_navalShipsLogic.BeforeShipRemovedEvent += OnBeforeShipRemoved;
		_deploymentPlan = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalRaidMissionDeploymentPlanningLogic>();
		if (!SailWindProfile.IsSailWindProfileInitialized)
		{
			SailWindProfile.InitializeProfile();
		}
		MissionGameModels.Current.BattleInitializationModel.InitializeModel();
		BattleInitializationModel.SetBypassPlayerDeployment(true);
	}

	public override void OnMissionStateFinalized()
	{
		SailWindProfile.FinalizeProfile();
		_navalShipsLogic.BeforeShipRemovedEvent -= OnBeforeShipRemoved;
		BattleInitializationModel.SetBypassPlayerDeployment(false);
	}

	public override void EarlyStart()
	{
		((MissionBehavior)this).EarlyStart();
		InitializeMissionTeamSides();
	}

	public override void AfterStart()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		((MissionBehavior)this).AfterStart();
		DefaultNavalMissionLogic.UpdateSceneWindDirection();
		InitializeShipAssignments();
		_defenderSpawnPhase = new MissionSpawnPhase
		{
			TotalSpawnNumber = _defenderTotalTroopCount,
			InitialSpawnNumber = _defenderInitialTroopCount,
			RemainingSpawnNumber = _defenderTotalTroopCount - _defenderInitialTroopCount
		};
		Team team = ((IEnumerable<Team>)((MissionBehavior)this).Mission.Teams).FirstOrDefault(delegate(Team t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return t.TeamSide != _attackerTeamSide;
		});
		_deploymentPlan.SetSpawnWithHorses(team, spawnWithHorses: false);
		((MissionBehavior)this).Mission.SetBattleAgentCount(MathF.Min(_defenderSpawnPhase.InitialSpawnNumber, _attackerTeamSpawnContext.TotalSpawnNumber));
		((MissionBehavior)this).Mission.SetInitialAgentCountForSide((BattleSideEnum)0, _defenderInitialTroopCount);
		((MissionBehavior)this).Mission.SetInitialAgentCountForSide((BattleSideEnum)1, _attackerTeamSpawnContext.TotalSpawnNumber);
		_bannerBearerLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<BannerBearerLogic>();
		if (_bannerBearerLogic != null)
		{
			for (int num = 0; num < 2; num++)
			{
				_defenderSideSpawnContext.SetBannerBearerLogic(_bannerBearerLogic);
			}
		}
		MissionGameModels.Current.BattleSpawnModel.OnMissionStart();
	}

	public override void OnDeploymentFinished()
	{
		foreach (MissionShip item in (List<MissionShip>)(object)_navalShipsLogic.AllShips)
		{
			item.SetAnchor(isAnchored: false);
			if (!item.IsPlayerShip)
			{
				item.SetController(ShipControllerType.AI);
			}
		}
		_navalShipsLogic.SetDeploymentMode(value: false);
		_attackerTeamSpawnContext.OnDeploymentFinished();
		_navalAgentsLogic.SetIgnoreTroopCapacities(value: true);
		_navalAgentsLogic.SetDeploymentMode(value: false);
	}

	public override void OnMissionTick(float dt)
	{
		if (!_isAttackerSideDeployed || !_isDefenderSideDeployed)
		{
			return;
		}
		if (!((MissionBehavior)this).Mission.IsDeploymentFinished)
		{
			_attackerTeamSpawnContext.OnDeploymentTick(dt);
			return;
		}
		if (_defenderReinforcementSpawnEnabled)
		{
			CheckDefenderReinforcementBatch();
		}
		if (_defenderSideSpawningReinforcements)
		{
			CheckDefenderReinforcementSpawn();
		}
	}

	public AgentState GetAgentState(Agent affectedAgent, float deathProbability, out bool usedSurgery)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return DefaultNavalMissionLogic.GetNavalAgentState(affectedAgent, deathProbability, out usedSurgery);
	}

	public void StartSpawner(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if ((int)side == 1)
		{
			_attackerTeamSpawnContext.SetSpawnTroops(spawnTroops: true);
		}
		else if ((int)side == 0)
		{
			_defenderSideSpawnContext.SetSpawnTroops(true);
		}
	}

	public void StopSpawner(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		if ((int)side == 1)
		{
			_attackerTeamSpawnContext.SetSpawnTroops(spawnTroops: false);
		}
		else
		{
			_defenderSideSpawnContext.SetSpawnTroops(false);
		}
	}

	public bool IsSideSpawnEnabled(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		if ((int)side == 1)
		{
			return _attackerTeamSpawnContext.TroopSpawningActive;
		}
		return _defenderSideSpawnContext.TroopSpawnActive;
	}

	public bool IsSideDepleted(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if ((int)side == 1)
		{
			int num = 0;
			foreach (Team item in (List<Team>)(object)((MissionBehavior)this).Mission.Teams)
			{
				if (item.Side == side)
				{
					num += ((List<Agent>)(object)item.ActiveAgents).Count;
				}
			}
			num += _navalAgentsLogic.GetNumberOfReservedTroops(side, spawnableOnly: true);
			return num == 0;
		}
		if (_defenderSideSpawnContext.NumberOfActiveTroops == 0)
		{
			return _defenderSpawnPhase.RemainingSpawnNumber == 0;
		}
		return false;
	}

	internal void SetDefenderReinforcementSpawnEnabled(bool value, bool resetTimers = true)
	{
		if (_defenderReinforcementSpawnEnabled != value)
		{
			_defenderReinforcementSpawnEnabled = value;
			if (resetTimers)
			{
				_defenderReinforcementSpawnTimer.Reset();
			}
		}
	}

	public float GetReinforcementInterval(BattleSideEnum battleSide)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		if ((int)battleSide == 1)
		{
			return NavalAgentsLogic.ComputeReinforcementSpawnDuration(0);
		}
		return ((MissionSpawnSettings)(ref _defenderSpawnSettings)).GlobalReinforcementInterval;
	}

	public int GetNumberOfPlayerControllableTroops()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)_attackerTeamSide == 0)
		{
			return _attackerInitialTroopCount;
		}
		return _defenderSideSpawnContext.GetNumberOfPlayerControllableTroops();
	}

	public IEnumerable<IAgentOriginBase> GetAllTroopsForSide(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Expected I4, but got Unknown
		int num = (int)side;
		return _battleSideTroopSuppliers[num].GetAllTroops();
	}

	public void SetSpawnTroops(BattleSideEnum battleSide, bool spawnTroops, bool enforceSpawning = false)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)battleSide == 0)
		{
			_defenderSideSpawnContext.SetSpawnTroops(spawnTroops);
		}
		else
		{
			_attackerTeamSpawnContext.SetSpawnTroops(spawnTroops);
		}
	}

	public bool GetSpawnHorses(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)side == 0)
		{
			return _defenderSideSpawnContext.SpawnWithHorses;
		}
		return false;
	}

	public void OnSideDeploymentOver(BattleSideEnum battleSide)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Invalid comparison between Unknown and I4
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		foreach (Team item in (List<Team>)(object)((MissionBehavior)this).Mission.Teams)
		{
			if (item.Side == battleSide)
			{
				((MissionBehavior)this).Mission.OnTeamDeployed(item);
			}
		}
		((MissionBehavior)this).Mission.OnBattleSideDeployed(battleSide);
		foreach (Team item2 in (List<Team>)(object)((MissionBehavior)this).Mission.Teams)
		{
			if (item2.Side == battleSide)
			{
				foreach (Formation item3 in (List<Formation>)(object)item2.FormationsIncludingEmpty)
				{
					if (item3.CountOfUnits > 0)
					{
						item3.QuerySystem.EvaluateAllPreliminaryQueryData();
					}
				}
			}
			if ((int)item2.Side != 0)
			{
				continue;
			}
			item2.MasterOrderController.OnOrderIssued += new OnOrderIssuedDelegate(OrderController_OnOrderIssued);
			for (int i = 8; i < 10; i++)
			{
				Formation val = ((List<Formation>)(object)item2.FormationsIncludingSpecialAndEmpty)[i];
				if (val.CountOfUnits > 0)
				{
					item2.MasterOrderController.SelectFormation(val);
					item2.MasterOrderController.SetOrderWithAgent((OrderType)7, item2.GeneralAgent);
					item2.MasterOrderController.ClearSelectedFormations();
					val.SetControlledByAI(true, false);
				}
			}
			item2.MasterOrderController.OnOrderIssued -= new OnOrderIssuedDelegate(OrderController_OnOrderIssued);
		}
		if ((int)battleSide == 1 && battleSide == _playerSide)
		{
			Team playerTeam = ((MissionBehavior)this).Mission.PlayerTeam;
			Formation val2 = ((playerTeam != null) ? ((IEnumerable<Formation>)playerTeam.FormationsIncludingEmpty).FirstOrDefault((Func<Formation, bool>)NavalDLCHelpers.IsPlayerCaptainOfFormationShip) : null);
			if (val2 != null && ((MissionBehavior)this).Mission.PlayerTeam.PlayerOrderController is NavalOrderController navalOrderController)
			{
				((OrderController)navalOrderController).SelectFormation(val2);
				((OrderController)navalOrderController).SetOrder((OrderType)34);
				((OrderController)navalOrderController).SetFormationUpdateEnabledAfterSetOrder(true);
				((OrderController)navalOrderController).ClearSelectedFormations();
			}
		}
	}

	public void DeployAttackerSideShips()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		MakeAttackerDeploymentPlans();
		Team val = ((IEnumerable<Team>)((MissionBehavior)this).Mission.Teams).FirstOrDefault(delegate(Team t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			return (int)t.Side == 1;
		});
		foreach (Formation item in (List<Formation>)(object)val.FormationsIncludingEmpty)
		{
			FormationClass formationIndex = item.FormationIndex;
			IFormationDeploymentPlan formationPlan = ((MissionDeploymentPlanningLogic)_deploymentPlan).GetFormationPlan(val, formationIndex, false);
			if (formationPlan.HasFrame())
			{
				MatrixFrame spawnFrame = formationPlan.GetFrame();
				_navalShipsLogic.SpawnShip(item, in spawnFrame, spawnAnchored: true, checkForFreeArea: false).SetController(ShipControllerType.None);
			}
		}
	}

	public void DeployAttackerSideTroops()
	{
		SetSpawnTroops((BattleSideEnum)1, spawnTroops: true);
		_attackerTeamSpawnContext.AllocateAndDeployInitialTroops(((MissionBehavior)this).Mission);
		_isAttackerSideDeployed = true;
	}

	public void UpdateAttackerShips()
	{
		_attackerTeamSpawnContext.UpdateShips();
	}

	public void OnPlayerShipsUpdated()
	{
		PlayerShipsUpdated?.Invoke();
	}

	public void SetReassignCaptainsOfRemovedShips(bool value)
	{
		_setReassignCaptainsOfRemovedShips = value;
	}

	private void InitializeShipAssignments()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		_navalShipsLogic.ClearShipAssignments();
		int num = MathF.Min(_attackerTeamShipDeploymentLimit.NetDeploymentLimit, ((List<IShipOrigin>)(object)_attackerTeamShips).Count);
		num = MathF.Min(_navalAgentsLogic.GetTeamTroopOrigins(_attackerTeamSide).Count(), num);
		foreach (var item in AssignShipsToFormations((MBReadOnlyList<IShipOrigin>)(object)_attackerTeamShips, num))
		{
			_navalShipsLogic.SetShipAssignment(_attackerTeamSide, item.formationIndex, item.ship);
		}
	}

	public bool HasPendingCaptainAssignment(Formation formation)
	{
		return _attackerTeamSpawnContext.HasPendingCaptainAssignment(formation);
	}

	private List<(FormationClass formationIndex, IShipOrigin ship)> AssignShipsToFormations(MBReadOnlyList<IShipOrigin> ships, int shipCount)
	{
		List<(FormationClass, IShipOrigin)> list = new List<(FormationClass, IShipOrigin)>();
		int num = 8;
		int num2 = 0;
		foreach (IShipOrigin item in (List<IShipOrigin>)(object)ships)
		{
			if (num2 < num && num2 < shipCount)
			{
				list.Add(((FormationClass)num2, item));
				num2++;
				continue;
			}
			break;
		}
		return list;
	}

	private void MakeAttackerDeploymentPlans()
	{
		Team val = ((IEnumerable<Team>)((MissionBehavior)this).Mission.Teams).Where(delegate(Team t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			return (int)t.Side == 1 && _navalShipsLogic.GetCountOfSetShipAssignments(t.TeamSide) > 0;
		}).First();
		AddTeamShipsToDeploymentPlan(val);
		((MissionDeploymentPlanningLogic)_deploymentPlan).MakeDeploymentPlan(val, 0f, 0f);
	}

	private void AddTeamShipsToDeploymentPlan(Team team)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 11; i++)
		{
			ShipAssignment shipAssignment = _navalShipsLogic.GetShipAssignment(team.TeamSide, (FormationClass)i);
			if (shipAssignment.IsSet)
			{
				_deploymentPlan.AddShip(team, shipAssignment.FormationIndex, shipAssignment.ShipOrigin);
			}
		}
	}

	private void OnBeforeShipRemoved(MissionShip ship)
	{
		if (ship.Team != null)
		{
			_attackerTeamSpawnContext.OnBeforeShipRemoved(ship);
		}
	}

	public void DeployDefenderSideTroops()
	{
		SetSpawnTroops((BattleSideEnum)0, spawnTroops: true);
		Team defenderTeam = ((IEnumerable<Team>)((MissionBehavior)this).Mission.Teams).FirstOrDefault(delegate(Team t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			return (int)t.Side == 0;
		});
		int num = MathF.Max(BannerlordConfig.GetRealBattleSize() - _attackerInitialTroopCount, 0);
		int num2 = MathF.Min(_defenderSpawnPhase.InitialSpawnNumber, num);
		_defenderSideSpawnContext.SetSpawnWithHorses(false);
		_defenderSideSpawnContext.ReserveTroops(num2);
		MakeDefenderDeploymentPlans(defenderTeam);
		_defenderSideSpawnContext.SpawnTroops(num2, false);
		DefenderActivePhase.OnInitialTroopsSpawned();
		_defenderSideSpawnContext.OnInitialSpawnOver();
		_isDefenderSideDeployed = true;
	}

	private void CheckDefenderReinforcementSpawn()
	{
		if (_defenderSideSpawnContext.HasSpawnableReinforcements && (float)_defenderSideSpawnContext.ReinforcementsSpawnedInLastBatch < _defenderSideSpawnContext.ReinforcementBatchSize)
		{
			int num = _defenderSideSpawnContext.TryReinforcementSpawn();
			MissionSpawnPhase defenderActivePhase = DefenderActivePhase;
			defenderActivePhase.RemainingSpawnNumber -= num;
			if (0 + num > 0)
			{
				NotifyDefenderReinforcementTroopsSpawned(checkEmptyReserves: true);
			}
		}
	}

	private void MakeDefenderDeploymentPlans(Team defenderTeam)
	{
		MBList<(Team, MissionFormationSpawnData[])> source = default(MBList<(Team, MissionFormationSpawnData[])>);
		_defenderSideSpawnContext.GetTeamFormationsSpawnData(ref source);
		MissionFormationSpawnData[] item = ((IEnumerable<(Team, MissionFormationSpawnData[])>)source).First().Item2;
		for (int i = 0; i < item.Length; i++)
		{
			if (((MissionFormationSpawnData)(ref item[i])).NumTroops > 0)
			{
				_deploymentPlan.AddTroops(defenderTeam, (FormationClass)i, item[i].FootTroopCount, item[i].MountedTroopCount);
			}
		}
		((MissionDeploymentPlanningLogic)_deploymentPlan).MakeDeploymentPlan(defenderTeam, 0f, 0f);
		if (_deploymentPlan.IsReinforcementPlanMade(defenderTeam))
		{
			return;
		}
		int num = Math.Max(_battleSize / (2 * item.Length), 1);
		for (int j = 0; j < item.Length; j++)
		{
			if (TroopClassExtensions.IsMounted((FormationClass)j))
			{
				_deploymentPlan.AddTroops(defenderTeam, (FormationClass)j, 0, num, isReinforcement: true);
			}
			else
			{
				_deploymentPlan.AddTroops(defenderTeam, (FormationClass)j, num, 0, isReinforcement: true);
			}
		}
		_deploymentPlan.MakeReinforcementDeploymentPlan(defenderTeam);
	}

	private void CheckDefenderReinforcementBatch()
	{
		if (_defenderReinforcementSpawnTimer.ElapsedTime >= ((MissionSpawnSettings)(ref _defenderSpawnSettings)).GlobalReinforcementInterval)
		{
			NotifyDefenderReinforcementTroopsSpawned(checkEmptyReserves: false);
			bool flag = _defenderSideSpawnContext.CheckReinforcementBatch();
			_defenderSideSpawningReinforcements = flag && CheckDefenderMinimumBatchQuotaRequirement();
			_defenderReinforcementSpawnTimer.Reset();
		}
	}

	private bool CheckDefenderMinimumBatchQuotaRequirement()
	{
		int num = DefaultBattleMissionAgentSpawnLogic.MaxNumberOfAgentsForMission - NumberOfAgents;
		int num2 = 0;
		for (int i = 0; i < 2; i++)
		{
			num2 += _defenderSideSpawnContext.ReinforcementQuotaRequirement;
		}
		return num >= num2;
	}

	private void NotifyDefenderReinforcementTroopsSpawned(bool checkEmptyReserves)
	{
		int reinforcementsSpawnedInLastBatch = _defenderSideSpawnContext.ReinforcementsSpawnedInLastBatch;
		if (!_defenderSideSpawnContext.ReinforcementsNotifiedOnLastBatch && reinforcementsSpawnedInLastBatch > 0 && (!checkEmptyReserves || (checkEmptyReserves && !_defenderSideSpawnContext.HasReservedTroops)))
		{
			_defenderSideSpawnContext.SetReinforcementsNotifiedOnLastBatch(true);
		}
	}

	private void OrderController_OnOrderIssued(OrderType orderType, MBReadOnlyList<Formation> appliedFormations, OrderController orderController, params object[] delegateParams)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		DeploymentHandler.OrderController_OnOrderIssued_Aux(orderType, appliedFormations, orderController, delegateParams);
	}

	private void InitializeMissionTeamSides()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		_defenderReinforcementSpawnTimer = new BasicMissionTimer();
		_defenderSpawnSettings = new MissionSpawnSettings((InitialSpawnMethod)1, (ReinforcementTimingMethod)0, (ReinforcementSpawnMethod)0, 3f, 0.1f, 0.2f, 0f, 0, 0f, 0f, 1f, 0.75f);
		_defenderSideSpawnContext = new MissionBattleSideSpawnContext((IBattleMissionAgentSpawnLogic)(object)this, (BattleSideEnum)0, _battleSideTroopSuppliers[0], (int)_playerSide == 0, false);
		MBList<IAgentOriginBase> val = new MBList<IAgentOriginBase>();
		foreach (IAgentOriginBase item in _battleSideTroopSuppliers[1].SupplyTroops(_attackerInitialTroopCount))
		{
			((List<IAgentOriginBase>)(object)val).Add(item);
		}
		_attackerTeamSpawnContext = new NavalTeamSideSpawnContext(((MissionBehavior)this).Mission, this, (BattleSideEnum)1, _attackerTeamSide, val);
	}

	public static void ComputeInitialTroopCounts(int totalAttackerTroopCount, int totalDefenderTroopCount, out int initialAttackerTroopCount, out int initialDefenderTroopCount)
	{
		int realBattleSize = BannerlordConfig.GetRealBattleSize();
		int num = totalAttackerTroopCount + totalDefenderTroopCount;
		if (num <= realBattleSize)
		{
			initialAttackerTroopCount = totalAttackerTroopCount;
			initialDefenderTroopCount = totalDefenderTroopCount;
			return;
		}
		int minimumDeployableTroopCountPerSide = GetMinimumDeployableTroopCountPerSide(realBattleSize);
		initialAttackerTroopCount = MathF.Round((float)realBattleSize * ((float)totalAttackerTroopCount / (float)num));
		if (totalAttackerTroopCount >= minimumDeployableTroopCountPerSide)
		{
			initialAttackerTroopCount = Math.Max(initialAttackerTroopCount, minimumDeployableTroopCountPerSide);
		}
		if (totalDefenderTroopCount >= minimumDeployableTroopCountPerSide)
		{
			int val = realBattleSize - minimumDeployableTroopCountPerSide;
			initialAttackerTroopCount = Math.Min(initialAttackerTroopCount, val);
		}
		initialAttackerTroopCount = Math.Min(initialAttackerTroopCount, totalAttackerTroopCount);
		initialAttackerTroopCount = Math.Max(0, initialAttackerTroopCount);
		initialDefenderTroopCount = realBattleSize - initialAttackerTroopCount;
		initialDefenderTroopCount = Math.Min(initialDefenderTroopCount, totalDefenderTroopCount);
		initialDefenderTroopCount = Math.Max(0, initialDefenderTroopCount);
		int num2 = realBattleSize - (initialAttackerTroopCount + initialDefenderTroopCount);
		if (num2 > 0)
		{
			int num3 = Math.Min(num2, totalAttackerTroopCount - initialAttackerTroopCount);
			initialAttackerTroopCount += num3;
		}
	}

	public static int GetMinimumDeployableTroopCountPerSide(int battleSize)
	{
		return Math.Max(1, MathF.Floor((float)battleSize * 0.2f));
	}
}

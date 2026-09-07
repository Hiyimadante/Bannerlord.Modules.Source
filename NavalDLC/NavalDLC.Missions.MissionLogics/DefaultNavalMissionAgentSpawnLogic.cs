using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.AI.TeamAI;
using NavalDLC.Missions.Objects;
using SandBox.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class DefaultNavalMissionAgentSpawnLogic : MissionLogic, IMissionAgentSpawnLogic, IMissionBehavior, INavalMissionAgentSpawnLogic
{
	[CompilerGenerated]
	private BattleSideEnum _003CPlayerSide_003Ek__BackingField;

	private NavalAgentsLogic _agentsLogic;

	private NavalShipsLogic _shipsLogic;

	private readonly MBList<NavalTeamSideSpawnContext> _missionTeamSides;

	private IMissionTroopSupplier[] _battleSideTroopSuppliers;

	private readonly int[] _maxDeployableTroopCountPerTeam;

	private BattleSideEnum _playerSide;

	private int _numTroopsControllableByPlayer;

	private bool _setReassignCaptainsOfRemovedShips;

	public BattleSideEnum PlayerSide
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CPlayerSide_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CPlayerSide_003Ek__BackingField = value;
		}
	}

	public int DeployablePlayerShipCount { get; private set; }

	public bool ReassignCaptainsOfRemovedShips => _setReassignCaptainsOfRemovedShips;

	public event Action PlayerShipsUpdated;

	public DefaultNavalMissionAgentSpawnLogic(IMissionTroopSupplier[] suppliers, BattleSideEnum playerSide, int deployablePlayerShipCount = 0, int[] maxDeployableTroopCountPerTeam = null)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		_setReassignCaptainsOfRemovedShips = true;
		((MissionLogic)this)._002Ector();
		PlayerSide = playerSide;
		_missionTeamSides = new MBList<NavalTeamSideSpawnContext>();
		int num = 3;
		DeployablePlayerShipCount = deployablePlayerShipCount;
		_maxDeployableTroopCountPerTeam = new int[num];
		if (maxDeployableTroopCountPerTeam == null)
		{
			for (int i = 0; i < num; i++)
			{
				_maxDeployableTroopCountPerTeam[i] = int.MaxValue;
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				int num2 = maxDeployableTroopCountPerTeam[j];
				_maxDeployableTroopCountPerTeam[j] = num2;
			}
		}
		_battleSideTroopSuppliers = suppliers;
		_playerSide = playerSide;
	}

	public override void OnBehaviorInitialize()
	{
		((MissionBehavior)this).OnBehaviorInitialize();
		_agentsLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalAgentsLogic>();
		_agentsLogic.SetDeploymentMode(value: true);
		_shipsLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalShipsLogic>();
		_shipsLogic.BeforeShipRemovedEvent += OnBeforeShipRemoved;
		MissionGameModels.Current.BattleInitializationModel.InitializeModel();
	}

	public override void OnMissionStateFinalized()
	{
		_shipsLogic.BeforeShipRemovedEvent -= OnBeforeShipRemoved;
	}

	public override void EarlyStart()
	{
		((MissionBehavior)this).EarlyStart();
		InitializeMissionTeamSides();
	}

	public override void OnDeploymentFinished()
	{
		foreach (NavalTeamSideSpawnContext item in (List<NavalTeamSideSpawnContext>)(object)_missionTeamSides)
		{
			item.OnDeploymentFinished();
		}
		_agentsLogic.SetIgnoreTroopCapacities(value: true);
		_agentsLogic.SetDeploymentMode(value: false);
		BattleAgentLogic missionBehavior = ((MissionBehavior)this).Mission.GetMissionBehavior<BattleAgentLogic>();
		foreach (MissionShip item2 in (List<MissionShip>)(object)_shipsLogic.AllShips)
		{
			foreach (Agent item3 in (List<Agent>)(object)_agentsLogic.GetActiveAgentsOfShip(item2))
			{
				if (missionBehavior != null)
				{
					((MissionBehavior)missionBehavior).OnAgentBuild(item3, (Banner)null);
				}
			}
		}
	}

	public override void OnMissionTick(float dt)
	{
		if (((MissionBehavior)this).Mission.IsDeploymentFinished)
		{
			return;
		}
		foreach (NavalTeamSideSpawnContext item in (List<NavalTeamSideSpawnContext>)(object)_missionTeamSides)
		{
			item.OnDeploymentTick(dt);
		}
	}

	public void StartSpawner(BattleSideEnum side)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		foreach (NavalTeamSideSpawnContext item in (List<NavalTeamSideSpawnContext>)(object)_missionTeamSides)
		{
			if (item.BattleSide == side)
			{
				item.SetSpawnTroops(spawnTroops: true);
			}
		}
	}

	public void StopSpawner(BattleSideEnum side)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		foreach (NavalTeamSideSpawnContext item in (List<NavalTeamSideSpawnContext>)(object)_missionTeamSides)
		{
			if (item.BattleSide == side)
			{
				item.SetSpawnTroops(spawnTroops: false);
			}
		}
	}

	public bool IsSideSpawnEnabled(BattleSideEnum side)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		foreach (NavalTeamSideSpawnContext item in (List<NavalTeamSideSpawnContext>)(object)_missionTeamSides)
		{
			if (item.BattleSide == side)
			{
				flag = flag || item.TroopSpawningActive;
			}
		}
		return flag;
	}

	public bool IsSideDepleted(BattleSideEnum side)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		foreach (Team item in (List<Team>)(object)((MissionBehavior)this).Mission.Teams)
		{
			if (item.Side == side)
			{
				num += ((List<Agent>)(object)item.ActiveAgents).Count;
			}
		}
		num += _agentsLogic.GetNumberOfReservedTroops(side, spawnableOnly: true);
		return num == 0;
	}

	public float GetReinforcementInterval(BattleSideEnum side = (BattleSideEnum)(-1))
	{
		return 0f;
	}

	public int GetNumberOfPlayerControllableTroops()
	{
		return _numTroopsControllableByPlayer;
	}

	public IEnumerable<IAgentOriginBase> GetAllTroopsForSide(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Expected I4, but got Unknown
		int num = (int)side;
		return _battleSideTroopSuppliers[num].GetAllTroops();
	}

	public bool GetSpawnHorses(BattleSideEnum side)
	{
		return false;
	}

	public void OnPlayerShipsUpdated()
	{
		PlayerShipsUpdated?.Invoke();
	}

	public void SetReassignCaptainsOfRemovedShips(bool value)
	{
		_setReassignCaptainsOfRemovedShips = value;
	}

	internal void AllocateAndDeployInitialTroops(BattleSideEnum battleSide)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		SetSpawnTroops(battleSide, spawnTroops: true);
		foreach (NavalTeamSideSpawnContext item in (List<NavalTeamSideSpawnContext>)(object)_missionTeamSides)
		{
			if (item.BattleSide == battleSide)
			{
				item.AllocateAndDeployInitialTroops(((MissionBehavior)this).Mission);
			}
		}
	}

	internal void UpdateShips(TeamSideEnum teamSide)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		GetMissionTeamSide(teamSide, out var missionTeamSide);
		missionTeamSide.UpdateShips();
	}

	internal void SetSpawnTroops(BattleSideEnum battleSide, bool spawnTroops, bool enforceSpawning = false)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		foreach (NavalTeamSideSpawnContext item in (List<NavalTeamSideSpawnContext>)(object)_missionTeamSides)
		{
			if (item.BattleSide == battleSide)
			{
				item.SetSpawnTroops(spawnTroops, enforceSpawning);
			}
		}
	}

	internal bool HasPendingCaptainAssignment(Formation formation)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		GetMissionTeamSide(formation.Team.TeamSide, out var missionTeamSide);
		return missionTeamSide.HasPendingCaptainAssignment(formation);
	}

	internal void OnSideDeploymentOver(BattleSideEnum side)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		IEnumerable<Team> teamsOfSide = Mission.GetTeamsOfSide(side);
		foreach (Team item in teamsOfSide)
		{
			((MissionBehavior)this).Mission.OnTeamDeployed(item);
		}
		((MissionBehavior)this).Mission.OnBattleSideDeployed(side);
		foreach (Team item2 in teamsOfSide)
		{
			foreach (Formation item3 in (List<Formation>)(object)item2.FormationsIncludingEmpty)
			{
				if (item3.CountOfUnits > 0)
				{
					item3.QuerySystem.EvaluateAllPreliminaryQueryData();
				}
			}
		}
		Team playerTeam = ((MissionBehavior)this).Mission.PlayerTeam;
		Formation val = ((playerTeam != null) ? ((IEnumerable<Formation>)playerTeam.FormationsIncludingEmpty).FirstOrDefault((Func<Formation, bool>)NavalDLCHelpers.IsPlayerCaptainOfFormationShip) : null);
		if (val != null && ((MissionBehavior)this).Mission.PlayerTeam.PlayerOrderController is NavalOrderController navalOrderController)
		{
			((OrderController)navalOrderController).SelectFormation(val);
			((OrderController)navalOrderController).SetOrder((OrderType)34);
			((OrderController)navalOrderController).SetFormationUpdateEnabledAfterSetOrder(true);
			((OrderController)navalOrderController).ClearSelectedFormations();
		}
	}

	private void InitializeMissionTeamSides()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		MBList<(Team, MBList<IAgentOriginBase>)> val = new MBList<(Team, MBList<IAgentOriginBase>)>();
		foreach (Team item4 in (List<Team>)(object)((MissionBehavior)this).Mission.Teams)
		{
			((List<(Team, MBList<IAgentOriginBase>)>)(object)val).Add((item4, new MBList<IAgentOriginBase>()));
		}
		for (int i = 0; i < 2; i++)
		{
			IMissionTroopSupplier val2 = _battleSideTroopSuppliers[i];
			BattleSideEnum val3 = (BattleSideEnum)i;
			bool flag = val3 == _playerSide;
			if (flag)
			{
				_numTroopsControllableByPlayer = val2.GetNumberOfPlayerControllableTroops();
			}
			bool flag2 = true;
			while (val2.AnyTroopRemainsToBeSupplied && (flag2 || IsAnyTeamsUnfilled(val3, val, _maxDeployableTroopCountPerTeam)))
			{
				flag2 = false;
				IAgentOriginBase val4 = val2.SupplyOneTroop();
				if (val4 != null)
				{
					Team troopTeam = Mission.GetAgentTeam(val4, flag);
					MBList<IAgentOriginBase> item = ((IEnumerable<(Team, MBList<IAgentOriginBase>)>)val).FirstOrDefault<(Team, MBList<IAgentOriginBase>)>(((Team team, MBList<IAgentOriginBase> troopOrigins) tuple2) => tuple2.team == troopTeam).Item2;
					if (((List<IAgentOriginBase>)(object)item).Count < _maxDeployableTroopCountPerTeam[troopTeam.TeamSide])
					{
						((List<IAgentOriginBase>)(object)item).Add(val4);
						flag2 = true;
					}
				}
			}
		}
		(Team, MBList<IAgentOriginBase>) tuple = ((IEnumerable<(Team, MBList<IAgentOriginBase>)>)val).FirstOrDefault<(Team, MBList<IAgentOriginBase>)>(delegate((Team team, MBList<IAgentOriginBase> troopOrigins) tuple2)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			return (int)tuple2.team.TeamSide == 0;
		});
		_numTroopsControllableByPlayer = MathF.Min(_numTroopsControllableByPlayer, ((List<IAgentOriginBase>)(object)tuple.Item2).Count);
		foreach (var item5 in (List<(Team, MBList<IAgentOriginBase>)>)(object)val)
		{
			BattleSideEnum side = item5.Item1.Side;
			TeamSideEnum teamSide = item5.Item1.TeamSide;
			MBList<IAgentOriginBase> item2 = item5.Item2;
			_ = _playerSide;
			NavalTeamSideSpawnContext item3 = new NavalTeamSideSpawnContext(((MissionBehavior)this).Mission, this, side, teamSide, item2);
			((List<NavalTeamSideSpawnContext>)(object)_missionTeamSides).Add(item3);
			((List<IAgentOriginBase>)(object)item2).Clear();
		}
		((List<(Team, MBList<IAgentOriginBase>)>)(object)val).Clear();
	}

	private void OnBeforeShipRemoved(MissionShip ship)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (ship.Team != null && GetMissionTeamSide(ship.Team.TeamSide, out var missionTeamSide))
		{
			missionTeamSide.OnBeforeShipRemoved(ship);
		}
	}

	private bool GetMissionTeamSide(TeamSideEnum teamSide, out NavalTeamSideSpawnContext missionTeamSide)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		missionTeamSide = ((IEnumerable<NavalTeamSideSpawnContext>)_missionTeamSides).FirstOrDefault(delegate(NavalTeamSideSpawnContext mts)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return mts.TeamSide == teamSide;
		});
		return missionTeamSide != null;
	}

	private static bool IsAnyTeamsUnfilled(BattleSideEnum battleSide, MBList<(Team team, MBList<IAgentOriginBase> troopOrigins)> troopOriginsPerTeam, int[] maxDeployableTroopCountPerTeam)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		foreach (var item in (List<(Team, MBList<IAgentOriginBase>)>)(object)troopOriginsPerTeam)
		{
			if (item.Item1.Side == battleSide && (((List<IAgentOriginBase>)(object)item.Item2)?.Count ?? 0) < maxDeployableTroopCountPerTeam[item.Item1.TeamSide])
			{
				return true;
			}
		}
		return false;
	}
}

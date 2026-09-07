using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

internal class NavalTeamSideSpawnContext
{
	[CompilerGenerated]
	private BattleSideEnum _003CBattleSide_003Ek__BackingField;

	[CompilerGenerated]
	private readonly TeamSideEnum _003CTeamSide_003Ek__BackingField;

	private readonly INavalMissionAgentSpawnLogic _agentSpawnLogic;

	private readonly Mission _mission;

	private readonly NavalShipsLogic _shipsLogic;

	private readonly NavalAgentsLogic _agentsLogic;

	private readonly MBQueue<(Formation formation, IAgentOriginBase captainOrigin)> _pendingCaptainAssignments;

	private bool _updateShipsOnNextTick;

	private bool _troopSpawningActive;

	public BattleSideEnum BattleSide
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CBattleSide_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CBattleSide_003Ek__BackingField = value;
		}
	}

	public TeamSideEnum TeamSide
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CTeamSide_003Ek__BackingField;
		}
	}

	public bool TroopSpawningActive
	{
		get
		{
			return _troopSpawningActive;
		}
		private set
		{
			_troopSpawningActive = value;
			if (_agentsLogic.IsDeploymentFinished)
			{
				_agentsLogic.SetSpawnReinforcementsOnTick(_troopSpawningActive);
			}
		}
	}

	public bool IsInitialSpawnOver { get; private set; }

	public int TotalSpawnNumber { get; private set; }

	public NavalTeamSideSpawnContext(Mission mission, INavalMissionAgentSpawnLogic agentSpawnLogic, BattleSideEnum battleSide, TeamSideEnum teamSide, MBList<IAgentOriginBase> troopOrigins)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector();
		TotalSpawnNumber = ((List<IAgentOriginBase>)(object)troopOrigins).Count;
		_mission = mission;
		_agentSpawnLogic = agentSpawnLogic;
		BattleSide = battleSide;
		TeamSide = teamSide;
		_agentsLogic = _mission.GetMissionBehavior<NavalAgentsLogic>();
		_shipsLogic = _mission.GetMissionBehavior<NavalShipsLogic>();
		_agentsLogic.SetSpawnReinforcementsOnTick(teamSide, TroopSpawningActive);
		_agentsLogic.AddTroopOrigins(teamSide, troopOrigins);
		_agentsLogic.SetRestrictRecentlySwappedAgentTransfers(teamSide, value: true);
		_pendingCaptainAssignments = new MBQueue<(Formation, IAgentOriginBase)>();
	}

	public void OnDeploymentFinished()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_agentsLogic.SetRestrictRecentlySwappedAgentTransfers(TeamSide, value: false);
		_agentsLogic.SetSpawnReinforcementsOnTick(TroopSpawningActive);
	}

	public void OnDeploymentTick(float dt)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		_agentsLogic.ClearRecentlySwappedAgentsData(TeamSide);
		if (_updateShipsOnNextTick)
		{
			_updateShipsOnNextTick = false;
			_agentsLogic.AssignTroops(TeamSide);
			_agentsLogic.InitializeReinforcementTimers(TeamSide);
			ReassignPendingCaptains();
			CheckSpawnNextBatch();
			_agentsLogic.AssignAndTeleportCrewToShipMachines(TeamSide);
			if ((int)TeamSide == 0)
			{
				_agentSpawnLogic.OnPlayerShipsUpdated();
			}
		}
	}

	public void AllocateAndDeployInitialTroops(Mission mission)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		_agentsLogic.AutoComputeDesiredTroopCountsPerShip(TeamSide);
		if ((int)TeamSide == 0)
		{
			AllocateAndDeployInitialTroopsOfPlayerTeam();
		}
		else
		{
			AllocateAndDeployInitialTroopsOfTeam();
		}
		_agentsLogic.AssignAndTeleportCrewToShipMachines(TeamSide);
		IsInitialSpawnOver = true;
	}

	public void UpdateShips()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		_agentsLogic.AutoComputeDesiredTroopCountsPerShip(TeamSide);
		_agentsLogic.UnassignTroops(TeamSide);
		_updateShipsOnNextTick = true;
	}

	public void SetSpawnTroops(bool spawnTroops, bool enforceSpawn = false)
	{
		TroopSpawningActive = spawnTroops;
		if (enforceSpawn)
		{
			CheckSpawnNextBatch();
		}
	}

	public bool HasPendingCaptainAssignment(Formation formation)
	{
		return ((IEnumerable<(Formation, IAgentOriginBase)>)_pendingCaptainAssignments).Any<(Formation, IAgentOriginBase)>(((Formation formation, IAgentOriginBase captainOrigin) pca) => pca.formation == formation);
	}

	private void ReassignPendingCaptains()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		while (!Extensions.IsEmpty<(Formation, IAgentOriginBase)>((IEnumerable<(Formation, IAgentOriginBase)>)_pendingCaptainAssignments))
		{
			(Formation, IAgentOriginBase) tuple = ((Queue<(Formation, IAgentOriginBase)>)(object)_pendingCaptainAssignments).Dequeue();
			IAgentOriginBase item = tuple.Item2;
			var (formation, _) = tuple;
			if (_shipsLogic.GetShip(formation, out var ship))
			{
				if (!_agentsLogic.IsAgentOnAnyShip(item, out var foundAgent, out var onShip, TeamSide))
				{
					_agentsLogic.SpawnExistingHero(item, ship, out foundAgent);
					onShip = ship;
				}
				_agentsLogic.AssignCaptainToShipForDeploymentMode(foundAgent, ship, onShip);
			}
		}
	}

	public void OnBeforeShipRemoved(MissionShip ship)
	{
		if (!_shipsLogic.IsMissionEnding && _agentSpawnLogic.ReassignCaptainsOfRemovedShips && ship.Captain != null)
		{
			((Queue<(Formation, IAgentOriginBase)>)(object)_pendingCaptainAssignments).Enqueue((ship.Formation, ship.Captain.Origin));
		}
	}

	private void AllocateAndDeployInitialTroopsOfPlayerTeam()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		IAgentOriginBase troopOrigin = _agentsLogic.FindTroopOrigin(TeamSide, (IAgentOriginBase origin) => origin.Troop.IsPlayerCharacter);
		MissionShip missionShip = _shipsLogic.GetShipAssignment((TeamSideEnum)0, (FormationClass)0).MissionShip;
		_agentsLogic.AddReservedTroopToShip(troopOrigin, missionShip);
		_agentsLogic.AssignTroops(TeamSide);
		_agentsLogic.InitializeReinforcementTimers(TeamSide);
		CheckSpawnNextBatch();
		Agent val = ((IEnumerable<Agent>)_agentsLogic.GetActiveHeroesOfShip(missionShip)).FirstOrDefault((Agent agent) => agent.IsPlayerTroop);
		if (missionShip.Captain != val)
		{
			_agentsLogic.AssignCaptainToShipForDeploymentMode(val, missionShip, missionShip);
		}
	}

	private void AllocateAndDeployInitialTroopsOfTeam()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		_agentsLogic.AssignTroops(TeamSide);
		_agentsLogic.InitializeReinforcementTimers(TeamSide);
		CheckSpawnNextBatch();
	}

	private int CheckSpawnNextBatch()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		if (TroopSpawningActive)
		{
			num += _agentsLogic.SpawnNextBatch(TeamSide);
		}
		return num;
	}
}

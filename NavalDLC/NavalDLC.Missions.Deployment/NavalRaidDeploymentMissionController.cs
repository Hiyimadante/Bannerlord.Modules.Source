using System;
using System.Collections.Generic;
using NavalDLC.Missions.Handlers;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.ShipControl;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Deployment;

public class NavalRaidDeploymentMissionController : DeploymentMissionController
{
	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private NavalRaidMissionAgentSpawnLogic _navalRaidMissionLogic;

	private NavalRaidDeploymentHandler _navalRaidDeploymentHandler;

	public event Action PlayerShipsUpdated;

	public NavalRaidDeploymentMissionController(bool isPlayerAttacker)
		: base(isPlayerAttacker)
	{
	}

	public override void OnBehaviorInitialize()
	{
		((DeploymentMissionController)this).OnBehaviorInitialize();
		_navalRaidMissionLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalRaidMissionAgentSpawnLogic>();
		_navalAgentsLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalAgentsLogic>();
		_navalShipsLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalShipsLogic>();
		_navalRaidMissionLogic.PlayerShipsUpdated += OnPlayerShipsUpdated;
		_navalRaidDeploymentHandler = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalRaidDeploymentHandler>();
	}

	public override void OnRemoveBehavior()
	{
		((MissionBehavior)this).OnRemoveBehavior();
	}

	protected override void OnAfterStart()
	{
		for (int i = 0; i < 2; i++)
		{
			_navalRaidMissionLogic.SetSpawnTroops((BattleSideEnum)i, spawnTroops: false);
		}
		_navalRaidMissionLogic.SetDefenderReinforcementSpawnEnabled(value: false);
	}

	public override void OnMissionStateFinalized()
	{
		_navalRaidMissionLogic.PlayerShipsUpdated -= OnPlayerShipsUpdated;
	}

	public bool TryAssignShipToFormation(IShipOrigin shipOrigin, Formation formation, bool updateShips = true)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		ShipAssignment shipAssignment = null;
		bool flag = shipOrigin != null && _navalShipsLogic.FindAssignmentOfShipOrigin(shipOrigin, out shipAssignment);
		if (flag && shipAssignment.Formation == formation)
		{
			return false;
		}
		bool flag2 = _navalShipsLogic.IsAShipAssignedToFormation(formation);
		if (shipOrigin == null && !flag2)
		{
			return false;
		}
		if (flag2)
		{
			_navalShipsLogic.RemoveShip(formation);
		}
		if (shipOrigin != null)
		{
			if (flag)
			{
				_navalShipsLogic.TransferShipToFormation(shipOrigin, shipAssignment.Formation, formation);
			}
			else
			{
				_navalShipsLogic.SpawnShip(shipOrigin, MatrixFrame.Zero, formation.Team, formation, spawnAnchored: true, (FormationClass)8).SetController(ShipControllerType.None);
			}
		}
		if (updateShips)
		{
			UpdateShipsAttackerShips();
		}
		return true;
	}

	public void UpdateShipsAttackerShips()
	{
		_navalRaidMissionLogic.UpdateAttackerShips();
	}

	public bool IsShipAssignedToFormation(Formation formation)
	{
		return _navalShipsLogic.IsAShipAssignedToFormation(formation);
	}

	public bool TryAssignCaptainToFormation(IAgentOriginBase captainOrigin, Formation formation)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		_navalShipsLogic.GetShip(formation, out var ship);
		if (captainOrigin != null)
		{
			bool flag = _navalAgentsLogic.IsAgentOnAnyShip(captainOrigin, out var foundAgent, out var onShip, formation.Team.TeamSide);
			if (flag && formation.Captain == foundAgent)
			{
				return false;
			}
			if (!flag)
			{
				_navalAgentsLogic.SpawnExistingHero(captainOrigin, ship, out foundAgent);
			}
			_navalAgentsLogic.AssignCaptainToShipForDeploymentMode(foundAgent, ship, onShip);
			return true;
		}
		if (formation.Captain == null)
		{
			return false;
		}
		_navalAgentsLogic.UnassignCaptainOfShipForDeploymentMode(ship);
		return true;
	}

	public bool SetAttackerSideTroopClassFilter(TroopTraitsMask troopClassFilter, Formation targetFormation, bool updateShips)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		_navalShipsLogic.GetShip(targetFormation, out var ship);
		_navalAgentsLogic.SetTroopClassFilter(ship, troopClassFilter);
		if (updateShips)
		{
			UpdateShipsAttackerShips();
		}
		return updateShips;
	}

	public bool SetAttackerSideTroopTraitsFilter(TroopTraitsMask troopTraitsFilter, Formation targetFormation, bool updateShips)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		_navalShipsLogic.GetShip(targetFormation, out var ship);
		_navalAgentsLogic.SetTroopTraitsFilter(ship, troopTraitsFilter);
		if (updateShips)
		{
			UpdateShipsAttackerShips();
		}
		return updateShips;
	}

	public IReadOnlyCollection<IAgentOriginBase> GetAllPlayerTeamHeroes()
	{
		return _navalAgentsLogic.GetTeamHeroOrigins((TeamSideEnum)0);
	}

	public MBReadOnlyList<IShipOrigin> GetAllPlayerShips()
	{
		return _navalRaidMissionLogic.PlayerShips;
	}

	public MBReadOnlyList<Formation> GetUsableFormations()
	{
		return (MBReadOnlyList<Formation>)(object)((MissionBehavior)this).Mission.PlayerTeam.FormationsIncludingEmpty;
	}

	protected override void OnSetupTeamsOfSide(BattleSideEnum battleSide)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if ((int)battleSide == 1)
		{
			_navalRaidMissionLogic.DeployAttackerSideShips();
			_navalRaidMissionLogic.DeployAttackerSideTroops();
		}
		else
		{
			_navalRaidMissionLogic.DeployDefenderSideTroops();
		}
		_navalRaidMissionLogic.OnSideDeploymentOver(battleSide);
		((DeploymentMissionController)this).SetupAgentAIStatesForSide(battleSide);
	}

	protected override void OnSetupTeamsFinished()
	{
		((MissionBehavior)this).Mission.IsTeleportingAgents = true;
		_navalShipsLogic.SetTeleportShips(value: true);
		Team defender = ((MissionBehavior)this).Mission.Teams.Defender;
		if (defender.GeneralAgent != null)
		{
			WorldPosition val = default(WorldPosition);
			Vec2 val2 = default(Vec2);
			((MissionBehavior)this).Mission.GetFormationSpawnFrame(defender, (FormationClass)8, false, ref val, ref val2, true);
			if (((WorldPosition)(ref val)).GetNavMesh() != UIntPtr.Zero && ((WorldPosition)(ref val)).IsValid)
			{
				defender.GeneralAgent.TrySetFormationFrame(ref val, ref val2);
			}
		}
	}

	protected override void SetupAIOfEnemySide(BattleSideEnum enemySide)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		if ((int)enemySide == 1)
		{
			Team attackerTeam = ((MissionBehavior)this).Mission.AttackerTeam;
			((DeploymentMissionController)this).SetupAIOfEnemyTeam(attackerTeam);
		}
		else
		{
			Team defenderTeam = ((MissionBehavior)this).Mission.DefenderTeam;
			((DeploymentMissionController)this).SetupAIOfEnemyTeam(defenderTeam);
		}
	}

	protected override void SetupAIOfEnemyTeam(Team team)
	{
		foreach (Formation item in (List<Formation>)(object)team.FormationsIncludingEmpty)
		{
			if (item.CountOfUnits > 0)
			{
				item.SetControlledByAI(true, false);
			}
		}
		team.QuerySystem.Expire();
		((MissionBehavior)this).Mission.AllowAiTicking = true;
		((MissionBehavior)this).Mission.ForceTickOccasionally = true;
		team.ResetTactic();
		((MissionBehavior)this).Mission.AllowAiTicking = false;
		((MissionBehavior)this).Mission.ForceTickOccasionally = false;
	}

	protected override void BeforeDeploymentFinished()
	{
		((MissionBehavior)this).Mission.IsTeleportingAgents = false;
		_navalShipsLogic.SetTeleportShips(value: false);
	}

	protected override void AfterDeploymentFinished()
	{
		_navalRaidMissionLogic.SetDefenderReinforcementSpawnEnabled(value: true);
		((MissionBehavior)this).Mission.RemoveMissionBehavior((MissionBehavior)(object)_navalRaidDeploymentHandler);
	}

	internal void OnPlayerShipsUpdated()
	{
		PlayerShipsUpdated?.Invoke();
	}
}

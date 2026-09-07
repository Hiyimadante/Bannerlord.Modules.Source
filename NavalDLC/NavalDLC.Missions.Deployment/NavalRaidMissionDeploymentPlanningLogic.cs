using System;
using System.Collections.Generic;
using System.Linq;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Deployment;

public class NavalRaidMissionDeploymentPlanningLogic : MissionDeploymentPlanningLogic
{
	public const string DefenderPlayerSpawnEntityTag = "player_spawn_frame";

	private MBList<(Team team, NavalTeamDeploymentPlan plan)> _attackerSideTeamDeploymentPlans = new MBList<(Team, NavalTeamDeploymentPlan)>();

	private MBList<(Team team, DefaultTeamDeploymentPlan plan)> _defenderSideTeamDeploymentPlans = new MBList<(Team, DefaultTeamDeploymentPlan)>();

	private WorldFrame? _defenderSidePlayerSpawnFrame;

	private FormationSceneSpawnEntry[,] _formationSceneSpawnEntries;

	public override void Initialize()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((List<(Team, NavalTeamDeploymentPlan)>)(object)_attackerSideTeamDeploymentPlans).Clear();
		((List<(Team, DefaultTeamDeploymentPlan)>)(object)_defenderSideTeamDeploymentPlans).Clear();
		foreach (Team item3 in (List<Team>)(object)((MissionBehavior)this).Mission.Teams)
		{
			if ((int)item3.Side == 0)
			{
				DefaultTeamDeploymentPlan item = new DefaultTeamDeploymentPlan(((MissionBehavior)this).Mission, item3);
				((List<(Team, DefaultTeamDeploymentPlan)>)(object)_defenderSideTeamDeploymentPlans).Add((item3, item));
			}
			else
			{
				NavalTeamDeploymentPlan item2 = new NavalTeamDeploymentPlan(((MissionBehavior)this).Mission, item3);
				((List<(Team, NavalTeamDeploymentPlan)>)(object)_attackerSideTeamDeploymentPlans).Add((item3, item2));
			}
		}
	}

	public override void ClearDeploymentPlan(Team team)
	{
		GetTeamPlan<ITeamDeploymentPlan>(team).ClearPlan(false);
	}

	public override bool SupportsReinforcements()
	{
		return true;
	}

	public override bool SupportsNavmesh(Team team)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)team.Side == 0)
		{
			return true;
		}
		return false;
	}

	public override void UpdateReinforcementPlan(Team team)
	{
		GetTeamPlan<DefaultTeamDeploymentPlan>(team).UpdateReinforcementPlans();
	}

	public override bool HasPlayerSpawnFrame(BattleSideEnum battleSide)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if ((int)battleSide == 0)
		{
			return _defenderSidePlayerSpawnFrame.HasValue;
		}
		return false;
	}

	public override bool GetPlayerSpawnFrame(BattleSideEnum battleSide, out WorldPosition position, out Vec2 direction)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		if ((int)battleSide == 0 && _defenderSidePlayerSpawnFrame.HasValue)
		{
			Scene scene = Mission.Current.Scene;
			UIntPtr zero = UIntPtr.Zero;
			WorldFrame value = _defenderSidePlayerSpawnFrame.Value;
			position = new WorldPosition(scene, zero, ((WorldPosition)(ref value.Origin)).GetGroundVec3(), false);
			value = _defenderSidePlayerSpawnFrame.Value;
			Vec2 asVec = ((Vec3)(ref value.Rotation.f)).AsVec2;
			direction = ((Vec2)(ref asVec)).Normalized();
			return true;
		}
		position = WorldPosition.Invalid;
		direction = Vec2.Invalid;
		return false;
	}

	public void ClearAddedShips(Team team)
	{
		GetTeamPlan<NavalTeamDeploymentPlan>(team).ClearAddedShips();
	}

	public void ClearAddedTroops(Team team)
	{
		GetTeamPlan<DefaultTeamDeploymentPlan>(team).ClearAddedTroops(false);
	}

	public override void ClearAll()
	{
		foreach (var item in (List<(Team, DefaultTeamDeploymentPlan)>)(object)_defenderSideTeamDeploymentPlans)
		{
			item.Item2.ClearAddedTroops(false);
			item.Item2.ClearPlan(false);
		}
		foreach (var item2 in (List<(Team, NavalTeamDeploymentPlan)>)(object)_attackerSideTeamDeploymentPlans)
		{
			item2.Item2.ClearAddedShips();
			item2.Item2.ClearPlan();
		}
	}

	public void AddShip(Team team, FormationClass formationIndex, IShipOrigin shipOrigin)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		GetTeamPlan<NavalTeamDeploymentPlan>(team).AddShip(formationIndex, shipOrigin);
	}

	public bool RemoveShip(Team team, FormationClass formationIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetTeamPlan<NavalTeamDeploymentPlan>(team).RemoveShip(formationIndex);
	}

	public void AddTroops(Team team, FormationClass formationClass, int footTroopCount, int mountedTroopCount = 0, bool isReinforcement = false)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		_ = team.Side;
		GetTeamPlan<DefaultTeamDeploymentPlan>(team).AddTroops(formationClass, footTroopCount, mountedTroopCount, isReinforcement);
	}

	public void SetSpawnWithHorses(Team team, bool spawnWithHorses)
	{
		GetTeamPlan<DefaultTeamDeploymentPlan>(team).SetSpawnWithHorses(spawnWithHorses);
	}

	public override void MakeDeploymentPlan(Team team, float spawnPathOffset = 0f, float targetOffset = 0f)
	{
		if (!((MissionDeploymentPlanningLogic)this).IsPlanMade(team))
		{
			MakeDeploymentPlanAux(team, isReinforcement: false);
			bool flag = default(bool);
			if (((MissionDeploymentPlanningLogic)this).IsPlanMade(team, ref flag))
			{
				((MissionBehavior)this).Mission.OnDeploymentPlanMade(team, flag);
			}
		}
	}

	public void MakeReinforcementDeploymentPlan(Team team)
	{
		if (!IsReinforcementPlanMade(team))
		{
			MakeDeploymentPlanAux(team, isReinforcement: true);
		}
	}

	public override bool RemakeDeploymentPlan(Team team)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected I4, but got Unknown
		((MissionDeploymentPlanningLogic)this).IsPlanMade(team);
		if ((int)team.Side == 0)
		{
			(int, int)[] array = new(int, int)[11];
			foreach (Agent item in ((IEnumerable<Agent>)((MissionBehavior)this).Mission.AllAgents).Where((Agent agent) => agent.IsHuman && agent.Team != null && agent.Team == team && agent.Formation != null))
			{
				int num = (int)item.Formation.FormationIndex;
				(int, int) tuple = array[num];
				array[num] = (item.HasMount ? (tuple.Item1, tuple.Item2 + 1) : (tuple.Item1 + 1, tuple.Item2));
			}
			if (!IsInitialPlanSuitableForFormations(team, array))
			{
				ClearAddedTroops(team);
				((MissionDeploymentPlanningLogic)this).ClearDeploymentPlan(team);
				for (int num2 = 0; num2 < 11; num2++)
				{
					var (num3, num4) = array[num2];
					if (num3 + num4 > 0)
					{
						AddTroops(team, (FormationClass)num2, num3, num4);
					}
				}
				((MissionDeploymentPlanningLogic)this).MakeDeploymentPlan(team, 0f, 0f);
				return ((MissionDeploymentPlanningLogic)this).IsPlanMade(team);
			}
			return false;
		}
		ClearAddedShips(team);
		((MissionDeploymentPlanningLogic)this).ClearDeploymentPlan(team);
		NavalShipsLogic missionBehavior = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalShipsLogic>();
		for (int num5 = 0; num5 < 11; num5++)
		{
			FormationClass formationIndex = (FormationClass)num5;
			ShipAssignment shipAssignment = missionBehavior.GetShipAssignment(team.TeamSide, formationIndex);
			if (shipAssignment.IsSet)
			{
				AddShip(team, formationIndex, shipAssignment.ShipOrigin);
			}
		}
		((MissionDeploymentPlanningLogic)this).MakeDeploymentPlan(team, 0f, 0f);
		return ((MissionDeploymentPlanningLogic)this).IsPlanMade(team);
	}

	public override bool IsPositionInsideDeploymentBoundaries(Team team, in Vec2 position)
	{
		ITeamDeploymentPlan teamPlan = GetTeamPlan<ITeamDeploymentPlan>(team);
		(string, MBList<Vec2>) tuple = default((string, MBList<Vec2>));
		if (teamPlan.HasDeploymentBoundaries())
		{
			return teamPlan.IsPositionInsideDeploymentBoundaries(ref position, ref tuple);
		}
		Debug.FailedAssert("Cannot check if position is within deployment boundaries as requested team " + team.TeamIndex + " does not have deployment boundaries.", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\Deployment\\NavalRaidMissionDeploymentPlanningLogic.cs", "IsPositionInsideDeploymentBoundaries", 278);
		return false;
	}

	public override Vec2 GetClosestDeploymentBoundaryPosition(Team team, in Vec2 position)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		ITeamDeploymentPlan teamPlan = GetTeamPlan<ITeamDeploymentPlan>(team);
		if (teamPlan.HasDeploymentBoundaries())
		{
			return teamPlan.GetClosestDeploymentBoundaryPosition(ref position);
		}
		Debug.FailedAssert("Cannot retrieve closest deployment boundary position as requested team (index: " + team.TeamIndex + ") does not have deployment boundaries.", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\Deployment\\NavalRaidMissionDeploymentPlanningLogic.cs", "GetClosestDeploymentBoundaryPosition", 290);
		return position;
	}

	public override void ProjectPositionToDeploymentBoundaries(Team team, ref WorldPosition endPosition)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (!((MissionDeploymentPlanningLogic)this).HasDeploymentBoundaries(team))
		{
			return;
		}
		Vec2 asVec = ((WorldPosition)(ref endPosition)).AsVec2;
		if (!((MissionDeploymentPlanningLogic)this).IsPositionInsideDeploymentBoundaries(team, ref asVec))
		{
			MatrixFrame deploymentFrame = ((MissionDeploymentPlanningLogic)this).GetDeploymentFrame(team);
			WorldPosition val = default(WorldPosition);
			((WorldPosition)(ref val))._002Ector(Mission.Current.Scene, UIntPtr.Zero, deploymentFrame.origin, false);
			WorldPosition val2 = default(WorldPosition);
			if (((MissionDeploymentPlanningLogic)this).GetPathDeploymentBoundaryIntersection(team, ref val, ref endPosition, ref val2))
			{
				endPosition = val2;
			}
		}
	}

	public override bool GetPathDeploymentBoundaryIntersection(Team team, in WorldPosition startPosition, in WorldPosition endPosition, out WorldPosition intersection)
	{
		return GetTeamPlan<DefaultTeamDeploymentPlan>(team).GetPathDeploymentBoundaryIntersection(ref startPosition, ref endPosition, ref intersection);
	}

	public override float GetSpawnPathOffset(Team team)
	{
		return 0f;
	}

	public override MatrixFrame GetZoomFocusFrame(Team team)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if ((int)team.Side == 0)
		{
			return ((MissionDeploymentPlanningLogic)this).GetDeploymentFrame(team);
		}
		NavalTeamDeploymentPlan teamPlan = GetTeamPlan<NavalTeamDeploymentPlan>(team);
		MatrixFrame deploymentFrame = teamPlan.GetDeploymentFrame();
		Vec3 val = Vec3.Zero;
		int num = 0;
		for (int i = 0; i < 11; i++)
		{
			IFormationDeploymentPlan formationPlan = teamPlan.GetFormationPlan((FormationClass)i);
			if (formationPlan.HasFrame())
			{
				MatrixFrame frame = formationPlan.GetFrame();
				val += frame.origin;
				num++;
			}
		}
		val /= (float)num;
		deploymentFrame.origin = val;
		return deploymentFrame;
	}

	public override float GetZoomOffset(Team team, float fovAngle)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		ITeamDeploymentPlan teamPlan = GetTeamPlan<ITeamDeploymentPlan>(team);
		MatrixFrame deploymentFrame = teamPlan.GetDeploymentFrame();
		float num = float.MinValue;
		for (int i = 0; i < 11; i++)
		{
			IFormationDeploymentPlan formationPlan = teamPlan.GetFormationPlan((FormationClass)i, false);
			if (formationPlan.HasFrame())
			{
				MatrixFrame frame = formationPlan.GetFrame();
				Vec2 asVec = ((Vec3)(ref frame.origin)).AsVec2;
				float num2 = ((Vec2)(ref asVec)).DistanceSquared(((Vec3)(ref deploymentFrame.origin)).AsVec2);
				num = MathF.Max(num, num2);
			}
		}
		return (MathF.Sqrt(num) + 20f) / MathF.Max(MathF.Tan(fovAngle / 2f), 0.01f);
	}

	public override IFormationDeploymentPlan GetFormationPlan(Team team, FormationClass fClass, bool isReinforcement = false)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		ITeamDeploymentPlan teamPlan = GetTeamPlan<ITeamDeploymentPlan>(team);
		if (team.IsAttacker)
		{
			return teamPlan.GetFormationPlan(fClass, false);
		}
		return teamPlan.GetFormationPlan(fClass, isReinforcement);
	}

	public override bool IsPlanMade(Team team)
	{
		ITeamDeploymentPlan teamPlanAux = GetTeamPlanAux(team);
		if (teamPlanAux != null)
		{
			return teamPlanAux.IsPlanMade(false);
		}
		return false;
	}

	public bool IsReinforcementPlanMade(Team team)
	{
		ITeamDeploymentPlan teamPlanAux = GetTeamPlanAux(team);
		if (teamPlanAux != null)
		{
			return teamPlanAux.IsPlanMade(true);
		}
		return false;
	}

	public override bool IsPlanMade(Team team, out bool isFirstPlan)
	{
		isFirstPlan = false;
		ITeamDeploymentPlan teamPlanAux = GetTeamPlanAux(team);
		if (teamPlanAux != null && teamPlanAux.IsPlanMade(false))
		{
			isFirstPlan = teamPlanAux.IsFirstPlan(false);
			return true;
		}
		return false;
	}

	public override bool HasDeploymentBoundaries(Team team)
	{
		ITeamDeploymentPlan teamPlanAux = GetTeamPlanAux(team);
		if (teamPlanAux != null)
		{
			return teamPlanAux.HasDeploymentBoundaries();
		}
		return false;
	}

	public override MatrixFrame GetDeploymentFrame(Team team)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetTeamPlan<ITeamDeploymentPlan>(team).GetDeploymentFrame();
	}

	public float GetTargetOffset(Team team)
	{
		return GetTeamPlan<ITeamDeploymentPlan>(team).GetTargetOffset(false);
	}

	public override MBReadOnlyList<(string, MBList<Vec2>)> GetDeploymentBoundaries(Team team)
	{
		return GetTeamPlan<ITeamDeploymentPlan>(team).GetDeploymentBoundaries();
	}

	public virtual bool GetMeanBoundaryPosition(Team team, out Vec2 meanPosition, int boundaryIndex = 0)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		NavalTeamDeploymentPlan teamPlan = GetTeamPlan<NavalTeamDeploymentPlan>(team);
		if (teamPlan != null && teamPlan.HasDeploymentBoundaries())
		{
			meanPosition = teamPlan.GetMeanBoundaryPosition(boundaryIndex);
			return true;
		}
		meanPosition = Vec2.Invalid;
		return false;
	}

	private T GetTeamPlan<T>(Team team) where T : ITeamDeploymentPlan
	{
		ITeamDeploymentPlan teamPlanAux;
		if ((teamPlanAux = GetTeamPlanAux(team)) is T)
		{
			return (T)(object)teamPlanAux;
		}
		Debug.FailedAssert("Unable to cast team plan to given type", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\Deployment\\NavalRaidMissionDeploymentPlanningLogic.cs", "GetTeamPlan", 514);
		return default(T);
	}

	private ITeamDeploymentPlan GetTeamPlanAux(Team team)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		if ((int)team.Side == 0)
		{
			return (ITeamDeploymentPlan)(object)((IEnumerable<(Team, DefaultTeamDeploymentPlan)>)_defenderSideTeamDeploymentPlans).FirstOrDefault<(Team, DefaultTeamDeploymentPlan)>(((Team team, DefaultTeamDeploymentPlan plan) t) => t.team == team).Item2;
		}
		if ((int)team.Side == 1)
		{
			return (ITeamDeploymentPlan)(object)((IEnumerable<(Team, NavalTeamDeploymentPlan)>)_attackerSideTeamDeploymentPlans).FirstOrDefault<(Team, NavalTeamDeploymentPlan)>(((Team team, NavalTeamDeploymentPlan plan) t) => t.team == team).Item2;
		}
		return null;
	}

	private void MakeDeploymentPlanAux(Team team, bool isReinforcement)
	{
		ITeamDeploymentPlan teamPlan = GetTeamPlan<ITeamDeploymentPlan>(team);
		if (teamPlan.IsPlanMade(isReinforcement))
		{
			teamPlan.ClearPlan(false);
		}
		if (_formationSceneSpawnEntries == null)
		{
			ReadSpawnEntitiesFromScene();
		}
		teamPlan.MakeDeploymentPlan(0f, 0f, _formationSceneSpawnEntries, isReinforcement);
	}

	private void ReadSpawnEntitiesFromScene()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected I4, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		_defenderSidePlayerSpawnFrame = null;
		GameEntity val = ((MissionBehavior)this).Mission.Scene.FindEntityWithTag("player_spawn_frame");
		if (val != (GameEntity)null)
		{
			MatrixFrame globalFrame = val.GetGlobalFrame();
			WorldPosition val2 = default(WorldPosition);
			((WorldPosition)(ref val2))._002Ector(((MissionBehavior)this).Mission.Scene, UIntPtr.Zero, globalFrame.origin, false);
			_defenderSidePlayerSpawnFrame = new WorldFrame(globalFrame.rotation, val2);
		}
		_formationSceneSpawnEntries = new FormationSceneSpawnEntry[2, 11];
		Scene scene = ((MissionBehavior)this).Mission.Scene;
		for (int i = 0; i < 2; i++)
		{
			string text = ((i == 1) ? "attacker_" : "defender_");
			for (int j = 0; j < 11; j++)
			{
				FormationClass val3 = (FormationClass)j;
				string text2 = text + FormationClassExtensions.GetName(val3).ToLower();
				string text3 = text2 + "_reinforcement";
				WeakGameEntity val4 = scene.FindWeakEntityWithTag(text2);
				WeakGameEntity? val5 = null;
				if (val4 == (GameEntity)null)
				{
					FormationClass val6 = FormationClassExtensions.FallbackClass(val3);
					int num = (int)val6;
					FormationSceneSpawnEntry val7 = _formationSceneSpawnEntries[i, num];
					if (val7.SpawnEntity != (GameEntity)null)
					{
						val4 = val7.SpawnEntity.WeakEntity;
						val5 = val7.ReinforcementSpawnEntity.WeakEntity;
					}
					else
					{
						text2 = text + FormationClassExtensions.GetName(val6).ToLower();
						text3 = text2 + "_reinforcement";
						val4 = scene.FindWeakEntityWithTag(text2);
						val5 = scene.FindWeakEntityWithTag(text3);
					}
					val3 = (FormationClass)((!(val4 != (GameEntity)null)) ? 10 : ((int)val6));
				}
				else
				{
					val5 = scene.FindWeakEntityWithTag(text3);
				}
				GameEntity val8 = null;
				GameEntity val9 = null;
				if (((WeakGameEntity)(ref val4)).IsValid)
				{
					val8 = GameEntity.CreateFromWeakEntity(val4);
					if (val5.HasValue)
					{
						WeakGameEntity value = val5.Value;
						if (((WeakGameEntity)(ref value)).IsValid)
						{
							val9 = GameEntity.CreateFromWeakEntity(val5.Value);
						}
					}
				}
				if (val9 == (GameEntity)null)
				{
					val9 = val8;
				}
				_formationSceneSpawnEntries[i, j] = new FormationSceneSpawnEntry(val3, val8, val9);
			}
		}
	}

	private bool IsInitialPlanSuitableForFormations(Team team, (int footTroopCount, int mountedTroopCount)[] troopDataPerFormationClass)
	{
		return GetTeamPlan<DefaultTeamDeploymentPlan>(team).IsInitialPlanSuitableForFormations(troopDataPerFormationClass);
	}
}

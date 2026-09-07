using System.Collections.Generic;
using System.Linq;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Deployment;

public class NavalMissionDeploymentPlanningLogic : MissionDeploymentPlanningLogic
{
	private Mission _mission;

	private MBList<(Team team, NavalTeamDeploymentPlan plan)> _teamDeploymentPlans = new MBList<(Team, NavalTeamDeploymentPlan)>();

	public NavalMissionDeploymentPlanningLogic(Mission mission)
	{
		_mission = mission;
	}

	public override void Initialize()
	{
		((List<(Team, NavalTeamDeploymentPlan)>)(object)_teamDeploymentPlans).Clear();
		foreach (Team item2 in (List<Team>)(object)_mission.Teams)
		{
			NavalTeamDeploymentPlan item = new NavalTeamDeploymentPlan(_mission, item2);
			((List<(Team, NavalTeamDeploymentPlan)>)(object)_teamDeploymentPlans).Add((item2, item));
		}
	}

	public override void ClearDeploymentPlan(Team team)
	{
		GetTeamPlan(team).ClearPlan();
	}

	public override bool SupportsReinforcements()
	{
		return false;
	}

	public override void UpdateReinforcementPlan(Team team)
	{
		Debug.FailedAssert("Naval mission deployment planning logic does not support reinforcements plans that can be updated", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\Deployment\\NavalMissionDeploymentPlanningLogic.cs", "UpdateReinforcementPlan", 43);
	}

	public override bool SupportsNavmesh(Team team)
	{
		return false;
	}

	public override bool HasPlayerSpawnFrame(BattleSideEnum battleSide)
	{
		return false;
	}

	public override bool GetPlayerSpawnFrame(BattleSideEnum battleSide, out WorldPosition position, out Vec2 direction)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		position = WorldPosition.Invalid;
		direction = Vec2.Invalid;
		return false;
	}

	public void ClearAddedShips(Team team)
	{
		GetTeamPlan(team).ClearAddedShips();
	}

	public override void ClearAll()
	{
		foreach (var item in (List<(Team, NavalTeamDeploymentPlan)>)(object)_teamDeploymentPlans)
		{
			item.Item2.ClearAddedShips();
			item.Item2.ClearPlan();
		}
	}

	public void AddShip(Team team, FormationClass formationIndex, IShipOrigin shipOrigin)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		GetTeamPlan(team).AddShip(formationIndex, shipOrigin);
	}

	public bool RemoveShip(Team team, FormationClass formationIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetTeamPlan(team).RemoveShip(formationIndex);
	}

	public override void MakeDeploymentPlan(Team team, float spawnPathOffset = 0f, float targetOffset = 0f)
	{
		NavalTeamDeploymentPlan teamPlan = GetTeamPlan(team);
		if (!((MissionDeploymentPlanningLogic)this).IsPlanMade(team))
		{
			teamPlan.MakeDeploymentPlan(spawnPathOffset, targetOffset);
			bool flag = default(bool);
			if (((MissionDeploymentPlanningLogic)this).IsPlanMade(team, ref flag))
			{
				_mission.OnDeploymentPlanMade(team, flag);
			}
		}
	}

	public override bool RemakeDeploymentPlan(Team team)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		((MissionDeploymentPlanningLogic)this).IsPlanMade(team);
		float spawnPathOffset = ((MissionDeploymentPlanningLogic)this).GetSpawnPathOffset(team);
		float targetOffset = GetTargetOffset(team);
		ClearAddedShips(team);
		((MissionDeploymentPlanningLogic)this).ClearDeploymentPlan(team);
		NavalShipsLogic missionBehavior = _mission.GetMissionBehavior<NavalShipsLogic>();
		for (int i = 0; i < 11; i++)
		{
			FormationClass formationIndex = (FormationClass)i;
			ShipAssignment shipAssignment = missionBehavior.GetShipAssignment(team.TeamSide, formationIndex);
			if (shipAssignment.IsSet)
			{
				AddShip(team, formationIndex, shipAssignment.ShipOrigin);
			}
		}
		((MissionDeploymentPlanningLogic)this).MakeDeploymentPlan(team, spawnPathOffset, targetOffset);
		return ((MissionDeploymentPlanningLogic)this).IsPlanMade(team);
	}

	public override bool IsPositionInsideDeploymentBoundaries(Team team, in Vec2 position)
	{
		(string, MBList<Vec2>) containingBoundaryTuple;
		return GetTeamPlan(team).IsPositionInsideDeploymentBoundaries(in position, out containingBoundaryTuple);
	}

	public override Vec2 GetClosestDeploymentBoundaryPosition(Team team, in Vec2 position)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return GetTeamPlan(team).GetClosestDeploymentBoundaryPosition(in position);
	}

	public override void ProjectPositionToDeploymentBoundaries(Team team, ref WorldPosition position)
	{
		Debug.FailedAssert("Naval deployment plan does not support projection of position to deployment boundaries as it does not support a navmesh", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\Deployment\\NavalMissionDeploymentPlanningLogic.cs", "ProjectPositionToDeploymentBoundaries", 161);
	}

	public override bool GetPathDeploymentBoundaryIntersection(Team team, in WorldPosition startPosition, in WorldPosition endPosition, out WorldPosition intersection)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		Debug.FailedAssert("Naval deployment plan does not support finding boundary intersection between positions as it does not support a navmesh", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\Deployment\\NavalMissionDeploymentPlanningLogic.cs", "GetPathDeploymentBoundaryIntersection", 166);
		intersection = WorldPosition.Invalid;
		return false;
	}

	public override float GetSpawnPathOffset(Team team)
	{
		return GetTeamPlan(team).GetSpawnPathOffset();
	}

	public override MatrixFrame GetZoomFocusFrame(Team team)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		NavalTeamDeploymentPlan teamPlan = GetTeamPlan(team);
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
		NavalTeamDeploymentPlan teamPlan = GetTeamPlan(team);
		MatrixFrame deploymentFrame = teamPlan.GetDeploymentFrame();
		float num = float.MinValue;
		for (int i = 0; i < 11; i++)
		{
			IFormationDeploymentPlan formationPlan = teamPlan.GetFormationPlan((FormationClass)i);
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetTeamPlan(team).GetFormationPlan(fClass);
	}

	public override bool IsPlanMade(Team team)
	{
		return GetTeamPlanAux(team)?.IsPlanMade() ?? false;
	}

	public override bool IsPlanMade(Team team, out bool isFirstPlan)
	{
		isFirstPlan = false;
		NavalTeamDeploymentPlan teamPlanAux = GetTeamPlanAux(team);
		if (teamPlanAux != null && teamPlanAux.IsPlanMade())
		{
			isFirstPlan = teamPlanAux.IsFirstPlan();
			return true;
		}
		return false;
	}

	public override bool HasDeploymentBoundaries(Team team)
	{
		return GetTeamPlanAux(team)?.HasDeploymentBoundaries() ?? false;
	}

	public override MatrixFrame GetDeploymentFrame(Team team)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return GetTeamPlan(team).GetDeploymentFrame();
	}

	public float GetTargetOffset(Team team)
	{
		return GetTeamPlan(team).GetTargetOffset();
	}

	public override MBReadOnlyList<(string, MBList<Vec2>)> GetDeploymentBoundaries(Team team)
	{
		return GetTeamPlan(team).GetDeploymentBoundaries();
	}

	public virtual bool GetMeanBoundaryPosition(Team team, out Vec2 meanPosition, int boundaryIndex = 0)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		NavalTeamDeploymentPlan teamPlan = GetTeamPlan(team);
		if (teamPlan.HasDeploymentBoundaries())
		{
			meanPosition = teamPlan.GetMeanBoundaryPosition(boundaryIndex);
			return true;
		}
		meanPosition = Vec2.Invalid;
		return false;
	}

	private NavalTeamDeploymentPlan GetTeamPlan(Team team)
	{
		return GetTeamPlanAux(team);
	}

	private NavalTeamDeploymentPlan GetTeamPlanAux(Team team)
	{
		return ((IEnumerable<(Team, NavalTeamDeploymentPlan)>)_teamDeploymentPlans).FirstOrDefault<(Team, NavalTeamDeploymentPlan)>(((Team team, NavalTeamDeploymentPlan plan) tdp) => tdp.team == team).Item2;
	}
}

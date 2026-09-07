using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Deployment;

public class NavalDeploymentPlan
{
	public const float HorizontalShipGap = 20f;

	public readonly Team Team;

	private readonly Mission _mission;

	private int _planCount;

	private bool _isRiverPlan;

	private bool _isRaidPlan;

	private Vec3 _meanPosition;

	private readonly NavalFormationDeploymentPlan[] _formationPlans;

	public bool IsRiverPlan => _isRiverPlan;

	public bool IsRaidPlan => _isRaidPlan;

	public int PlanCount => _planCount;

	public bool IsPlanMade { get; private set; }

	public float SpawnPathOffset { get; private set; }

	public float TargetOffset { get; private set; }

	public int TroopCount
	{
		get
		{
			int num = 0;
			NavalFormationDeploymentPlan[] formationPlans = _formationPlans;
			foreach (NavalFormationDeploymentPlan navalFormationDeploymentPlan in formationPlans)
			{
				num += navalFormationDeploymentPlan.PlannedTroopCount;
			}
			return num;
		}
	}

	public int ShipCount
	{
		get
		{
			int num = 0;
			NavalFormationDeploymentPlan[] formationPlans = _formationPlans;
			for (int i = 0; i < formationPlans.Length; i++)
			{
				if (formationPlans[i].HasShipObject)
				{
					num++;
				}
			}
			return num;
		}
	}

	public Vec3 MeanPosition
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _meanPosition;
		}
	}

	public static NavalDeploymentPlan CreatePlan(Mission mission, Team team, bool isRiverPlan, bool isRaidPlan)
	{
		return new NavalDeploymentPlan(mission, team, isRiverPlan, isRaidPlan);
	}

	private NavalDeploymentPlan(Mission mission, Team team, bool isRiverPlan, bool isRaidPlan)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector();
		_mission = mission;
		_planCount = 0;
		Team = team;
		_formationPlans = new NavalFormationDeploymentPlan[11];
		_isRiverPlan = isRiverPlan;
		_isRaidPlan = isRaidPlan;
		IsPlanMade = false;
		SpawnPathOffset = 0f;
		for (int i = 0; i < _formationPlans.Length; i++)
		{
			FormationClass fClass = (FormationClass)i;
			_formationPlans[i] = new NavalFormationDeploymentPlan(fClass, _mission);
		}
		ClearAddedShips();
		ClearPlan();
	}

	public void MakeDeploymentPlan(float spawnPathOffset, float targetOffset, FormationSceneSpawnEntry[,] formationSceneSpawnEntries = null)
	{
		SpawnPathOffset = spawnPathOffset;
		TargetOffset = targetOffset;
		if (_mission.HasSpawnPath)
		{
			PlanNavalBattleDeploymentFromSpawnPath(spawnPathOffset, targetOffset);
		}
		else
		{
			PlanNavalBattleDeploymentFromSceneData(formationSceneSpawnEntries);
		}
		ComputeMeanPosition();
	}

	public void ClearPlan()
	{
		NavalFormationDeploymentPlan[] formationPlans = _formationPlans;
		for (int i = 0; i < formationPlans.Length; i++)
		{
			formationPlans[i].Clear();
		}
		IsPlanMade = false;
	}

	public void ClearAddedShips()
	{
		NavalFormationDeploymentPlan[] formationPlans = _formationPlans;
		for (int i = 0; i < formationPlans.Length; i++)
		{
			formationPlans[i].SetShipOrigin(null);
		}
	}

	public void AddShip(FormationClass formationClass, IShipOrigin shipOrigin)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Expected I4, but got Unknown
		int num = (int)formationClass;
		_formationPlans[num].SetShipOrigin(shipOrigin);
	}

	public bool RemoveShip(FormationClass formationIndex)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		NavalFormationDeploymentPlan navalFormationDeploymentPlan = _formationPlans[formationIndex];
		if (navalFormationDeploymentPlan.ShipObject != null)
		{
			navalFormationDeploymentPlan.SetShipOrigin(null);
			return true;
		}
		return false;
	}

	public NavalFormationDeploymentPlan GetFormationPlan(FormationClass fClass)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return _formationPlans[fClass];
	}

	public bool GetFormationDeploymentFrame(FormationClass fClass, out MatrixFrame frame)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		NavalFormationDeploymentPlan formationPlan = GetFormationPlan(fClass);
		if (formationPlan.HasFrame())
		{
			frame = formationPlan.GetFrame();
			return true;
		}
		frame = MatrixFrame.Identity;
		return false;
	}

	private void PlanNavalBattleDeploymentFromSpawnPath(float pathOffset, float targetOffset)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Vec2 deployPosition = default(Vec2);
		Vec2 deployDirection = default(Vec2);
		_mission.GetInitialSpawnPathData(Team.Side).GetSpawnPathFrameFacingTarget(pathOffset, targetOffset, _isRiverPlan, ref deployPosition, ref deployDirection, false, 0.2f);
		DeployShips(deployPosition, deployDirection);
		IsPlanMade = true;
		_planCount++;
	}

	private void PlanNavalBattleDeploymentFromSceneData(FormationSceneSpawnEntry[,] formationSceneSpawnEntries)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected I4, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (formationSceneSpawnEntries == null || formationSceneSpawnEntries.GetLength(0) != 2 || formationSceneSpawnEntries.GetLength(1) != _formationPlans.Length)
		{
			return;
		}
		int num = (int)Team.Side;
		for (int i = 0; i < _formationPlans.Length; i++)
		{
			NavalFormationDeploymentPlan navalFormationDeploymentPlan = _formationPlans[i];
			if (navalFormationDeploymentPlan.HasShipObject)
			{
				MatrixFrame globalFrame = formationSceneSpawnEntries[num, i].SpawnEntity.GetGlobalFrame();
				Vec2 deployPosition = ((Vec3)(ref globalFrame.origin)).AsVec2;
				Vec2 deployDirection = ((Vec3)(ref globalFrame.rotation.f)).AsVec2;
				deployDirection = ((Vec2)(ref deployDirection)).Normalized();
				navalFormationDeploymentPlan.SetFrame(in deployPosition, in deployDirection);
			}
		}
		IsPlanMade = true;
		_planCount++;
	}

	private void DeployShips(Vec2 deployPosition, Vec2 deployDirection)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		List<(int, NavalFormationDeploymentPlan)> list = new List<(int, NavalFormationDeploymentPlan)>();
		for (int i = 0; i < _formationPlans.Count(); i++)
		{
			NavalFormationDeploymentPlan navalFormationDeploymentPlan = _formationPlans[i];
			if (navalFormationDeploymentPlan.HasShipObject)
			{
				int totalCrewCapacity = navalFormationDeploymentPlan.ShipOrigin.TotalCrewCapacity;
				list.Add((totalCrewCapacity, navalFormationDeploymentPlan));
			}
		}
		list.Sort(((int crewCapacity, NavalFormationDeploymentPlan plan) x, (int crewCapacity, NavalFormationDeploymentPlan plan) y) => y.crewCapacity.CompareTo(x.crewCapacity));
		float num = 0f;
		float num2 = 0f;
		Vec2 val = ((Vec2)(ref deployDirection)).LeftVec();
		Vec2 val2 = ((Vec2)(ref val)).Normalized();
		Vec2 val3 = -val2;
		int num3 = 0;
		if (list.Count % 2 != 0)
		{
			NavalFormationDeploymentPlan item = list[num3].Item2;
			item.SetFrame(in deployPosition, in deployDirection);
			float num4 = item.ShipObject.DeploymentArea.x / 2f;
			num += num4;
			num2 += num4;
			num3++;
		}
		for (; num3 < list.Count; num3++)
		{
			NavalFormationDeploymentPlan item2 = list[num3].Item2;
			float num5 = item2.ShipObject.DeploymentArea.x / 2f;
			if (num3 % 2 == 0)
			{
				num2 += 20f + num5;
				item2.SetFrame(deployPosition + val3 * num2, in deployDirection);
				num2 += num5;
			}
			else
			{
				num += 20f + num5;
				item2.SetFrame(deployPosition + val2 * num, in deployDirection);
				num += num5;
			}
		}
		list.Clear();
	}

	private void ComputeMeanPosition()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		_meanPosition = Vec3.Zero;
		Vec2 val = Vec2.Zero;
		int num = 0;
		NavalFormationDeploymentPlan[] formationPlans = _formationPlans;
		foreach (NavalFormationDeploymentPlan navalFormationDeploymentPlan in formationPlans)
		{
			if (navalFormationDeploymentPlan.HasFrame())
			{
				Vec2 val2 = val;
				Vec3 position = navalFormationDeploymentPlan.GetPosition();
				val = val2 + ((Vec3)(ref position)).AsVec2;
				num++;
			}
		}
		if (num > 0)
		{
			((Vec2)(ref val))._002Ector(((Vec2)(ref val)).X / (float)num, ((Vec2)(ref val)).Y / (float)num);
			_meanPosition = ((Vec2)(ref val)).ToVec3(0f);
		}
	}
}

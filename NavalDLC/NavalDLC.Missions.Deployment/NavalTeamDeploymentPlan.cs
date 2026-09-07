using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Deployment;

public class NavalTeamDeploymentPlan : ITeamDeploymentPlan
{
	public const float DeployZoneMinimumWidth = 400f;

	public const float RiverSceneDeployZoneFixedWidth = 200f;

	public const float DeployZoneForwardMargin = 50f;

	public const float DeployZoneBackwardMargin = 100f;

	private Mission _mission;

	private readonly NavalDeploymentPlan _initialPlan;

	private readonly MBList<(string id, MBList<Vec2> points)> _deploymentBoundaries;

	private MatrixFrame _deploymentFrame;

	private float _deploymentWidth;

	private float _deploymentDepth;

	private MBList<Vec2> _meanBoundaryPositions;

	public Team Team { get; private set; }

	internal NavalTeamDeploymentPlan(Mission mission, Team team)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		_deploymentBoundaries = new MBList<(string, MBList<Vec2>)>();
		base._002Ector();
		_mission = mission;
		Team = team;
		_deploymentFrame = MatrixFrame.Identity;
		_deploymentWidth = 0f;
		_deploymentDepth = 0f;
		_meanBoundaryPositions = new MBList<Vec2>();
		bool isRiverPlan = (int)mission.MissionTeamAIType == 4 && _mission.Scene.GetNavmeshFaceCountBetweenTwoIds(1, 1) > 0;
		bool isRaidPlan = (int)mission.MissionTeamAIType == 5;
		_initialPlan = NavalDeploymentPlan.CreatePlan(_mission, team, isRiverPlan, isRaidPlan);
		((List<(string, MBList<Vec2>)>)(object)_deploymentBoundaries).Clear();
	}

	public void MakeDeploymentPlan(float spawnPathOffset, float targetOffset = 0f, FormationSceneSpawnEntry[,] formationSpawnEntries = null, bool isReinforcement = false)
	{
		_initialPlan.MakeDeploymentPlan(spawnPathOffset, targetOffset, formationSpawnEntries);
		PlanDeploymentZone();
	}

	public void ClearPlan(bool isReinforcement = false)
	{
		_initialPlan.ClearPlan();
		((List<Vec2>)(object)_meanBoundaryPositions).Clear();
	}

	public void ClearAddedShips()
	{
		_initialPlan.ClearAddedShips();
	}

	internal void AddShip(FormationClass formationClass, IShipOrigin shipOrigin)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		_initialPlan.AddShip(formationClass, shipOrigin);
	}

	internal bool RemoveShip(FormationClass formationIndex)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return _initialPlan.RemoveShip(formationIndex);
	}

	public int GetShipCount()
	{
		return _initialPlan.ShipCount;
	}

	public bool IsFirstPlan(bool isReinforcement = false)
	{
		return _initialPlan.PlanCount == 1;
	}

	public bool IsPlanMade(bool isReinforcement = false)
	{
		return _initialPlan.IsPlanMade;
	}

	public MBReadOnlyList<(string id, MBList<Vec2> points)> GetDeploymentBoundaries()
	{
		return (MBReadOnlyList<(string id, MBList<Vec2> points)>)(object)_deploymentBoundaries;
	}

	public float GetSpawnPathOffset(bool isReinforcement = false)
	{
		return _initialPlan.SpawnPathOffset;
	}

	public float GetTargetOffset(bool isReinforcement = false)
	{
		return _initialPlan.TargetOffset;
	}

	public MatrixFrame GetDeploymentFrame()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return _deploymentFrame;
	}

	public bool HasDeploymentBoundaries()
	{
		return !Extensions.IsEmpty<(string, MBList<Vec2>)>((IEnumerable<(string, MBList<Vec2>)>)_deploymentBoundaries);
	}

	public IFormationDeploymentPlan GetFormationPlan(FormationClass fClass, bool isReinforcement = false)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return (IFormationDeploymentPlan)(object)_initialPlan.GetFormationPlan(fClass);
	}

	public Vec3 GetMeanPosition(bool isReinforcement = false)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return _initialPlan.MeanPosition;
	}

	public bool IsPositionInsideDeploymentBoundaries(in Vec2 position, out (string id, MBList<Vec2> points) containingBoundaryTuple)
	{
		bool result = false;
		containingBoundaryTuple = (id: "", points: null);
		foreach (var item2 in (List<(string, MBList<Vec2>)>)(object)_deploymentBoundaries)
		{
			MBList<Vec2> item = item2.Item2;
			if (MBSceneUtilities.IsPointInsideBoundaries(ref position, item, 0.05f))
			{
				containingBoundaryTuple = item2;
				result = true;
				break;
			}
		}
		return result;
	}

	public Vec2 GetClosestDeploymentBoundaryPosition(in Vec2 position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		Vec2 result = position;
		float num = float.MaxValue;
		Vec2 val = default(Vec2);
		foreach (var item2 in (List<(string, MBList<Vec2>)>)(object)_deploymentBoundaries)
		{
			MBList<Vec2> item = item2.Item2;
			if (((List<Vec2>)(object)item).Count > 2)
			{
				float num2 = MBSceneUtilities.FindClosestPointToBoundaries(ref position, item, ref val);
				if (num2 < num)
				{
					num = num2;
					result = val;
				}
			}
		}
		return result;
	}

	public Vec2 GetMeanBoundaryPosition(int boundaryIndex = 0)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return ((List<Vec2>)(object)_meanBoundaryPositions)[boundaryIndex];
	}

	private void PlanDeploymentZone()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		Vec3 val = Vec3.Zero;
		Vec2 val2 = Vec2.Zero;
		int num = 0;
		for (int i = 0; i < 10; i++)
		{
			FormationClass fClass = (FormationClass)i;
			NavalFormationDeploymentPlan formationPlan = _initialPlan.GetFormationPlan(fClass);
			if (formationPlan.HasFrame())
			{
				val += formationPlan.GetPosition();
				val2 += formationPlan.GetDirection();
				num++;
			}
		}
		val /= (float)num;
		Vec3 val3 = ((Vec2)(ref val2)).ToVec3(0f);
		val3 = ((Vec3)(ref val3)).NormalizedCopy();
		Mat3 val4 = Mat3.CreateMat3WithForward(ref val3);
		_deploymentFrame = new MatrixFrame(ref val4, ref val);
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		for (int j = 0; j < 10; j++)
		{
			FormationClass fClass2 = (FormationClass)j;
			IFormationDeploymentPlan formationPlan2 = GetFormationPlan(fClass2);
			float num6 = formationPlan2.PlannedDepth / 2f;
			float num7 = formationPlan2.PlannedWidth / 2f;
			if (formationPlan2.HasFrame())
			{
				ref MatrixFrame deploymentFrame = ref _deploymentFrame;
				MatrixFrame frame = formationPlan2.GetFrame();
				MatrixFrame val5 = ((MatrixFrame)(ref deploymentFrame)).TransformToLocal(ref frame);
				num2 = Math.Max(val5.origin.y + num6, num2);
				num3 = Math.Min(val5.origin.y - num6, num3);
				num4 = Math.Max(val5.origin.x + num7, num4);
				num5 = Math.Min(val5.origin.x - num7, num5);
			}
		}
		float val6 = num4 + MathF.Abs(num5);
		float num8 = num2 + MathF.Abs(num3);
		((MatrixFrame)(ref _deploymentFrame)).Advance(num2 + 50f);
		((List<(string, MBList<Vec2>)>)(object)_deploymentBoundaries).Clear();
		((List<Vec2>)(object)_meanBoundaryPositions).Clear();
		if (_initialPlan.IsRiverPlan)
		{
			_deploymentWidth = 200f;
		}
		else
		{
			_deploymentWidth = Math.Max(val6, 400f);
		}
		_deploymentDepth = 50f + MathF.Max(100f, num8);
		Vec2 item = default(Vec2);
		foreach (KeyValuePair<string, ICollection<Vec2>> boundary in _mission.Boundaries)
		{
			string key = boundary.Key;
			ICollection<Vec2> value = boundary.Value;
			MBList<Vec2> val7 = ComputeDeploymentBoundariesFromMissionBoundaries(value);
			((List<(string, MBList<Vec2>)>)(object)_deploymentBoundaries).Add((key, val7));
			((Vec2)(ref item))._002Ector(((IEnumerable<Vec2>)val7).Average(delegate(Vec2 v)
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				return v.x;
			}), ((IEnumerable<Vec2>)val7).Average(delegate(Vec2 v)
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				return v.y;
			}));
			((List<Vec2>)(object)_meanBoundaryPositions).Add(item);
		}
		_deploymentFrame.origin.z = _mission.Scene.GetWaterLevelAtPosition(((Vec3)(ref _deploymentFrame.origin)).AsVec2, true, false);
	}

	private MBList<Vec2> ComputeDeploymentBoundariesFromMissionBoundaries(ICollection<Vec2> missionBoundaries)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		MBList<Vec2> val = new MBList<Vec2>();
		if (missionBoundaries.Count > 2)
		{
			Vec2 asVec = ((Vec3)(ref _deploymentFrame.origin)).AsVec2;
			Vec2 val2 = ((Vec3)(ref _deploymentFrame.rotation.s)).AsVec2;
			Vec2 val3 = ((Vec2)(ref val2)).Normalized();
			val2 = ((Vec3)(ref _deploymentFrame.rotation.f)).AsVec2;
			Vec2 val4 = ((Vec2)(ref val2)).Normalized();
			Vec2 val5 = asVec - _deploymentDepth / 2f * val4;
			MBList<Vec2> val6 = new MBList<Vec2>();
			Vec2 val7 = asVec - _deploymentWidth / 2f * val3;
			((List<Vec2>)(object)val6).Add(val7);
			Vec2 val8 = val7 - val4 * _deploymentDepth;
			((List<Vec2>)(object)val6).Add(val8);
			Vec2 val9 = val8 + val3 * _deploymentWidth;
			((List<Vec2>)(object)val6).Add(val9);
			Vec2 item = val9 + val4 * _deploymentDepth;
			((List<Vec2>)(object)val6).Add(item);
			MBList<Vec2> val10 = Extensions.ToMBList<Vec2>((IEnumerable<Vec2>)missionBoundaries);
			Vec2 point = default(Vec2);
			Vec2 point2 = default(Vec2);
			foreach (Vec2 item2 in (List<Vec2>)(object)val6)
			{
				Vec2 current = item2;
				if (MBSceneUtilities.IsPointInsideBoundaries(ref current, val10, 0.05f))
				{
					AddDeploymentBoundaryPoint(val, current);
					continue;
				}
				val2 = val5 - current;
				Vec2 val11 = ((Vec2)(ref val2)).Normalized();
				Vec2 val12 = ((Vec2.DotProduct(val11, val3) >= 0f) ? val3 : (-val3));
				if (MBMath.IntersectRayWithPolygon(current, val12, val10, ref point))
				{
					AddDeploymentBoundaryPoint(val, point);
				}
				Vec2 val13 = ((Vec2.DotProduct(val11, val4) >= 0f) ? val4 : (-val4));
				if (MBMath.IntersectRayWithPolygon(current, val13, val10, ref point2))
				{
					AddDeploymentBoundaryPoint(val, point2);
				}
			}
			foreach (Vec2 item3 in (List<Vec2>)(object)val10)
			{
				Vec2 current2 = item3;
				if (MBSceneUtilities.IsPointInsideBoundaries(ref current2, val6, 0.05f))
				{
					AddDeploymentBoundaryPoint(val, current2);
				}
			}
			MBSceneUtilities.RadialSortBoundary(ref val);
			MBSceneUtilities.FindConvexHull(ref val);
		}
		return val;
	}

	private void AddDeploymentBoundaryPoint(MBList<Vec2> deploymentBoundaries, Vec2 point)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (!((List<Vec2>)(object)deploymentBoundaries).Exists((Predicate<Vec2>)delegate(Vec2 boundaryPoint)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			return ((Vec2)(ref boundaryPoint)).Distance(point) <= 0.1f;
		}))
		{
			((List<Vec2>)(object)deploymentBoundaries).Add(point);
		}
	}

	bool ITeamDeploymentPlan.IsPositionInsideDeploymentBoundaries(in Vec2 position, out (string id, MBList<Vec2> points) containingBoundaryTuple)
	{
		return IsPositionInsideDeploymentBoundaries(in position, out containingBoundaryTuple);
	}

	Vec2 ITeamDeploymentPlan.GetClosestDeploymentBoundaryPosition(in Vec2 position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return GetClosestDeploymentBoundaryPosition(in position);
	}
}

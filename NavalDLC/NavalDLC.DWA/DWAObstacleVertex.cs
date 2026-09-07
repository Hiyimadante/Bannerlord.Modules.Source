using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.DWA;

public class DWAObstacleVertex : IDWAObstacleVertex
{
	private Vec2 _direction;

	[CompilerGenerated]
	private Vec2 _003CPoint_003Ek__BackingField;

	int IDWAObstacleVertex.Id => Id;

	Vec2 IDWAObstacleVertex.Point
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return Point;
		}
	}

	float IDWAObstacleVertex.PointZ => PointZ;

	public int Id { get; }

	public Vec2 Point
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CPoint_003Ek__BackingField;
		}
		[CompilerGenerated]
		internal set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CPoint_003Ek__BackingField = value;
		}
	}

	public Vec3 Point3D
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			Vec2 point = Point;
			return ((Vec2)(ref point)).ToVec3(PointZ);
		}
	}

	public float PointZ { get; internal set; }

	public Vec2 Direction
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _direction;
		}
		internal set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_direction = value;
		}
	}

	public DWAObstacleVertex Previous { get; internal set; }

	public DWAObstacleVertex Next { get; internal set; }

	public bool IsConvex { get; internal set; }

	internal DWAObstacleVertex(int id)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector();
		Id = id;
		Point = Vec2.Invalid;
		PointZ = 0f;
		Direction = Vec2.Forward;
		Previous = null;
		Next = null;
		IsConvex = false;
	}
}

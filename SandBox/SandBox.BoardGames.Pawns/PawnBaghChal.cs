using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.BoardGames.Pawns;

public class PawnBaghChal : PawnBase
{
	public int X;

	public int Y;

	public int PrevX;

	public int PrevY;

	[CompilerGenerated]
	private readonly MatrixFrame _003CInitialFrame_003Ek__BackingField;

	public override bool IsPlaced
	{
		get
		{
			if (X >= 0 && X < BoardGameBaghChal.BoardWidth && Y >= 0)
			{
				return Y < BoardGameBaghChal.BoardHeight;
			}
			return false;
		}
	}

	public MatrixFrame InitialFrame
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CInitialFrame_003Ek__BackingField;
		}
	}

	public bool IsTiger { get; }

	public bool IsGoat => !IsTiger;

	public PawnBaghChal(GameEntity entity, bool playerOne, bool isTiger)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector(entity, playerOne);
		X = -1;
		Y = -1;
		PrevX = -1;
		PrevY = -1;
		IsTiger = isTiger;
		InitialFrame = base.Entity.GetFrame();
	}

	public override void Reset()
	{
		base.Reset();
		X = -1;
		Y = -1;
		PrevX = -1;
		PrevY = -1;
	}
}

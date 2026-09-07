using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

public class MissionPlayerMovementFlagsChangeEvent : EventBase
{
	[CompilerGenerated]
	private MovementControlFlag _003CMovementFlag_003Ek__BackingField;

	public MovementControlFlag MovementFlag
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CMovementFlag_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CMovementFlag_003Ek__BackingField = value;
		}
	}

	public MissionPlayerMovementFlagsChangeEvent(MovementControlFlag movementFlag)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((EventBase)this)._002Ector();
		MovementFlag = movementFlag;
	}
}

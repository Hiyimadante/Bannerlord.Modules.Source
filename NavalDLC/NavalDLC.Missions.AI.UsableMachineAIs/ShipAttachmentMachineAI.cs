using NavalDLC.Missions.Objects.UsableMachines;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.UsableMachineAIs;

public sealed class ShipAttachmentMachineAI : UsableMachineAIBase
{
	public override bool HasActionCompleted => false;

	protected override MovementOrder NextOrder
	{
		get
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return MovementOrder.MovementOrderCharge;
		}
	}

	private ShipAttachmentMachine ShipAttachmentMachine => base.UsableMachine as ShipAttachmentMachine;

	public ShipAttachmentMachineAI(ShipAttachmentMachine shipAttachmentMachine)
		: base((UsableMachine)(object)shipAttachmentMachine)
	{
	}
}

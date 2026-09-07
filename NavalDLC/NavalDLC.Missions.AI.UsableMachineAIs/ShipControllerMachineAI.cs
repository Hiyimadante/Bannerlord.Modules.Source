using NavalDLC.Missions.Objects.UsableMachines;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.UsableMachineAIs;

public sealed class ShipControllerMachineAI : UsableMachineAIBase
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

	private ShipControllerMachine ShipControllerMachine => base.UsableMachine as ShipControllerMachine;

	public ShipControllerMachineAI(ShipControllerMachine shipControllerMachine)
		: base((UsableMachine)(object)shipControllerMachine)
	{
	}
}

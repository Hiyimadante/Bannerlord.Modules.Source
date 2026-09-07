using System.Collections.Generic;
using NavalDLC.Missions.Objects;
using NavalDLC.Storyline.MissionControllers;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Quest3;

internal class BurnShipObjective : MissionObjective
{
	private BlockedEstuaryMissionController _controller;

	private MissionShip _targetShip;

	public override string UniqueId => "naval_storyline_quest_3_burn_ship_objective";

	public override TextObject Name
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			return new TextObject("{=Ry0xZCO2}Ram Enemy Ship", (Dictionary<string, object>)null);
		}
	}

	public override TextObject Description
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			return new TextObject("{=BHR7DWsG}Destroy the enemy ship by ramming it with your fireship.", (Dictionary<string, object>)null);
		}
	}

	internal BurnShipObjective(Mission mission, MissionShip targetShip)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		((MissionObjective)this)._002Ector(mission);
		_controller = ((MissionObjective)this).Mission.GetMissionBehavior<BlockedEstuaryMissionController>();
		_targetShip = targetShip;
		((MissionObjective)this).AddTarget((MissionObjectiveTarget)(object)new ShipObjectiveTarget(_targetShip, new TextObject("{=EBLRhSsY}Target Ship", (Dictionary<string, object>)null)));
	}

	protected override bool IsActivationRequirementsMet()
	{
		return _targetShip != null;
	}

	protected override bool IsCompletionRequirementsMet()
	{
		return _controller.ShipsCollided;
	}
}

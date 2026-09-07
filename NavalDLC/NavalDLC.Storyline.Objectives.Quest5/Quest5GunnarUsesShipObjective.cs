using System.Collections.Generic;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Quest5;

public class Quest5GunnarUsesShipObjective : MissionObjective
{
	public override string UniqueId => "quest_5_gunnar_uses_ship_objective";

	public override TextObject Name
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			return new TextObject("{=LBNwZ3HS}Keep Watch", (Dictionary<string, object>)null);
		}
	}

	public override TextObject Description
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			return new TextObject("{=araGPQbp}Keep watch for approaching enemy ships.", (Dictionary<string, object>)null);
		}
	}

	public Quest5GunnarUsesShipObjective(Mission mission)
		: base(mission)
	{
	}

	protected override bool IsActivationRequirementsMet()
	{
		return true;
	}

	protected override bool IsCompletionRequirementsMet()
	{
		return false;
	}
}

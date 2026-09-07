using System.Collections.Generic;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Quest5;

public class Quest5ReachAlliesObjective : MissionObjective
{
	private readonly VolumeBox _targetVolumeBox;

	public override string UniqueId => "quest_5_reach_allies_objective";

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

	public Quest5ReachAlliesObjective(Mission mission, VolumeBox targetVolumeBox)
		: base(mission)
	{
		_targetVolumeBox = targetVolumeBox;
	}

	protected override bool IsActivationRequirementsMet()
	{
		return true;
	}

	protected override bool IsCompletionRequirementsMet()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Agent main = Agent.Main;
		if (main != null && main.IsActive())
		{
			return _targetVolumeBox.IsPointIn(Agent.Main.Position);
		}
		return false;
	}
}

using System.Collections.Generic;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace SandBox.Missions.MissionLogics.Hideout.Objectives;

public class ClearTheMainCampObjective : MissionObjective
{
	private readonly List<Agent> _agents;

	private readonly int _requiredProgressAmount;

	public override string UniqueId => "hideout_mission_clear_the_main_camp_objective";

	public override TextObject Name
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			return new TextObject("{=OLWkIYxa}Clear the Main Camp", (Dictionary<string, object>)null);
		}
	}

	public override TextObject Description
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			return new TextObject("{=lGZLiIey}Clear the main camp with your troops.", (Dictionary<string, object>)null);
		}
	}

	public ClearTheMainCampObjective(Mission mission, List<Agent> agents)
		: base(mission)
	{
		_agents = agents;
		_requiredProgressAmount = agents.Count;
	}

	public override MissionObjectiveProgressInfo GetCurrentProgress()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		return new MissionObjectiveProgressInfo
		{
			CurrentProgressAmount = _requiredProgressAmount - _agents.Count,
			RequiredProgressAmount = _requiredProgressAmount
		};
	}
}

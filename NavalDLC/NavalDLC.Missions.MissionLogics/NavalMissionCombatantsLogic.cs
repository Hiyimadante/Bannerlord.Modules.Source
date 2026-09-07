using System.Collections.Generic;
using NavalDLC.Missions.AI.Tactics;
using NavalDLC.Missions.AI.TeamAI;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class NavalMissionCombatantsLogic : MissionCombatantsLogic
{
	public NavalMissionCombatantsLogic(IEnumerable<IBattleCombatant> battleCombatants, IBattleCombatant playerBattleCombatant, IBattleCombatant defenderLeaderBattleCombatant, IBattleCombatant attackerLeaderBattleCombatant, MissionTeamAITypeEnum teamAIType, bool isPlayerSergeant)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((MissionCombatantsLogic)this)._002Ector(battleCombatants, playerBattleCombatant, defenderLeaderBattleCombatant, attackerLeaderBattleCombatant, teamAIType, isPlayerSergeant);
	}

	public override void EarlyStart()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Invalid comparison between Unknown and I4
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		Mission.Current.MissionTeamAIType = base.TeamAIType;
		foreach (Team item in (List<Team>)(object)Mission.Current.Teams)
		{
			if ((int)base.TeamAIType == 4)
			{
				item.AddTeamAI((TeamAIComponent)(object)new TeamAINavalComponent(((MissionBehavior)this).Mission, item, 5f, 1f), false);
			}
			else if ((int)base.TeamAIType == 5)
			{
				if (item.IsAttacker)
				{
					item.AddTeamAI((TeamAIComponent)(object)new TeamAINavalRaidAttackerComponent(((MissionBehavior)this).Mission, item, 5f, 1f), false);
				}
				else
				{
					item.AddTeamAI((TeamAIComponent)(object)new TeamAINavalRaidDefenderComponent(((MissionBehavior)this).Mission, item, 5f), false);
				}
			}
		}
		if (((List<Team>)(object)Mission.Current.Teams).Count <= 0)
		{
			return;
		}
		foreach (Team item2 in (List<Team>)(object)Mission.Current.Teams)
		{
			if (!item2.HasTeamAi)
			{
				continue;
			}
			if ((int)base.TeamAIType == 4)
			{
				item2.AddTacticOption((TacticComponent)(object)new TacticNavalBalancedOffense(item2));
				if ((int)item2.Side == 0)
				{
					item2.AddTacticOption((TacticComponent)(object)new TacticNavalLineDefense(item2));
				}
			}
			else if ((int)base.TeamAIType == 5)
			{
				item2.AddTacticOption((TacticComponent)new TacticCharge(item2));
				if ((int)item2.Side == 0)
				{
					item2.AddTacticOption((TacticComponent)(object)new TacticNavalRaidDefense(item2));
				}
			}
		}
		foreach (Team item3 in (List<Team>)(object)((MissionBehavior)this).Mission.Teams)
		{
			item3.QuerySystem.Expire();
			item3.ResetTactic();
		}
	}
}

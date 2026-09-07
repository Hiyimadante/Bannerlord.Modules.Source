using System.Collections.Generic;
using Helpers;
using NavalDLC.CharacterDevelopment;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.GameComponents;

public class NavalDLCRaidModel : RaidModel
{
	public override int GoldRewardForEachLostHearth => ((MBGameModel<RaidModel>)this).BaseModel.GoldRewardForEachLostHearth;

	public override ExplainedNumber CalculateHitDamage(MapEventSide attackerSide, float settlementHitPoints)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		ExplainedNumber result = ((MBGameModel<RaidModel>)this).BaseModel.CalculateHitDamage(attackerSide, settlementHitPoints);
		int num = 0;
		foreach (MapEventParty item in (List<MapEventParty>)(object)attackerSide.Parties)
		{
			num += item.Party.MemberRoster.TotalManCount;
		}
		if (num > 0)
		{
			ExplainedNumber val = default(ExplainedNumber);
			foreach (MapEventParty item2 in (List<MapEventParty>)(object)attackerSide.Parties)
			{
				PartyBase party = item2.Party;
				int totalManCount = party.MemberRoster.TotalManCount;
				if (totalManCount <= 0)
				{
					continue;
				}
				float num2 = (float)totalManCount / (float)num;
				if (PartyBaseHelper.HasFeat(party, NavalCulturalFeats.NordHostileActionSpeedFeat))
				{
					((ExplainedNumber)(ref result)).AddFactor(NavalCulturalFeats.NordHostileActionSpeedFeat.EffectBonus * num2, (TextObject)null);
				}
				if (party.MobileParty != null && party.MobileParty.IsCurrentlyAtSea)
				{
					((ExplainedNumber)(ref val))._002Ector(0f, false, (TextObject)null);
					PerkHelper.AddPerkBonusForParty(NavalPerks.Mariner.Forceful, party.MobileParty, false, ref val, false);
					if (((ExplainedNumber)(ref val)).ResultNumber != 0f)
					{
						((ExplainedNumber)(ref result)).AddFactor(((ExplainedNumber)(ref val)).ResultNumber * num2, (TextObject)null);
					}
				}
			}
		}
		return result;
	}

	public override ExplainedNumber GetRaidLootMultiplier(PartyBase receivingParty)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		ExplainedNumber raidLootMultiplier = ((MBGameModel<RaidModel>)this).BaseModel.GetRaidLootMultiplier(receivingParty);
		if (receivingParty != null && receivingParty.IsMobile && receivingParty.MobileParty.IsCurrentlyAtSea)
		{
			PerkHelper.AddPerkBonusForParty(NavalPerks.Mariner.BruteForce, receivingParty.MobileParty, false, ref raidLootMultiplier, false);
		}
		return raidLootMultiplier;
	}

	public override MBReadOnlyList<(ItemObject, float)> GetCommonLootItemScores()
	{
		return ((MBGameModel<RaidModel>)this).BaseModel.GetCommonLootItemScores();
	}
}

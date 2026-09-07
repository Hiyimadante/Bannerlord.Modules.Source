using System.Collections.Generic;
using System.Linq;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace NavalDLC.CustomBattle.CustomBattle;

public static class NavalCustomBattleHelper
{
	public const string DefaultNavalBattleGameTypeStringId = "NavalBattle";

	public const string DefaultNavalRaidGameTypeStringId = "NavalRaid";

	private const string EmpireInfantryTroop = "imperial_veteran_infantryman";

	private const string EmpireRangedTroop = "imperial_archer";

	private const string EmpireCavalryTroop = "imperial_heavy_horseman";

	private const string EmpireHorseArcherTroop = "bucellarii";

	private const string SturgiaInfantryTroop = "sturgian_spearman";

	private const string SturgiaRangedTroop = "sturgian_archer";

	private const string SturgiaCavalryTroop = "sturgian_hardened_brigand";

	private const string AseraiInfantryTroop = "aserai_infantry";

	private const string AseraiRangedTroop = "aserai_archer";

	private const string AseraiCavalryTroop = "aserai_mameluke_cavalry";

	private const string AseraiHorseArcherTroop = "aserai_faris";

	private const string VlandiaInfantryTroop = "vlandian_swordsman";

	private const string VlandiaRangedTroop = "vlandian_hardened_crossbowman";

	private const string VlandiaCavalryTroop = "vlandian_knight";

	private const string BattaniaInfantryTroop = "battanian_picked_warrior";

	private const string BattaniaRangedTroop = "battanian_hero";

	private const string BattaniaCavalryTroop = "battanian_scout";

	private const string KhuzaitInfantryTroop = "khuzait_spear_infantry";

	private const string KhuzaitRangedTroop = "khuzait_archer";

	private const string KhuzaitCavalryTroop = "khuzait_lancer";

	private const string KhuzaitHorseArcherTroop = "khuzait_horse_archer";

	private const string NordInfantryTroop = "nord_spear_warrior";

	private const string NordRangedTroop = "nord_marksman";

	public static void StartGame(NavalCustomBattleData data)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		Game.Current.PlayerTroop = data.PlayerCharacter;
		if (data.GameTypeStringId == "NavalBattle")
		{
			CustomNavalMissions.OpenNavalBattleForCustomMission(data.SceneId, data.PlayerCharacter, data.PlayerParty, Extensions.ToMBList<IShipOrigin>(data.PlayerShips), data.EnemyParty, Extensions.ToMBList<IShipOrigin>(data.EnemyShips), isPlayerGeneral: true, data.SeasonId, data.TimeOfDay, data.WindStrength, data.WindDirection, data.Terrain, data.ForcedSceneLevel);
		}
		else if (data.GameTypeStringId == "NavalRaid")
		{
			MBList<IShipOrigin> attackerShips = (((int)data.PlayerParty.Side == 1) ? Extensions.ToMBList<IShipOrigin>(data.PlayerShips) : Extensions.ToMBList<IShipOrigin>(data.EnemyShips));
			CustomNavalMissions.OpenNavalRaidBattleForCustomMission(data.SceneId, data.PlayerCharacter, data.PlayerParty, data.EnemyParty, attackerShips, isPlayerGeneral: true, data.SeasonId, data.TimeOfDay, 0.5f, NavalCustomBattleWindConfig.Direction.TowardsAttacker, data.Terrain, data.ForcedSceneLevel);
		}
		else
		{
			Debug.FailedAssert("NavalCustomBattleData.GameTypeStringId: \"" + data.GameTypeStringId + "\" is invalid!", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC.CustomBattle\\CustomBattle\\NavalCustomBattleHelper.cs", "StartGame", 76);
		}
	}

	public static NavalCustomBattleData PrepareBattleData(BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, List<IShipOrigin> playerShips, CustomBattleCombatant enemyParty, List<IShipOrigin> enemyShips, string gameTypeStringId, string scene, string season, float timeOfDay, float windStrength, NavalCustomBattleWindConfig.Direction windDirection, TerrainType terrain, string forcedSceneLevel)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		return new NavalCustomBattleData
		{
			GameTypeStringId = gameTypeStringId,
			SceneId = scene,
			PlayerCharacter = playerCharacter,
			PlayerParty = playerParty,
			PlayerShips = playerShips,
			EnemyParty = enemyParty,
			EnemyShips = enemyShips,
			SeasonId = season,
			TimeOfDay = timeOfDay,
			WindStrength = windStrength,
			WindDirection = windDirection,
			Terrain = terrain,
			ForcedSceneLevel = forcedSceneLevel
		};
	}

	public static CustomBattleCombatant[] GetCustomBattleParties(BasicCharacterObject playerCharacter, BasicCharacterObject enemyCharacter, List<BasicCharacterObject> remainingHeroes, BasicCultureObject playerFaction, int[] playerNumbers, List<BasicCharacterObject>[] playerTroopSelections, int playerHeroCount, BasicCultureObject enemyFaction, int[] enemyNumbers, List<BasicCharacterObject>[] enemyTroopSelections, int enemyHeroCount, bool isPlayerAttacker)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		object obj;
		if (playerFaction == null)
		{
			obj = null;
		}
		else
		{
			Banner banner = playerFaction.Banner;
			obj = ((banner != null) ? banner.BannerCode : null);
		}
		if (obj == null)
		{
			obj = string.Empty;
		}
		Banner val;
		if (Banner.IsValidBannerCode((string)obj))
		{
			val = new Banner(playerFaction.Banner, playerFaction.Color, playerFaction.Color2);
		}
		else
		{
			object obj2;
			if (playerFaction == null)
			{
				obj2 = null;
			}
			else
			{
				Banner banner2 = playerFaction.Banner;
				obj2 = ((banner2 != null) ? banner2.BannerCode : null);
			}
			Debug.FailedAssert("Banner code for player faction is not valid: " + (string?)obj2, "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC.CustomBattle\\CustomBattle\\NavalCustomBattleHelper.cs", "GetCustomBattleParties", 126);
			val = Banner.CreateOneColoredEmptyBanner(92);
		}
		object obj3;
		if (enemyFaction == null)
		{
			obj3 = null;
		}
		else
		{
			Banner banner3 = enemyFaction.Banner;
			obj3 = ((banner3 != null) ? banner3.BannerCode : null);
		}
		if (obj3 == null)
		{
			obj3 = string.Empty;
		}
		Banner val2;
		if (Banner.IsValidBannerCode((string)obj3))
		{
			val2 = new Banner(enemyFaction.Banner, enemyFaction.Color, enemyFaction.Color2);
		}
		else
		{
			object obj4;
			if (playerFaction == null)
			{
				obj4 = null;
			}
			else
			{
				Banner banner4 = playerFaction.Banner;
				obj4 = ((banner4 != null) ? banner4.BannerCode : null);
			}
			Debug.FailedAssert("Banner code for enemy faction is not valid: " + (string?)obj4, "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC.CustomBattle\\CustomBattle\\NavalCustomBattleHelper.cs", "GetCustomBattleParties", 136);
			val2 = Banner.CreateOneColoredEmptyBanner(92);
		}
		if (((MBObjectBase)playerFaction).StringId == ((MBObjectBase)enemyFaction).StringId)
		{
			uint primaryColor = val2.GetPrimaryColor();
			val2.ChangePrimaryColor(val2.GetFirstIconColor());
			val2.ChangeIconColors(primaryColor);
		}
		CustomBattleCombatant[] array = (CustomBattleCombatant[])(object)new CustomBattleCombatant[2]
		{
			new CustomBattleCombatant(new TextObject("{=sSJSTe5p}Player Party", (Dictionary<string, object>)null), playerFaction, val),
			new CustomBattleCombatant(new TextObject("{=0xC75dN6}Enemy Party", (Dictionary<string, object>)null), enemyFaction, val2)
		};
		int num = playerHeroCount - 1;
		int num2 = enemyHeroCount - 1;
		array[0].Side = (BattleSideEnum)(isPlayerAttacker ? 1 : 0);
		array[0].AddCharacter(playerCharacter, 1);
		array[0].SetGeneral(playerCharacter);
		for (int i = 0; i < num; i++)
		{
			int index = MBRandom.RandomInt(0, remainingHeroes.Count);
			array[0].AddCharacter(remainingHeroes[index], 1);
			remainingHeroes.RemoveAt(index);
		}
		array[1].Side = Extensions.GetOppositeSide(array[0].Side);
		array[1].AddCharacter(enemyCharacter, 1);
		for (int j = 0; j < num2; j++)
		{
			int index2 = MBRandom.RandomInt(0, remainingHeroes.Count);
			array[1].AddCharacter(remainingHeroes[index2], 1);
			remainingHeroes.RemoveAt(index2);
		}
		for (int k = 0; k < array.Length; k++)
		{
			PopulateListsWithDefaults(ref array[k], (k == 0) ? playerNumbers : enemyNumbers, (k == 0) ? playerTroopSelections : enemyTroopSelections);
		}
		return array;
	}

	public static List<IShipOrigin>[] GetCustomBattleShipLists(List<IShipOrigin> playerShips, List<IShipOrigin> enemyShips)
	{
		List<IShipOrigin>[] array = new List<IShipOrigin>[2]
		{
			new List<IShipOrigin>(),
			new List<IShipOrigin>()
		};
		foreach (IShipOrigin playerShip in playerShips)
		{
			if (playerShip is CustomBattleShip customBattleShip)
			{
				array[0].Add((IShipOrigin)(object)customBattleShip.GetCopy());
			}
		}
		foreach (IShipOrigin enemyShip in enemyShips)
		{
			if (enemyShip is CustomBattleShip customBattleShip2)
			{
				array[1].Add((IShipOrigin)(object)customBattleShip2.GetCopy());
			}
		}
		return array;
	}

	private static void PopulateListsWithDefaults(ref CustomBattleCombatant customBattleParties, int[] numbers, List<BasicCharacterObject>[] troopList)
	{
		BasicCultureObject basicCulture = customBattleParties.BasicCulture;
		if (troopList == null)
		{
			troopList = new List<BasicCharacterObject>[4]
			{
				new List<BasicCharacterObject>(),
				new List<BasicCharacterObject>(),
				new List<BasicCharacterObject>(),
				new List<BasicCharacterObject>()
			};
		}
		if (troopList[0].Count == 0)
		{
			troopList[0] = new List<BasicCharacterObject> { GetDefaultTroopOfFormationForFaction(basicCulture, (FormationClass)0) };
		}
		if (troopList[1].Count == 0)
		{
			troopList[1] = new List<BasicCharacterObject> { GetDefaultTroopOfFormationForFaction(basicCulture, (FormationClass)1) };
		}
		if (troopList[2].Count == 0)
		{
			troopList[2] = new List<BasicCharacterObject> { GetDefaultTroopOfFormationForFaction(basicCulture, (FormationClass)2) };
		}
		if (troopList[3].Count == 0)
		{
			troopList[3] = new List<BasicCharacterObject> { GetDefaultTroopOfFormationForFaction(basicCulture, (FormationClass)3) };
		}
		if (troopList[3].Count == 0 || troopList[3].All((BasicCharacterObject troop) => troop == null))
		{
			numbers[2] += numbers[3] / 3;
			numbers[1] += numbers[3] / 3;
			numbers[0] += numbers[3] / 3;
			numbers[0] += numbers[3] - numbers[3] / 3 * 3;
			numbers[3] = 0;
		}
		for (int num = 0; num < 4; num++)
		{
			int count = troopList[num].Count;
			int num2 = numbers[num];
			if (num2 <= 0)
			{
				continue;
			}
			float num3 = (float)num2 / (float)count;
			float num4 = 0f;
			for (int num5 = 0; num5 < count; num5++)
			{
				float num6 = num3 + num4;
				int num7 = MathF.Floor(num6);
				num4 = num6 - (float)num7;
				customBattleParties.AddCharacter(troopList[num][num5], num7);
				numbers[num] -= num7;
				if (num5 == count - 1 && numbers[num] > 0)
				{
					customBattleParties.AddCharacter(troopList[num][num5], numbers[num]);
					numbers[num] = 0;
				}
			}
		}
	}

	public static int[] GetTroopCounts(int armySize, int heroCount, NavalCustomBattleCompositionData compositionData)
	{
		int[] array = new int[4];
		armySize -= heroCount;
		array[1] = MathF.Round(compositionData.RangedPercentage * (float)armySize);
		array[2] = MathF.Round(compositionData.CavalryPercentage * (float)armySize);
		array[3] = MathF.Round(compositionData.RangedCavalryPercentage * (float)armySize);
		array[0] = armySize - array.Sum();
		return array;
	}

	private static BasicCharacterObject GetTroopFromId(string troopId)
	{
		return MBObjectManager.Instance.GetObject<BasicCharacterObject>(troopId);
	}

	public static BasicCharacterObject GetDefaultTroopOfFormationForFaction(BasicCultureObject culture, FormationClass formation)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected I4, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected I4, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected I4, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected I4, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected I4, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected I4, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Invalid comparison between Unknown and I4
		if (((MBObjectBase)culture).StringId.ToLower() == "empire")
		{
			switch ((int)formation)
			{
			case 0:
				return GetTroopFromId("imperial_veteran_infantryman");
			case 1:
				return GetTroopFromId("imperial_archer");
			case 2:
				return GetTroopFromId("imperial_heavy_horseman");
			case 3:
				return GetTroopFromId("bucellarii");
			}
		}
		else if (((MBObjectBase)culture).StringId.ToLower() == "sturgia")
		{
			switch ((int)formation)
			{
			case 0:
				return GetTroopFromId("sturgian_spearman");
			case 1:
				return GetTroopFromId("sturgian_archer");
			case 2:
				return GetTroopFromId("sturgian_hardened_brigand");
			}
		}
		else if (((MBObjectBase)culture).StringId.ToLower() == "aserai")
		{
			switch ((int)formation)
			{
			case 0:
				return GetTroopFromId("aserai_infantry");
			case 1:
				return GetTroopFromId("aserai_archer");
			case 2:
				return GetTroopFromId("aserai_mameluke_cavalry");
			case 3:
				return GetTroopFromId("aserai_faris");
			}
		}
		else if (((MBObjectBase)culture).StringId.ToLower() == "vlandia")
		{
			switch ((int)formation)
			{
			case 0:
				return GetTroopFromId("vlandian_swordsman");
			case 1:
				return GetTroopFromId("vlandian_hardened_crossbowman");
			case 2:
				return GetTroopFromId("vlandian_knight");
			}
		}
		else if (((MBObjectBase)culture).StringId.ToLower() == "battania")
		{
			switch ((int)formation)
			{
			case 0:
				return GetTroopFromId("battanian_picked_warrior");
			case 1:
				return GetTroopFromId("battanian_hero");
			case 2:
				return GetTroopFromId("battanian_scout");
			}
		}
		else if (((MBObjectBase)culture).StringId.ToLower() == "khuzait")
		{
			switch ((int)formation)
			{
			case 0:
				return GetTroopFromId("khuzait_spear_infantry");
			case 1:
				return GetTroopFromId("khuzait_archer");
			case 2:
				return GetTroopFromId("khuzait_lancer");
			case 3:
				return GetTroopFromId("khuzait_horse_archer");
			}
		}
		else if (((MBObjectBase)culture).StringId.ToLower() == "nord")
		{
			if ((int)formation == 0)
			{
				return GetTroopFromId("nord_spear_warrior");
			}
			if ((int)formation == 1)
			{
				return GetTroopFromId("nord_marksman");
			}
		}
		return null;
	}

	public static bool CanShipHullBeUsedInRaid(ShipHull shipHull)
	{
		return shipHull.CanNavigateShallowWater;
	}
}

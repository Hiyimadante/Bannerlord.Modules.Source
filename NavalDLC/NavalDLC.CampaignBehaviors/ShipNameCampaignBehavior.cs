using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace NavalDLC.CampaignBehaviors;

public class ShipNameCampaignBehavior : CampaignBehaviorBase
{
	[Flags]
	private enum NameTrait
	{
		None = 0,
		Aserai = 2,
		Battania = 4,
		Empire = 8,
		Khuzait = 0x10,
		Nord = 0x20,
		Sturgia = 0x40,
		Vlandia = 0x80,
		Light = 0x100,
		Medium = 0x200,
		Heavy = 0x400,
		Trade = 0x800,
		LightAndMedium = Light | Medium
	}

	private MBReadOnlyList<(TextObject, NameTrait, float)> _fullNames;

	private MBReadOnlyList<(TextObject, NameTrait)> _firstNames;

	public override void SyncData(IDataStore dataStore)
	{
	}

	public override void RegisterEvents()
	{
		CampaignEvents.OnShipOwnerChangedEvent.AddNonSerializedListener((object)this, (Action<Ship, PartyBase, ShipOwnerChangeDetail>)OnShipOwnerChanged);
	}

	private void OnShipOwnerChanged(Ship ship, PartyBase owner, ShipOwnerChangeDetail detail)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Invalid comparison between Unknown and I4
		if ((int)detail == 3 || (int)detail == 4)
		{
			AssignNameToShip(ship);
		}
	}

	private TextObject GetRandomFullName(List<int> availableWeights, float totalWeight)
	{
		float num = MBRandom.RandomFloatRanged(totalWeight);
		for (int i = 0; i < availableWeights.Count; i++)
		{
			num -= ((List<(TextObject, NameTrait, float)>)(object)_fullNames)[availableWeights[i]].Item3;
			if (num < 0f)
			{
				return ((List<(TextObject, NameTrait, float)>)(object)_fullNames)[availableWeights[i]].Item1;
			}
		}
		return null;
	}

	private void AssignNameToShip(Ship ship)
	{
		float num = 0f;
		NameTrait nameFlags = GetNameFlags(ship);
		List<int> list = new List<int>();
		for (int i = 0; i < ((List<(TextObject, NameTrait, float)>)(object)_fullNames).Count; i++)
		{
			if (Extensions.HasAllFlags<NameTrait>(((List<(TextObject, NameTrait, float)>)(object)_fullNames)[i].Item2, nameFlags))
			{
				list.Add(i);
				num += ((List<(TextObject, NameTrait, float)>)(object)_fullNames)[i].Item3;
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		TextObject val = GetRandomFullName(list, num).CopyTextObject();
		list.Clear();
		for (int j = 0; j < ((List<(TextObject, NameTrait)>)(object)_firstNames).Count; j++)
		{
			if (Extensions.HasAllFlags<NameTrait>(((List<(TextObject, NameTrait)>)(object)_firstNames)[j].Item2, nameFlags))
			{
				list.Add(j);
			}
		}
		if (list.Count > 0)
		{
			TextObject val2 = ((List<(TextObject, NameTrait)>)(object)_firstNames)[Extensions.GetRandomElement<int>((IReadOnlyList<int>)list)].Item1.CopyTextObject();
			val.SetTextVariable("NAME", val2);
			ship.SetName(val);
		}
	}

	private static NameTrait GetNameFlags(Ship ship)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		NameTrait nameTrait = NameTrait.None;
		if (ship.ShipHull.IsTradeShip)
		{
			nameTrait |= NameTrait.Trade;
		}
		else if ((int)ship.ShipHull.Type == 0)
		{
			nameTrait |= NameTrait.Light;
		}
		else if ((int)ship.ShipHull.Type == 1)
		{
			nameTrait |= NameTrait.Medium;
		}
		else if ((int)ship.ShipHull.Type == 2)
		{
			nameTrait |= NameTrait.Heavy;
		}
		CultureObject culture = ship.Owner.Culture;
		if (((MBObjectBase)culture).StringId == "aserai")
		{
			nameTrait |= NameTrait.Aserai;
		}
		else if (((MBObjectBase)culture).StringId == "khuzait")
		{
			nameTrait |= NameTrait.Khuzait;
		}
		else if (((MBObjectBase)culture).StringId == "vlandia")
		{
			nameTrait |= NameTrait.Vlandia;
		}
		else if (((MBObjectBase)culture).StringId == "sturgia")
		{
			nameTrait |= NameTrait.Sturgia;
		}
		else if (((MBObjectBase)culture).StringId == "battania")
		{
			nameTrait |= NameTrait.Battania;
		}
		else if (((MBObjectBase)culture).StringId == "empire")
		{
			nameTrait |= NameTrait.Empire;
		}
		else if (((MBObjectBase)culture).StringId == "nord")
		{
			nameTrait |= NameTrait.Nord;
		}
		return nameTrait;
	}

	public ShipNameCampaignBehavior()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Expected O, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Expected O, but got Unknown
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Expected O, but got Unknown
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Expected O, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Expected O, but got Unknown
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Expected O, but got Unknown
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected O, but got Unknown
		//IL_05cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Expected O, but got Unknown
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Expected O, but got Unknown
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0641: Expected O, but got Unknown
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Expected O, but got Unknown
		//IL_066d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Expected O, but got Unknown
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected O, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Expected O, but got Unknown
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0701: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Expected O, but got Unknown
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Expected O, but got Unknown
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected O, but got Unknown
		//IL_076d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0781: Expected O, but got Unknown
		//IL_078d: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Expected O, but got Unknown
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected O, but got Unknown
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Expected O, but got Unknown
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Expected O, but got Unknown
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Expected O, but got Unknown
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0841: Expected O, but got Unknown
		//IL_084d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Expected O, but got Unknown
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0881: Expected O, but got Unknown
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Expected O, but got Unknown
		//IL_08ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c1: Expected O, but got Unknown
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected O, but got Unknown
		//IL_08ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0901: Expected O, but got Unknown
		//IL_090d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0921: Expected O, but got Unknown
		//IL_092d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Expected O, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0961: Expected O, but got Unknown
		//IL_096d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0981: Expected O, but got Unknown
		//IL_098d: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c1: Expected O, but got Unknown
		//IL_09cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Expected O, but got Unknown
		//IL_09ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected O, but got Unknown
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a21: Expected O, but got Unknown
		//IL_0a2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Expected O, but got Unknown
		//IL_0a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a61: Expected O, but got Unknown
		//IL_0a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a81: Expected O, but got Unknown
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Expected O, but got Unknown
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Expected O, but got Unknown
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae1: Expected O, but got Unknown
		//IL_0aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b01: Expected O, but got Unknown
		//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b21: Expected O, but got Unknown
		//IL_0b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b41: Expected O, but got Unknown
		//IL_0b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Expected O, but got Unknown
		//IL_0b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba1: Expected O, but got Unknown
		//IL_0bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc1: Expected O, but got Unknown
		//IL_0bcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be1: Expected O, but got Unknown
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c01: Expected O, but got Unknown
		//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c21: Expected O, but got Unknown
		//IL_0c2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c41: Expected O, but got Unknown
		//IL_0c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c61: Expected O, but got Unknown
		//IL_0c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c81: Expected O, but got Unknown
		//IL_0c8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca1: Expected O, but got Unknown
		//IL_0cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Expected O, but got Unknown
		//IL_0ccd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce1: Expected O, but got Unknown
		//IL_0ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d01: Expected O, but got Unknown
		//IL_0d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d21: Expected O, but got Unknown
		//IL_0d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d41: Expected O, but got Unknown
		//IL_0d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d61: Expected O, but got Unknown
		//IL_0d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d81: Expected O, but got Unknown
		//IL_0d8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da1: Expected O, but got Unknown
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc1: Expected O, but got Unknown
		//IL_0dcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de1: Expected O, but got Unknown
		//IL_0ded: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e01: Expected O, but got Unknown
		//IL_0e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e21: Expected O, but got Unknown
		//IL_0e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e41: Expected O, but got Unknown
		//IL_0e4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e61: Expected O, but got Unknown
		//IL_0e6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e81: Expected O, but got Unknown
		//IL_0e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea1: Expected O, but got Unknown
		//IL_0ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec1: Expected O, but got Unknown
		//IL_0ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee1: Expected O, but got Unknown
		//IL_0eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f01: Expected O, but got Unknown
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Expected O, but got Unknown
		//IL_0f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f41: Expected O, but got Unknown
		//IL_0f4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f61: Expected O, but got Unknown
		//IL_0f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f81: Expected O, but got Unknown
		//IL_0f8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa1: Expected O, but got Unknown
		//IL_0fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc1: Expected O, but got Unknown
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe1: Expected O, but got Unknown
		//IL_0fed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1001: Expected O, but got Unknown
		//IL_100d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Expected O, but got Unknown
		//IL_102d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1041: Expected O, but got Unknown
		//IL_104d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1061: Expected O, but got Unknown
		//IL_106d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1081: Expected O, but got Unknown
		//IL_108d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Expected O, but got Unknown
		//IL_10ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c1: Expected O, but got Unknown
		//IL_10cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e1: Expected O, but got Unknown
		//IL_10ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1101: Expected O, but got Unknown
		//IL_110d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1121: Expected O, but got Unknown
		//IL_112d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1141: Expected O, but got Unknown
		//IL_114d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1161: Expected O, but got Unknown
		//IL_116d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Expected O, but got Unknown
		//IL_118d: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a1: Expected O, but got Unknown
		//IL_11ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c1: Expected O, but got Unknown
		//IL_11cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e1: Expected O, but got Unknown
		//IL_11ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1201: Expected O, but got Unknown
		//IL_120d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1221: Expected O, but got Unknown
		//IL_122d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1241: Expected O, but got Unknown
		//IL_124d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1261: Expected O, but got Unknown
		//IL_126d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1281: Expected O, but got Unknown
		//IL_128d: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a1: Expected O, but got Unknown
		//IL_12ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c1: Expected O, but got Unknown
		//IL_12cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e1: Expected O, but got Unknown
		//IL_12ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1301: Expected O, but got Unknown
		//IL_130d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1321: Expected O, but got Unknown
		//IL_132d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1341: Expected O, but got Unknown
		//IL_134d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1361: Expected O, but got Unknown
		//IL_136d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1381: Expected O, but got Unknown
		//IL_138d: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a1: Expected O, but got Unknown
		//IL_13ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c1: Expected O, but got Unknown
		//IL_13cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e1: Expected O, but got Unknown
		//IL_13ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1401: Expected O, but got Unknown
		//IL_140d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1421: Expected O, but got Unknown
		//IL_142d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Expected O, but got Unknown
		//IL_144d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1461: Expected O, but got Unknown
		//IL_146d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1481: Expected O, but got Unknown
		//IL_148d: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a1: Expected O, but got Unknown
		//IL_14ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c1: Expected O, but got Unknown
		//IL_14cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e1: Expected O, but got Unknown
		//IL_14ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1501: Expected O, but got Unknown
		//IL_150d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1521: Expected O, but got Unknown
		//IL_152d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1541: Expected O, but got Unknown
		//IL_154d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1561: Expected O, but got Unknown
		//IL_156d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1581: Expected O, but got Unknown
		//IL_158d: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a1: Expected O, but got Unknown
		//IL_15ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c1: Expected O, but got Unknown
		//IL_15cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e1: Expected O, but got Unknown
		//IL_15ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1601: Expected O, but got Unknown
		//IL_160d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1621: Expected O, but got Unknown
		//IL_162d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1641: Expected O, but got Unknown
		//IL_164d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1661: Expected O, but got Unknown
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1681: Expected O, but got Unknown
		//IL_168d: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a1: Expected O, but got Unknown
		//IL_16ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c1: Expected O, but got Unknown
		//IL_16cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e1: Expected O, but got Unknown
		//IL_16ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1701: Expected O, but got Unknown
		//IL_170d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1721: Expected O, but got Unknown
		//IL_172d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1741: Expected O, but got Unknown
		//IL_174d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1761: Expected O, but got Unknown
		//IL_176d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1781: Expected O, but got Unknown
		//IL_178d: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a1: Expected O, but got Unknown
		//IL_17ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c1: Expected O, but got Unknown
		//IL_17cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e1: Expected O, but got Unknown
		//IL_17ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1801: Expected O, but got Unknown
		//IL_180d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1821: Expected O, but got Unknown
		//IL_182d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1841: Expected O, but got Unknown
		//IL_184d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1861: Expected O, but got Unknown
		//IL_186d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1881: Expected O, but got Unknown
		//IL_188d: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a1: Expected O, but got Unknown
		//IL_18ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c1: Expected O, but got Unknown
		//IL_18cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e1: Expected O, but got Unknown
		//IL_18ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1901: Expected O, but got Unknown
		//IL_190d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1921: Expected O, but got Unknown
		//IL_192d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1941: Expected O, but got Unknown
		//IL_194d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1961: Expected O, but got Unknown
		//IL_196d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1981: Expected O, but got Unknown
		//IL_198d: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a1: Expected O, but got Unknown
		//IL_19ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c1: Expected O, but got Unknown
		//IL_19cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e1: Expected O, but got Unknown
		//IL_19ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a01: Expected O, but got Unknown
		//IL_1a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a21: Expected O, but got Unknown
		//IL_1a2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a41: Expected O, but got Unknown
		//IL_1a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a61: Expected O, but got Unknown
		//IL_1a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a81: Expected O, but got Unknown
		//IL_1a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa1: Expected O, but got Unknown
		//IL_1aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac1: Expected O, but got Unknown
		//IL_1acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae1: Expected O, but got Unknown
		//IL_1aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b01: Expected O, but got Unknown
		//IL_1b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b21: Expected O, but got Unknown
		//IL_1b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b41: Expected O, but got Unknown
		//IL_1b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b61: Expected O, but got Unknown
		//IL_1b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b81: Expected O, but got Unknown
		//IL_1b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba1: Expected O, but got Unknown
		//IL_1bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc1: Expected O, but got Unknown
		//IL_1bcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be1: Expected O, but got Unknown
		//IL_1bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c01: Expected O, but got Unknown
		//IL_1c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c21: Expected O, but got Unknown
		//IL_1c2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c41: Expected O, but got Unknown
		//IL_1c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c61: Expected O, but got Unknown
		//IL_1c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c81: Expected O, but got Unknown
		//IL_1c8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca1: Expected O, but got Unknown
		//IL_1cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc1: Expected O, but got Unknown
		//IL_1ccd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce1: Expected O, but got Unknown
		//IL_1ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d01: Expected O, but got Unknown
		//IL_1d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d21: Expected O, but got Unknown
		//IL_1d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d41: Expected O, but got Unknown
		//IL_1d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d61: Expected O, but got Unknown
		//IL_1d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d81: Expected O, but got Unknown
		//IL_1d8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da1: Expected O, but got Unknown
		//IL_1dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc1: Expected O, but got Unknown
		//IL_1dcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de1: Expected O, but got Unknown
		//IL_1ded: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e01: Expected O, but got Unknown
		//IL_1e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e21: Expected O, but got Unknown
		//IL_1e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e41: Expected O, but got Unknown
		//IL_1e4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e61: Expected O, but got Unknown
		//IL_1e6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e81: Expected O, but got Unknown
		//IL_1e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea1: Expected O, but got Unknown
		//IL_1ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec1: Expected O, but got Unknown
		//IL_1ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee1: Expected O, but got Unknown
		//IL_1eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f01: Expected O, but got Unknown
		//IL_1f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f21: Expected O, but got Unknown
		//IL_1f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f41: Expected O, but got Unknown
		//IL_1f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6c: Expected O, but got Unknown
		//IL_1f78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f87: Expected O, but got Unknown
		//IL_1f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa2: Expected O, but got Unknown
		//IL_1fae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbd: Expected O, but got Unknown
		//IL_1fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd8: Expected O, but got Unknown
		//IL_1fe4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff3: Expected O, but got Unknown
		//IL_1fff: Unknown result type (might be due to invalid IL or missing references)
		//IL_200e: Expected O, but got Unknown
		//IL_201a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2029: Expected O, but got Unknown
		//IL_2035: Unknown result type (might be due to invalid IL or missing references)
		//IL_2044: Expected O, but got Unknown
		//IL_2050: Unknown result type (might be due to invalid IL or missing references)
		//IL_205f: Expected O, but got Unknown
		//IL_206b: Unknown result type (might be due to invalid IL or missing references)
		//IL_207a: Expected O, but got Unknown
		//IL_2086: Unknown result type (might be due to invalid IL or missing references)
		//IL_2095: Expected O, but got Unknown
		//IL_20a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b0: Expected O, but got Unknown
		//IL_20bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cb: Expected O, but got Unknown
		//IL_20d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e6: Expected O, but got Unknown
		//IL_20f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2101: Expected O, but got Unknown
		//IL_210d: Unknown result type (might be due to invalid IL or missing references)
		//IL_211c: Expected O, but got Unknown
		//IL_2128: Unknown result type (might be due to invalid IL or missing references)
		//IL_2137: Expected O, but got Unknown
		//IL_2143: Unknown result type (might be due to invalid IL or missing references)
		//IL_2152: Expected O, but got Unknown
		//IL_215e: Unknown result type (might be due to invalid IL or missing references)
		//IL_216d: Expected O, but got Unknown
		//IL_2179: Unknown result type (might be due to invalid IL or missing references)
		//IL_2188: Expected O, but got Unknown
		//IL_2194: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a3: Expected O, but got Unknown
		//IL_21af: Unknown result type (might be due to invalid IL or missing references)
		//IL_21be: Expected O, but got Unknown
		//IL_21ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d9: Expected O, but got Unknown
		//IL_21e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f4: Expected O, but got Unknown
		//IL_2200: Unknown result type (might be due to invalid IL or missing references)
		//IL_220f: Expected O, but got Unknown
		//IL_221b: Unknown result type (might be due to invalid IL or missing references)
		//IL_222a: Expected O, but got Unknown
		//IL_2236: Unknown result type (might be due to invalid IL or missing references)
		//IL_2245: Expected O, but got Unknown
		//IL_2251: Unknown result type (might be due to invalid IL or missing references)
		//IL_2260: Expected O, but got Unknown
		//IL_226c: Unknown result type (might be due to invalid IL or missing references)
		//IL_227b: Expected O, but got Unknown
		//IL_2287: Unknown result type (might be due to invalid IL or missing references)
		//IL_2296: Expected O, but got Unknown
		//IL_22a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b1: Expected O, but got Unknown
		//IL_22bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_22cc: Expected O, but got Unknown
		//IL_22d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e7: Expected O, but got Unknown
		//IL_22f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2302: Expected O, but got Unknown
		//IL_230e: Unknown result type (might be due to invalid IL or missing references)
		//IL_231d: Expected O, but got Unknown
		//IL_2329: Unknown result type (might be due to invalid IL or missing references)
		//IL_2338: Expected O, but got Unknown
		//IL_2344: Unknown result type (might be due to invalid IL or missing references)
		//IL_2353: Expected O, but got Unknown
		//IL_235f: Unknown result type (might be due to invalid IL or missing references)
		//IL_236e: Expected O, but got Unknown
		//IL_237a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2389: Expected O, but got Unknown
		//IL_2395: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a4: Expected O, but got Unknown
		//IL_23b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_23bf: Expected O, but got Unknown
		//IL_23cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_23da: Expected O, but got Unknown
		//IL_23e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f5: Expected O, but got Unknown
		//IL_2401: Unknown result type (might be due to invalid IL or missing references)
		//IL_2410: Expected O, but got Unknown
		//IL_241c: Unknown result type (might be due to invalid IL or missing references)
		//IL_242b: Expected O, but got Unknown
		//IL_2437: Unknown result type (might be due to invalid IL or missing references)
		//IL_2446: Expected O, but got Unknown
		//IL_2452: Unknown result type (might be due to invalid IL or missing references)
		//IL_2461: Expected O, but got Unknown
		//IL_246d: Unknown result type (might be due to invalid IL or missing references)
		//IL_247c: Expected O, but got Unknown
		//IL_2488: Unknown result type (might be due to invalid IL or missing references)
		//IL_2497: Expected O, but got Unknown
		//IL_24a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b2: Expected O, but got Unknown
		//IL_24be: Unknown result type (might be due to invalid IL or missing references)
		//IL_24cd: Expected O, but got Unknown
		//IL_24d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e8: Expected O, but got Unknown
		//IL_24f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2503: Expected O, but got Unknown
		//IL_250f: Unknown result type (might be due to invalid IL or missing references)
		//IL_251e: Expected O, but got Unknown
		//IL_252a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2539: Expected O, but got Unknown
		//IL_2545: Unknown result type (might be due to invalid IL or missing references)
		//IL_2554: Expected O, but got Unknown
		//IL_2560: Unknown result type (might be due to invalid IL or missing references)
		//IL_256f: Expected O, but got Unknown
		//IL_257b: Unknown result type (might be due to invalid IL or missing references)
		//IL_258a: Expected O, but got Unknown
		//IL_2596: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a5: Expected O, but got Unknown
		//IL_25b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25c0: Expected O, but got Unknown
		//IL_25cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_25db: Expected O, but got Unknown
		//IL_25e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f6: Expected O, but got Unknown
		//IL_2602: Unknown result type (might be due to invalid IL or missing references)
		//IL_2611: Expected O, but got Unknown
		//IL_261d: Unknown result type (might be due to invalid IL or missing references)
		//IL_262c: Expected O, but got Unknown
		//IL_2638: Unknown result type (might be due to invalid IL or missing references)
		//IL_2647: Expected O, but got Unknown
		//IL_2653: Unknown result type (might be due to invalid IL or missing references)
		//IL_2662: Expected O, but got Unknown
		//IL_266e: Unknown result type (might be due to invalid IL or missing references)
		//IL_267d: Expected O, but got Unknown
		//IL_2689: Unknown result type (might be due to invalid IL or missing references)
		//IL_2698: Expected O, but got Unknown
		//IL_26a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_26b3: Expected O, but got Unknown
		//IL_26bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ce: Expected O, but got Unknown
		//IL_26da: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e9: Expected O, but got Unknown
		//IL_26f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2704: Expected O, but got Unknown
		//IL_2710: Unknown result type (might be due to invalid IL or missing references)
		//IL_271f: Expected O, but got Unknown
		//IL_272b: Unknown result type (might be due to invalid IL or missing references)
		//IL_273a: Expected O, but got Unknown
		//IL_2746: Unknown result type (might be due to invalid IL or missing references)
		//IL_2755: Expected O, but got Unknown
		//IL_2761: Unknown result type (might be due to invalid IL or missing references)
		//IL_2770: Expected O, but got Unknown
		//IL_277c: Unknown result type (might be due to invalid IL or missing references)
		//IL_278b: Expected O, but got Unknown
		//IL_2797: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a6: Expected O, but got Unknown
		//IL_27b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c1: Expected O, but got Unknown
		//IL_27cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_27dc: Expected O, but got Unknown
		//IL_27e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f7: Expected O, but got Unknown
		//IL_2803: Unknown result type (might be due to invalid IL or missing references)
		//IL_2812: Expected O, but got Unknown
		//IL_281e: Unknown result type (might be due to invalid IL or missing references)
		//IL_282d: Expected O, but got Unknown
		//IL_2839: Unknown result type (might be due to invalid IL or missing references)
		//IL_2848: Expected O, but got Unknown
		//IL_2854: Unknown result type (might be due to invalid IL or missing references)
		//IL_2863: Expected O, but got Unknown
		//IL_286f: Unknown result type (might be due to invalid IL or missing references)
		//IL_287e: Expected O, but got Unknown
		//IL_288a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2899: Expected O, but got Unknown
		//IL_28a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b4: Expected O, but got Unknown
		//IL_28c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_28cf: Expected O, but got Unknown
		//IL_28db: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ea: Expected O, but got Unknown
		//IL_28f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2905: Expected O, but got Unknown
		//IL_2911: Unknown result type (might be due to invalid IL or missing references)
		//IL_2920: Expected O, but got Unknown
		//IL_292c: Unknown result type (might be due to invalid IL or missing references)
		//IL_293b: Expected O, but got Unknown
		//IL_2947: Unknown result type (might be due to invalid IL or missing references)
		//IL_2956: Expected O, but got Unknown
		//IL_2962: Unknown result type (might be due to invalid IL or missing references)
		//IL_2971: Expected O, but got Unknown
		//IL_297d: Unknown result type (might be due to invalid IL or missing references)
		//IL_298c: Expected O, but got Unknown
		//IL_2998: Unknown result type (might be due to invalid IL or missing references)
		//IL_29a7: Expected O, but got Unknown
		//IL_29b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_29c2: Expected O, but got Unknown
		//IL_29ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_29dd: Expected O, but got Unknown
		//IL_29e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f8: Expected O, but got Unknown
		//IL_2a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a13: Expected O, but got Unknown
		//IL_2a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a2e: Expected O, but got Unknown
		//IL_2a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a49: Expected O, but got Unknown
		//IL_2a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a64: Expected O, but got Unknown
		//IL_2a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a7f: Expected O, but got Unknown
		//IL_2a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a9a: Expected O, but got Unknown
		//IL_2aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab5: Expected O, but got Unknown
		//IL_2ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ad0: Expected O, but got Unknown
		//IL_2adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aeb: Expected O, but got Unknown
		//IL_2af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b06: Expected O, but got Unknown
		//IL_2b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b21: Expected O, but got Unknown
		//IL_2b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b3c: Expected O, but got Unknown
		//IL_2b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b57: Expected O, but got Unknown
		//IL_2b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b72: Expected O, but got Unknown
		//IL_2b7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b8d: Expected O, but got Unknown
		//IL_2b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba8: Expected O, but got Unknown
		//IL_2bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bc3: Expected O, but got Unknown
		_fullNames = new MBReadOnlyList<(TextObject, NameTrait, float)>((IEnumerable<(TextObject, NameTrait, float)>)new List<(TextObject, NameTrait, float)>
		{
			(new TextObject("{=p4zJbD3a}Righteous {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=EQHW6TPk}Glorious {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=FUMvrsE2}Angelic {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=obOVM8pM}Holy {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=N6CT6M1E}Sacred {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=M1Q36S4d}Divine {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=GYiAqvCR}Enduring {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=oIG8QbiK}Invincible {NAME}", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=3VaHDxBO}{NAME} of the Senate", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 4f),
			(new TextObject("{=RrI6uJAN}Royal {NAME}", (Dictionary<string, object>)null), NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=NT9EcONe}King's {NAME}", (Dictionary<string, object>)null), NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=IQ1Q0ncJ}Sable {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=LTa1b6T1}Crimson {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=l1Rs5EKR}Scarlet {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=aaYhWD7n}Azure {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=IgPHnuWN}Red {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 4f),
			(new TextObject("{=IgPHnuWN}Red {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=IgPHnuWN}Red {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade, 4f),
			(new TextObject("{=DqMfR4H9}Green {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 4f),
			(new TextObject("{=DqMfR4H9}Green {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=DqMfR4H9}Green {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade, 4f),
			(new TextObject("{=rqlsyT28}Golden {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 4f),
			(new TextObject("{=rqlsyT28}Golden {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=rqlsyT28}Golden {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade, 4f),
			(new TextObject("{=WDuVTmua}Black {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 4f),
			(new TextObject("{=WDuVTmua}Black {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=WDuVTmua}Black {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade, 4f),
			(new TextObject("{=YCHKJWPH}Silver {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 4f),
			(new TextObject("{=YCHKJWPH}Silver {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=YCHKJWPH}Silver {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade, 4f),
			(new TextObject("{=vseUmK09}Gray {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 4f),
			(new TextObject("{=vseUmK09}Gray {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=vseUmK09}Gray {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade, 4f),
			(new TextObject("{=4W6VIFQy}White {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 4f),
			(new TextObject("{=4W6VIFQy}White {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=4W6VIFQy}White {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade, 4f),
			(new TextObject("{=5h7uC3ea}Sea {NAME}", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Heavy, 4f),
			(new TextObject("{=T6M299YZ}Iron {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Khuzait | NameTrait.Heavy, 4f),
			(new TextObject("{=vBBVysYn}Bronze {NAME}", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Khuzait | NameTrait.Heavy, 4f),
			(new TextObject("{=YK07f3P5}{NAME} of the Ice", (Dictionary<string, object>)null), NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=MmJLmoTG}{NAME} of the North Wind", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=vGOdCk10}{NAME} of the West Wind", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=Gv8QS2ir}{NAME} of the South Wind", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=GUGb3elb}{NAME} of the Desert Wind", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 4f),
			(new TextObject("{=DDO8zNWb}{NAME} of the Steppe Wind", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=errJ9sPD}{NAME} of the East Wind", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=C5eXktem}{NAME} of the Tempest", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=PPxkvzaI}{NAME} of the Seven Seas", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=aBpPqNSV}{NAME} of the Oceans", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=o4f2am1S}{NAME} of the Four Winds", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=zGXMh3cK}{NAME} of the Summer Wind", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=7wacHLoB}{NAME} of the Monsoons", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 4f),
			(new TextObject("{=Sr5g7eGT}{NAME} of the Hidden Isles", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=2bpDbXgH}{NAME} of the Southern Isles", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=vaKsHBk4}{NAME} of the Jade Sea", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 4f),
			(new TextObject("{=X2hW2ZK8}{NAME} of the Lysian Gates", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=7SNvOuJZ}{NAME} of the Perfumed Isles", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=8nOygNES}{NAME} of the North Star", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=jXkBO9cE}{NAME} of the Southern Stars", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 4f),
			(new TextObject("{=YdrcIKM4}{NAME} of the Evening Star", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=KHvKnQlq}{NAME} of Balion", (Dictionary<string, object>)null), NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=D1FhdIi9}{NAME} of Geroia", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=BoahRhBP}{NAME} of the Biscan", (Dictionary<string, object>)null), NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=upUpjeLB}{NAME} of Charas", (Dictionary<string, object>)null), NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=AkL8Au7C}{NAME} of Vostrum", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=1a7vKHgp}{NAME} of Zeonica", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Trade, 4f),
			(new TextObject("{=1FIatE6X}{NAME} of Ostican", (Dictionary<string, object>)null), NameTrait.Vlandia | NameTrait.Trade, 4f),
			(new TextObject("{=RFus9sqB}Ouroboros", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=boyQwJ1m}Houndfish", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=lTbqQ9bz}Dogfish", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=jQpgsw8r}Swordfish", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Vlandia, 1f),
			(new TextObject("{=87bHj9A2}Sawfish", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire, 1f),
			(new TextObject("{=27YBAeBC}Blackfish", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=Rq9LsTZd}Codfish", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Trade, 1f),
			(new TextObject("{=9awY7d7g}Mergus", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Vlandia | NameTrait.Trade, 1f),
			(new TextObject("{=W1UHaqXn}Storm-Petrel", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=9YgoQgfF}Mermaid", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 1f),
			(new TextObject("{=ObA0FlxH}Golden Mermaid", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade, 1f),
			(new TextObject("{=7fvh1EnT}Silver Mermaid", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Trade, 1f),
			(new TextObject("{=lGJttwHt}Golden Dromedary", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 1f),
			(new TextObject("{=1IBdhv6m}White Dromedary", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 1f),
			(new TextObject("{=bGZjuUDa}Black Dromedary", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 1f),
			(new TextObject("{=AYMp00V6}Camel of the Nahasa", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade, 1f),
			(new TextObject("{=bKIfIrpa}Fighting Cockerel", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=aPhXFPcT}Red Rooster", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=WJX03gKf}Golden Eel", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=aBveRvWW}Silver Eel", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Sturgia | NameTrait.Vlandia, 1f),
			(new TextObject("{=UDgMFtzL}Moray Eel", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Vlandia, 1f),
			(new TextObject("{=xQi4P54b}Beluga", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia, 1f),
			(new TextObject("{=sTEQvac6}Kraken", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=MsLvZKOY}Stingray", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire, 1f),
			(new TextObject("{=5R17a1JM}Lobster", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Trade, 1f),
			(new TextObject("{=dOGq1Kna}Mullet", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Trade, 1f),
			(new TextObject("{=pTEJQmFt}Mackerel", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Vlandia, 1f),
			(new TextObject("{=7hp485w6}Herring", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Trade, 1f),
			(new TextObject("{=z7K50H9r}Albacore", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade, 1f),
			(new TextObject("{=9u7Xc1Ut}Senate and People", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=vLmdGlBp}Thalassarch", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=9AiyiCb1}Great Tethys", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=fXHy3mOb}Might of Cetus", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=6Cdlb2cd}Banner of Calradios", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=868vxgZt}Sun of Alixenios", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=YlOkpsf8}Autokrator", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=fupLwOHL}Vasileos", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=JxZ5IMJp}Princess Sarpea", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=ghoX4M9O}Mount Aracathos", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=uKvTvMP4}Mount Erithrys", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=Gn4eEJOa}Wrath of Typhon", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=6LlLXwOR}Smile of Akhileos", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=qQpwMEVO}Revenge of Serapeos", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=FYmdME8j}Transtemean Wind", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=MBAesOd0}Zeonic Wind", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=7sqi9P0w}Zephyr", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=cVbeR6AW}Lycanthropos", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=ACzfQv3T}Vrykolakas", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=0jgcowNU}Nereid", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=0RUL4jh8}Lamia", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=9Pr1gVrR}Myrmidon", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=RDKUfi9l}Hippalectryon", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire, 1f),
			(new TextObject("{=Qn2xEoOz}Scourge of the Barbarians", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=VNtVAxQF}Tamer of the Myzead", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=H1rQdt0h}Subduer of the Perassic", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy, 1f),
			(new TextObject("{=FNcuiONh}Sea Tsar", (Dictionary<string, object>)null), NameTrait.Sturgia | NameTrait.Heavy, 1f),
			(new TextObject("{=840RUJwg}Bogatyr", (Dictionary<string, object>)null), NameTrait.Sturgia | NameTrait.Heavy, 1f),
			(new TextObject("{=Xbr5wKmo}Archangel", (Dictionary<string, object>)null), NameTrait.Sturgia | NameTrait.Heavy, 1f),
			(new TextObject("{=eSbZi6xs}Moryana", (Dictionary<string, object>)null), NameTrait.Sturgia | NameTrait.Heavy, 1f),
			(new TextObject("{=wUrg3H2w}Chernobog's Laughter", (Dictionary<string, object>)null), NameTrait.Sturgia | NameTrait.Heavy, 1f),
			(new TextObject("{=V1t5aRMl}Stallion of Tyal", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia | NameTrait.Heavy, 1f),
			(new TextObject("{=p4OZyYgh}Vodyanoy", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia, 1f),
			(new TextObject("{=U1Qn1JZM}Karakaz", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia, 1f),
			(new TextObject("{=8zEWkLAE}Rusalka", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia, 1f),
			(new TextObject("{=dQwETpdC}Scythe of Nav", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia, 1f),
			(new TextObject("{=7ASz5f1a}Bear of Velos", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Sturgia, 1f),
			(new TextObject("{=Ciat3lsP}Mandate of the Great Sky", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Heavy, 1f),
			(new TextObject("{=TmUmadhP}Sons of the She-Wolf", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Heavy, 1f),
			(new TextObject("{=DrsB9HMG}Will of the Kurultai", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Heavy, 1f),
			(new TextObject("{=u51uZVjs}Arrow of Urkhun", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Heavy, 1f),
			(new TextObject("{=aCocYZSt}Steed of the Ultaiga", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=zjZpbQ1z}Gift of Bura Khan", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Heavy, 1f),
			(new TextObject("{=LUnfNHnM}Sword of Matyr", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=iPSzZd9B}Shyngay's Delight", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=aN2WQlbB}Sign of Ulgen", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Heavy, 1f),
			(new TextObject("{=gm5hsK25}Fury of Erlik", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=QSw6aJGV}Blessing of Ulukayin", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=qXb7YoGc}Asaligat", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=K4XxeGbc}Tulpar", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=Q33lWCaj}Talon of the Zilant", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=LGCKTQy2}Konrul", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=ofecuaPj}Guiding Star", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=RUv05qsg}Light of Dawn", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=xmz9r8P1}Wind Horse", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=5bv0Hc84}Storm-Spirit", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=C0fTWQGk}Ironskin", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=aBtcQVtm}Simurgh", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait, 1f),
			(new TextObject("{=LtGauLC1}Sigil of Queen Eshora", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=woCajT5W}Consort of Tiamat", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=2ReQJtZI}Invincible Sun", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=WAwkgdCj}Feather of Truth", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=P4IE7fXb}Lamassu", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=DKz1aPbN}Warding Hand", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=Z1x9wz33}Steed of Asera", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=cdmwGRa4}Haboob", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=5aFO3p3l}Simoom", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=q5Lfs1qS}Ghibli", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=KgSyBBFP}Pharaoh's Eye", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=oHPSr4VW}Khamsin", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=o1RLBGsT}Golden Rukh", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=TZ5CIXBH}Rukh's Talons", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=SaiEuTfS}Bird of Jebel Qaf", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=tnDzXWd5}Whirlwind", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=PWZQUadt}Moon Upon Clouds", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=nJBxI8hg}Anqa of the Sunset", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Heavy, 1f),
			(new TextObject("{=VPevzPsM}Saluqi Hound", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=yE3Y8IO8}Ghula's Kiss", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=no4fOW8Y}Water of Ziram", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=9aozS6Mk}Lord of the Horns", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=0jnH1Uza}Djinn-King", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=5jeB6Sxa}Djinn's Cavalcade", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=6JqD7i7C}Blue Flame", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=oHeJRau1}Breath of the Djinn", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=SgBaUv2r}Red Planet", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=5fFzNCdZ}Malaq's Defiance", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=pYhlkp70}Raging Hamadryas", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=Q4sO8AZd}Nahasawi", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai, 1f),
			(new TextObject("{=QHft3oRr}Rock of Glanys", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Heavy, 1f),
			(new TextObject("{=vYLbwCeF}Battle-Howl of Curlac", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Heavy, 1f),
			(new TextObject("{=gJ8JqhaQ}Mare of Eria", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Heavy, 1f),
			(new TextObject("{=imQbR7Cg}Boar of Torc Lugh", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Heavy, 1f),
			(new TextObject("{=nATHwmtR}Queen Tara", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Heavy, 1f),
			(new TextObject("{=SZPRJAAf}Bull of Cul", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Heavy, 1f),
			(new TextObject("{=LNDMIMVb}Lir's Wrath", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania, 1f),
			(new TextObject("{=tUvmEb8T}Dornal of the Harp", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania, 1f),
			(new TextObject("{=eHZguHKP}Hound of the Otherworld", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania, 1f),
			(new TextObject("{=AdNm9ieF}Bellow of Tryth", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania, 1f),
			(new TextObject("{=NLQvMD8L}Ark of the Gal", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania, 1f),
			(new TextObject("{=IpVZvz06}Shriek of Cathern", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania, 1f),
			(new TextObject("{=he6PPJIv}Ocean-Steed", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=Ln6EAz7S}Wave-Breaker", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=QRbebVR6}Salt Mare", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=1ybOm0PV}Woe-Bringer", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=tCzb3orN}Widow-Maker", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=Xj2dvQZe}Barrow-Filler", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=4FIUt3SN}Ran's Doorman", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=Wr1aXEU6}Hull-Biter", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=cba5bHbj}Stormcrow", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=yqBo2714}Gale-Rider", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=eV8ZaxVK}Eel-Feeder", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=n2c3mOar}Oaken Serpent", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=2o9iEiZD}Naglfar-Builder", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=5vRL70It}Devouring Wolf", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=nGUBW6v0}Fryr's Pocket-Contents", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=O3HM2T4Y}Corpse-Forger", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=5mxFBDao}Wind's Teeth", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=5bo6R8Pj}Bloody Wake", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=rMFwEIBG}Terror's Envoy", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=GF8NI4ak}Scythe of Men", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=b4dbbGSO}Foe-Scatterer", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=gazxad3b}Death's Harbringer", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=y8t3Hbq0}Breath-Quencher", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=d0ribjEv}Hralnar's Bane", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=4lCPiaXb}Utgard's Joke", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=uCCz0lIr}Keel-Snapper", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=qfmqjQVg}Draugr", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=u8xi68be}Frost-Giant", (Dictionary<string, object>)null), NameTrait.Nord | NameTrait.Heavy, 1f),
			(new TextObject("{=2ZLW2bGS}Steed of the Whale-Road", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Nord | NameTrait.Heavy | NameTrait.Trade, 1f),
			(new TextObject("{=1gVLf0pN}Ale-Cask", (Dictionary<string, object>)null), NameTrait.Nord | NameTrait.Trade, 1f),
			(new TextObject("{=vwV4IPbX}Rorqual", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=yFOn97b1}Cachalot", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=oil0bod6}Wyvern", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=Zp0vicNN}Salamander", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=TcNaPjpT}Basilisk", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=cvQAbYTz}Cameleopard", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=Ob41ouaL}Draconopedes", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=nX3uZGNy}Jackdaw", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=JqzQyz4P}Manticore", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=5rBfXrWW}Zedrosis", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=G9gL45wV}Hippocampus", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=AvdcY9xx}Porbeagle", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=B2jB58ID}Gatopard", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=buCTTnvU}Bold Vilund", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=dVOdKBvE}Good King Bonneric", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=0YhJD3ei}Worthy Rotbard", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=miaiftLB}Paladin Aganalt", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=oEuc40lO}Loyal Gundelm", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=Q0U5s3wP}Bayard", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=OyoWQKCf}Vigilant", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=T5LYBako}Pale Horseman", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=XiND8dN3}Saucy Gallard", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia | NameTrait.Heavy, 1f),
			(new TextObject("{=RBKgTtug}Cunning Tarsil", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f),
			(new TextObject("{=MBypc4Tk}Alerion-Bird", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Vlandia, 1f)
		});
		_firstNames = new MBReadOnlyList<(TextObject, NameTrait)>((IEnumerable<(TextObject, NameTrait)>)new List<(TextObject, NameTrait)>
		{
			(new TextObject("{=n4V81LNV}Jackal", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Khuzait),
			(new TextObject("{=R8I4QRvS}Gazelle", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=Llbz2iqf}Leopard", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Khuzait),
			(new TextObject("{=oshK5hAJ}Panther", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=oe6XS1cg}Hound", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=lG0KHx9d}Lynx", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=eo1F3Ghs}Cheetah", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai),
			(new TextObject("{=mdFJonjK}Ibex", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai),
			(new TextObject("{=wRtDPT3i}Falcon", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=AUaUGDaS}Kestrel", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=aSuWXMiM}Eagle", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Vlandia),
			(new TextObject("{=4dDCLq6Y}Ostrich", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=NVKwvl1G}Raven", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=VKFTub9a}Hawk", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Vlandia),
			(new TextObject("{=3dFnXRau}Heron", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=aSuWXMiM}Eagle", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=spgbMr1c}Parrot", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=4D0Y25hE}Owl", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=6RvO9UVG}Serpent", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire),
			(new TextObject("{=LTOaBiw3}Viper", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=usWAF8Wz}Asp", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Khuzait),
			(new TextObject("{=MbwwhiBo}Wolf", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=jjLUSzAk}Fox", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=ZQ4yL6gm}Hind", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=GUZRA5FT}Mare", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=TamM3Dpt}Unicorn", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=MbwwhiBo}Wolf", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=v4IDh2rE}Ghost", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Battania | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=shipNameRam}Ram", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai),
			(new TextObject("{=C5bsSTdu}Witch", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=TvbM2SMy}Centaur", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire),
			(new TextObject("{=jINLipTa}Scorpion", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=xerBRVAL}Wasp", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=IM1Fbb2V}Hornet", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=sxkwm8qn}Palmatian", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire),
			(new TextObject("{=PnfGEvfu}Canterion", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire),
			(new TextObject("{=nIfwtTXx}Ibis", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire),
			(new TextObject("{=hLqXTb5N}Badger", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Empire | NameTrait.Sturgia | NameTrait.Vlandia),
			(new TextObject("{=0bjYJLMo}Ferret", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Empire),
			(new TextObject("{=cqPflDvo}Pelican", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=cqPflDvo}Pelican", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=1TBEbQbp}Dolphin", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=1TBEbQbp}Dolphin", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=S51n3cnJ}Gull", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=S51n3cnJ}Gull", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=ZTfLT4dD}Cormorant", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=ZTfLT4dD}Cormorant", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=Ludz63ZI}Albatross", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=Ludz63ZI}Albatross", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=dqD0HRje}Osprey", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=dqD0HRje}Osprey", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=tqgCWg4i}Marlin", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=nFFRwbCy}Barracuda", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia),
			(new TextObject("{=39zy02Jd}Hare", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=iW7EXqiS}Roebuck", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=Zyi2ILYy}Antelope", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=o61Aevoo}Spoonbill", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Trade),
			(new TextObject("{=96uWB0JQ}Kingfisher", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=ZgVtOLFQ}Otter", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=LivxbamB}Marten", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=xpWEXt4K}Heifer", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=ZSA1mySL}Swan", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Battania | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=ZQ4yL6gm}Hind", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Trade),
			(new TextObject("{=8Aa4J5VU}Bear", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Khuzait | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=sRGUcmGT}Buffalo", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Heavy | NameTrait.Trade),
			(new TextObject("{=ecbh2GPS}Stallion", (Dictionary<string, object>)null), NameTrait.LightAndMedium | NameTrait.Aserai | NameTrait.Khuzait | NameTrait.Sturgia | NameTrait.Heavy),
			(new TextObject("{=0OrIliBh}Boar", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=gXKRAWmN}Behemoth", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=0bR3n4TR}Leviathan", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=GkvX7z6Y}Dragon", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Nord | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=iB1OFdgG}Troll", (Dictionary<string, object>)null), NameTrait.Nord | NameTrait.Heavy),
			(new TextObject("{=cfn3pbPM}Giant", (Dictionary<string, object>)null), NameTrait.Nord | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=LeN5ab67}Griffin", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=lZJGAUmb}Crocodile", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=nEIeg8bj}Wyrm", (Dictionary<string, object>)null), NameTrait.Nord | NameTrait.Heavy),
			(new TextObject("{=1EUJ4F5o}Bull", (Dictionary<string, object>)null), NameTrait.Battania | NameTrait.Khuzait | NameTrait.Nord | NameTrait.Heavy),
			(new TextObject("{=D0SX1cFQ}Lion", (Dictionary<string, object>)null), NameTrait.Khuzait | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=VMaalDyk}Elephant", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Khuzait | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=54SsKRD0}Walrus", (Dictionary<string, object>)null), NameTrait.Nord | NameTrait.Sturgia | NameTrait.Heavy | NameTrait.Trade),
			(new TextObject("{=8qMm3VIB}Majesty", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=aoY4ekls}Imperium", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=MWUzIGTJ}Destiny", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=uUEvDtIY}Wrath", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=4yqIAUZa}Concord", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=azoX77Hp}Wisdom", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=nrkcgic9}Triumph", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=BvD7h8gD}Mandate", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=YIStPMzW}Justice", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=nVhc43US}Guardian", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=9KPCUcTL}Sovereignty", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Heavy),
			(new TextObject("{=shipNameFury}Fury", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=f5WWBvGQ}Splendor", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Heavy),
			(new TextObject("{=v5dpjybs}Bounty", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=L3bOOJ7Q}Treasure", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=Zpds5B8d}Chalice", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=WxxVi13T}Pearl", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=FPyhdxJl}Jewel", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=yW3FevJR}Diamond", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=bUNpw29g}Emerald", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=MnzHURUf}Fortune", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=G9zmdS4J}Blessing", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=oMP4RhpF}Luck", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=BMm6tsRm}Princess", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=smlzWHsW}Maiden", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=eodelMzf}Lady", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=SHWI20zH}Queen", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=4TKA4kbv}Bride", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=ZAbwnp54}Fragrance", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=FLa5OuyK}Wanderer", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=xKXE1YrD}Pilgrim", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Sturgia | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=KTYNd9ps}Angel", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=JS17OAwM}Beacon", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=f8b5go27}Flower", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade),
			(new TextObject("{=jLcl52Vw}Rose", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=7EUZITUE}Lotus", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Trade),
			(new TextObject("{=wJRNbgRJ}Jasmine", (Dictionary<string, object>)null), NameTrait.Aserai | NameTrait.Empire | NameTrait.Trade),
			(new TextObject("{=oKLSbtdr}Lily", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade),
			(new TextObject("{=6hdP6O2N}Nymph", (Dictionary<string, object>)null), NameTrait.Empire | NameTrait.Vlandia | NameTrait.Trade)
		});
		((CampaignBehaviorBase)this)._002Ector();
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NavalDLC.CustomBattle.CustomBattle.SelectionItem;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.CustomBattle.CustomBattle;

public class NavalCustomBattleMapSelectionGroupVM : ViewModel
{
	private List<NavalCustomBattleMapItemVM> _customNavalBattleMaps;

	private List<NavalCustomBattleMapItemVM> _customNavalRaidMaps;

	private List<NavalCustomBattleMapItemVM> _availableMaps;

	private SelectorVM<NavalCustomBattleMapItemVM> _mapSelection;

	private SelectorVM<NavalCustomBattleSeasonItemVM> _seasonSelection;

	private SelectorVM<NavalCustomBattleTimeOfDayItemVM> _timeOfDaySelection;

	private SelectorVM<NavalCustomBattleWindStrengthItemVM> _windStrengthSelection;

	private SelectorVM<NavalCustomBattleWindDirectionItemVM> _windDirectionSelection;

	private string _titleText;

	private string _mapText;

	private string _seasonText;

	private string _timeOfDayText;

	private string _windStrengthText;

	private string _windDirectionText;

	private bool _isRaid;

	public int SelectedTimeOfDay { get; private set; }

	public float SelectedWindStrength { get; private set; }

	public NavalCustomBattleWindConfig.Direction SelectedWindDirection { get; private set; }

	public string SelectedSeasonId { get; private set; }

	public NavalCustomBattleMapItemVM SelectedMap { get; private set; }

	[DataSourceProperty]
	public SelectorVM<NavalCustomBattleMapItemVM> MapSelection
	{
		get
		{
			return _mapSelection;
		}
		set
		{
			if (value != _mapSelection)
			{
				_mapSelection = value;
				((ViewModel)this).OnPropertyChangedWithValue<SelectorVM<NavalCustomBattleMapItemVM>>(value, "MapSelection");
			}
		}
	}

	[DataSourceProperty]
	public SelectorVM<NavalCustomBattleSeasonItemVM> SeasonSelection
	{
		get
		{
			return _seasonSelection;
		}
		set
		{
			if (value != _seasonSelection)
			{
				_seasonSelection = value;
				((ViewModel)this).OnPropertyChangedWithValue<SelectorVM<NavalCustomBattleSeasonItemVM>>(value, "SeasonSelection");
			}
		}
	}

	[DataSourceProperty]
	public SelectorVM<NavalCustomBattleTimeOfDayItemVM> TimeOfDaySelection
	{
		get
		{
			return _timeOfDaySelection;
		}
		set
		{
			if (value != _timeOfDaySelection)
			{
				_timeOfDaySelection = value;
				((ViewModel)this).OnPropertyChangedWithValue<SelectorVM<NavalCustomBattleTimeOfDayItemVM>>(value, "TimeOfDaySelection");
			}
		}
	}

	[DataSourceProperty]
	public SelectorVM<NavalCustomBattleWindStrengthItemVM> WindStrengthSelection
	{
		get
		{
			return _windStrengthSelection;
		}
		set
		{
			if (value != _windStrengthSelection)
			{
				_windStrengthSelection = value;
				((ViewModel)this).OnPropertyChangedWithValue<SelectorVM<NavalCustomBattleWindStrengthItemVM>>(value, "WindStrengthSelection");
			}
		}
	}

	[DataSourceProperty]
	public SelectorVM<NavalCustomBattleWindDirectionItemVM> WindDirectionSelection
	{
		get
		{
			return _windDirectionSelection;
		}
		set
		{
			if (value != _windDirectionSelection)
			{
				_windDirectionSelection = value;
				((ViewModel)this).OnPropertyChangedWithValue<SelectorVM<NavalCustomBattleWindDirectionItemVM>>(value, "WindDirectionSelection");
			}
		}
	}

	[DataSourceProperty]
	public string TitleText
	{
		get
		{
			return _titleText;
		}
		set
		{
			if (value != _titleText)
			{
				_titleText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "TitleText");
			}
		}
	}

	[DataSourceProperty]
	public string MapText
	{
		get
		{
			return _mapText;
		}
		set
		{
			if (value != _mapText)
			{
				_mapText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "MapText");
			}
		}
	}

	[DataSourceProperty]
	public string SeasonText
	{
		get
		{
			return _seasonText;
		}
		set
		{
			if (value != _seasonText)
			{
				_seasonText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "SeasonText");
			}
		}
	}

	[DataSourceProperty]
	public string TimeOfDayText
	{
		get
		{
			return _timeOfDayText;
		}
		set
		{
			if (value != _timeOfDayText)
			{
				_timeOfDayText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "TimeOfDayText");
			}
		}
	}

	[DataSourceProperty]
	public string WindStrengthText
	{
		get
		{
			return _windStrengthText;
		}
		set
		{
			if (value != _windStrengthText)
			{
				_windStrengthText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "WindStrengthText");
			}
		}
	}

	[DataSourceProperty]
	public string WindDirectionText
	{
		get
		{
			return _windDirectionText;
		}
		set
		{
			if (value != _windDirectionText)
			{
				_windDirectionText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "WindDirectionText");
			}
		}
	}

	[DataSourceProperty]
	public bool IsRaid
	{
		get
		{
			return _isRaid;
		}
		set
		{
			if (value != _isRaid)
			{
				_isRaid = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "IsRaid");
			}
		}
	}

	public NavalCustomBattleMapSelectionGroupVM()
	{
		_customNavalBattleMaps = new List<NavalCustomBattleMapItemVM>();
		_customNavalRaidMaps = new List<NavalCustomBattleMapItemVM>();
		_availableMaps = _customNavalBattleMaps;
		MapSelection = new SelectorVM<NavalCustomBattleMapItemVM>(0, (Action<SelectorVM<NavalCustomBattleMapItemVM>>)OnMapSelection);
		SeasonSelection = new SelectorVM<NavalCustomBattleSeasonItemVM>(0, (Action<SelectorVM<NavalCustomBattleSeasonItemVM>>)OnSeasonSelection);
		TimeOfDaySelection = new SelectorVM<NavalCustomBattleTimeOfDayItemVM>(0, (Action<SelectorVM<NavalCustomBattleTimeOfDayItemVM>>)OnTimeOfDaySelection);
		WindStrengthSelection = new SelectorVM<NavalCustomBattleWindStrengthItemVM>(0, (Action<SelectorVM<NavalCustomBattleWindStrengthItemVM>>)OnWindStrengthSelection);
		WindDirectionSelection = new SelectorVM<NavalCustomBattleWindDirectionItemVM>(0, (Action<SelectorVM<NavalCustomBattleWindDirectionItemVM>>)OnWindDirectionSelection);
		((ViewModel)this).RefreshValues();
	}

	public override void RefreshValues()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		((ViewModel)this).RefreshValues();
		_customNavalBattleMaps.Clear();
		_customNavalRaidMaps.Clear();
		foreach (NavalCustomBattleSceneData customNavalBattleScene in NavalCustomGame.Current.CustomNavalBattleScenes)
		{
			NavalCustomBattleMapItemVM item = new NavalCustomBattleMapItemVM(((object)customNavalBattleScene.Name).ToString(), customNavalBattleScene.SceneID, customNavalBattleScene.Terrain, customNavalBattleScene.ForcedSceneLevel);
			_customNavalBattleMaps.Add(item);
		}
		foreach (NavalCustomBattleSceneData customNavalRaidScene in NavalCustomGame.Current.CustomNavalRaidScenes)
		{
			NavalCustomBattleMapItemVM item2 = new NavalCustomBattleMapItemVM(((object)customNavalRaidScene.Name).ToString(), customNavalRaidScene.SceneID, customNavalRaidScene.Terrain, customNavalRaidScene.ForcedSceneLevel);
			_customNavalRaidMaps.Add(item2);
		}
		TitleText = ((object)new TextObject("{=customgametitle}Map", (Dictionary<string, object>)null)).ToString();
		MapText = ((object)new TextObject("{=customgamemapname}Map", (Dictionary<string, object>)null)).ToString();
		SeasonText = ((object)new TextObject("{=xTzDM5XE}Season", (Dictionary<string, object>)null)).ToString();
		TimeOfDayText = ((object)new TextObject("{=DszSWnc3}Time of Day", (Dictionary<string, object>)null)).ToString();
		WindStrengthText = ((object)new TextObject("{=bbwr1vdO}Wind Strength", (Dictionary<string, object>)null)).ToString();
		WindDirectionText = ((object)new TextObject("{=CFUowjPd}Wind Direction", (Dictionary<string, object>)null)).ToString();
		((Collection<NavalCustomBattleMapItemVM>)(object)MapSelection.ItemList).Clear();
		((Collection<NavalCustomBattleSeasonItemVM>)(object)SeasonSelection.ItemList).Clear();
		((Collection<NavalCustomBattleTimeOfDayItemVM>)(object)TimeOfDaySelection.ItemList).Clear();
		((Collection<NavalCustomBattleWindStrengthItemVM>)(object)WindStrengthSelection.ItemList).Clear();
		((Collection<NavalCustomBattleWindDirectionItemVM>)(object)WindDirectionSelection.ItemList).Clear();
		foreach (NavalCustomBattleMapItemVM availableMap in _availableMaps)
		{
			MapSelection.AddItem(new NavalCustomBattleMapItemVM(availableMap.MapName, availableMap.MapId, availableMap.Terrain, availableMap.ForcedSceneLevel));
		}
		foreach (Tuple<string, string> season in NavalCustomBattleData.Seasons)
		{
			SeasonSelection.AddItem(new NavalCustomBattleSeasonItemVM(season.Item1, season.Item2));
		}
		foreach (Tuple<string, NavalCustomBattleTimeOfDay> item3 in NavalCustomBattleData.TimesOfDay)
		{
			TimeOfDaySelection.AddItem(new NavalCustomBattleTimeOfDayItemVM(item3.Item1, (int)item3.Item2));
		}
		foreach (Tuple<string, float> windStrength in NavalCustomBattleData.WindStrengths)
		{
			WindStrengthSelection.AddItem(new NavalCustomBattleWindStrengthItemVM(windStrength.Item1, windStrength.Item2));
		}
		foreach (Tuple<string, NavalCustomBattleWindConfig.Direction> windDirection in NavalCustomBattleData.WindDirections)
		{
			WindDirectionSelection.AddItem(new NavalCustomBattleWindDirectionItemVM(windDirection.Item1, windDirection.Item2));
		}
		MapSelection.SelectedIndex = 0;
		SeasonSelection.SelectedIndex = 0;
		TimeOfDaySelection.SelectedIndex = 0;
		WindStrengthSelection.SelectedIndex = 0;
		WindDirectionSelection.SelectedIndex = 0;
	}

	private void OnMapSelection(SelectorVM<NavalCustomBattleMapItemVM> selector)
	{
		SelectedMap = selector.SelectedItem;
	}

	private void OnSeasonSelection(SelectorVM<NavalCustomBattleSeasonItemVM> selector)
	{
		SelectedSeasonId = selector.SelectedItem.SeasonId;
	}

	private void OnTimeOfDaySelection(SelectorVM<NavalCustomBattleTimeOfDayItemVM> selector)
	{
		SelectedTimeOfDay = selector.SelectedItem.TimeOfDay;
	}

	private void OnWindStrengthSelection(SelectorVM<NavalCustomBattleWindStrengthItemVM> selector)
	{
		SelectedWindStrength = selector.SelectedItem.WindStrength;
	}

	private void OnWindDirectionSelection(SelectorVM<NavalCustomBattleWindDirectionItemVM> selector)
	{
		SelectedWindDirection = selector.SelectedItem.WindDirection;
	}

	public void OnGameTypeChange(string gameTypeStringId)
	{
		if (gameTypeStringId == "NavalBattle")
		{
			_availableMaps = _customNavalBattleMaps;
		}
		else if (gameTypeStringId == "NavalRaid")
		{
			_availableMaps = _customNavalRaidMaps;
		}
		((Collection<NavalCustomBattleMapItemVM>)(object)MapSelection.ItemList).Clear();
		foreach (NavalCustomBattleMapItemVM availableMap in _availableMaps)
		{
			MapSelection.AddItem(availableMap);
		}
		MapSelection.SelectedIndex = 0;
		IsRaid = gameTypeStringId == "NavalRaid";
	}

	public void RandomizeAll()
	{
		MapSelection.ExecuteRandomize();
		SeasonSelection.ExecuteRandomize();
		TimeOfDaySelection.ExecuteRandomize();
		WindStrengthSelection.ExecuteRandomize();
		WindDirectionSelection.ExecuteRandomize();
	}
}

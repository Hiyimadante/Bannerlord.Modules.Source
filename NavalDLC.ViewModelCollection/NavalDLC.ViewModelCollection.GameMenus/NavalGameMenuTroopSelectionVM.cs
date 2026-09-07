using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.TroopSelection;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection.GameMenus;

public class NavalGameMenuTroopSelectionVM : GameMenuTroopSelectionVM
{
	private readonly Action<TroopRoster, List<Ship>> _onDone;

	private readonly int _minSelectableShipCount;

	private readonly int _maxSelectableShipCount;

	private readonly bool _anyOtherPartiesOnPlayerSide;

	private string _currentSelectedShipAmountTitle;

	private MBBindingList<NavalGameMenuShipItemVM> _ships;

	private string _currentSelectedShipAmountText;

	[DataSourceProperty]
	public string CurrentSelectedShipAmountTitle
	{
		get
		{
			return _currentSelectedShipAmountTitle;
		}
		set
		{
			if (value != _currentSelectedShipAmountTitle)
			{
				_currentSelectedShipAmountTitle = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "CurrentSelectedShipAmountTitle");
			}
		}
	}

	[DataSourceProperty]
	public string CurrentSelectedShipAmountText
	{
		get
		{
			return _currentSelectedShipAmountText;
		}
		set
		{
			if (value != _currentSelectedShipAmountText)
			{
				_currentSelectedShipAmountText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "CurrentSelectedShipAmountText");
			}
		}
	}

	[DataSourceProperty]
	public MBBindingList<NavalGameMenuShipItemVM> Ships
	{
		get
		{
			return _ships;
		}
		set
		{
			if (value != _ships)
			{
				_ships = value;
				((ViewModel)this).OnPropertyChangedWithValue<MBBindingList<NavalGameMenuShipItemVM>>(value, "Ships");
			}
		}
	}

	public NavalGameMenuTroopSelectionVM(TroopRoster fullRoster, TroopRoster initialTroopSelections, List<Ship> eligibleShips, List<Ship> initialShipSelections, Func<CharacterObject, bool> canChangeChangeStatusOfTroop, Action<TroopRoster, List<Ship>> onDone, int minSelectableTroopCount, int minSelectableShipCount, int maxSelectableShipCount, bool anyOtherPartiesOnPlayerSide)
		: base(fullRoster, initialTroopSelections, canChangeChangeStatusOfTroop, (Action<TroopRoster>)delegate
		{
		}, 0, minSelectableTroopCount)
	{
		_onDone = onDone;
		_minSelectableShipCount = minSelectableShipCount;
		_maxSelectableShipCount = maxSelectableShipCount;
		_anyOtherPartiesOnPlayerSide = anyOtherPartiesOnPlayerSide;
		Ships = new MBBindingList<NavalGameMenuShipItemVM>();
		for (int num = 0; num < eligibleShips.Count; num++)
		{
			((Collection<NavalGameMenuShipItemVM>)(object)Ships).Add(new NavalGameMenuShipItemVM(eligibleShips[num], OnSelectedShipsChanged)
			{
				IsSelected = initialShipSelections.Contains(eligibleShips[num])
			});
		}
		OnSelectedShipsChanged();
		((ViewModel)this).RefreshValues();
	}

	public override void RefreshValues()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		((GameMenuTroopSelectionVM)this).RefreshValues();
		CurrentSelectedShipAmountTitle = ((object)new TextObject("{=*}Chosen Ships", (Dictionary<string, object>)null)).ToString();
	}

	private List<Ship> GetSelectedShips()
	{
		List<Ship> list = new List<Ship>();
		for (int i = 0; i < ((Collection<NavalGameMenuShipItemVM>)(object)Ships).Count; i++)
		{
			if (((Collection<NavalGameMenuShipItemVM>)(object)Ships)[i].IsSelected)
			{
				list.Add(((Collection<NavalGameMenuShipItemVM>)(object)Ships)[i].Ship);
			}
		}
		return list;
	}

	private void OnSelectedShipsChanged()
	{
		List<Ship> selectedShips = GetSelectedShips();
		int num = 0;
		for (int i = 0; i < selectedShips.Count; i++)
		{
			num += selectedShips[i].ShipHull.MainDeckCrewCapacity;
		}
		((GameMenuTroopSelectionVM)this).UpdateMaxSelectableTroopCount(num);
		bool flag = selectedShips.Count >= _maxSelectableShipCount;
		for (int j = 0; j < ((Collection<NavalGameMenuShipItemVM>)(object)Ships).Count; j++)
		{
			((Collection<NavalGameMenuShipItemVM>)(object)Ships)[j].IsDisabled = flag && !((Collection<NavalGameMenuShipItemVM>)(object)Ships)[j].IsSelected;
		}
		((GameMenuTroopSelectionVM)this).OnCurrentSelectedAmountChange();
	}

	protected override void OnCurrentSelectedAmountChange()
	{
		((GameMenuTroopSelectionVM)this).OnCurrentSelectedAmountChange();
		if (Ships != null)
		{
			int count = GetSelectedShips().Count;
			if (count < _minSelectableShipCount || count > _maxSelectableShipCount)
			{
				((GameMenuTroopSelectionVM)this).IsDoneEnabled = false;
			}
			GameTexts.SetVariable("LEFT", count);
			GameTexts.SetVariable("RIGHT", _maxSelectableShipCount);
			CurrentSelectedShipAmountText = ((object)GameTexts.FindText("str_LEFT_over_RIGHT_in_paranthesis", (string)null)).ToString();
			((GameMenuTroopSelectionVM)this).RefreshDoneHint();
		}
	}

	protected override void RefreshDoneHint()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		if (Ships == null)
		{
			((GameMenuTroopSelectionVM)this).RefreshDoneHint();
			return;
		}
		int count = GetSelectedShips().Count;
		if (((GameMenuTroopSelectionVM)this).IsDoneEnabled)
		{
			((GameMenuTroopSelectionVM)this).DoneHint.HintText = TextObject.GetEmpty();
		}
		else if (count < _minSelectableShipCount)
		{
			((GameMenuTroopSelectionVM)this).DoneHint.HintText = new TextObject("{=*}You must select at least {SHIP_COUNT} {?SHIP_COUNT > 1}ships{?}ship{\\?}", (Dictionary<string, object>)null).SetTextVariable("SHIP_COUNT", _minSelectableShipCount);
		}
		else if (count > _maxSelectableShipCount)
		{
			((GameMenuTroopSelectionVM)this).DoneHint.HintText = new TextObject("{=*}You cannot select more than {SHIP_COUNT} {?SHIP_COUNT > 1}ships{?}ship{\\?}", (Dictionary<string, object>)null).SetTextVariable("SHIP_COUNT", _maxSelectableShipCount);
		}
		else
		{
			((GameMenuTroopSelectionVM)this).RefreshDoneHint();
		}
	}

	public void ExecuteClearSelection()
	{
		((GameMenuTroopSelectionVM)this).ExecuteClearSelection();
		for (int i = 0; i < ((Collection<NavalGameMenuShipItemVM>)(object)Ships).Count; i++)
		{
			((Collection<NavalGameMenuShipItemVM>)(object)Ships)[i].IsSelected = false;
		}
		OnSelectedShipsChanged();
	}

	protected override void OnDone()
	{
		TroopRoster val = ((GameMenuTroopSelectionVM)this).BuildSelectedTroopRoster();
		((GameMenuTroopSelectionVM)this).IsEnabled = false;
		Common.DynamicInvokeWithLog((Delegate)_onDone, new object[2]
		{
			val,
			GetSelectedShips()
		});
	}

	protected override TextObject GetWarningMessageOnDone()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		if (((GameMenuTroopSelectionVM)this).GetAvailableSelectableTroopCount() > 0 && _anyOtherPartiesOnPlayerSide)
		{
			return new TextObject("{=*}The remaining room for soldiers will be filled by the other parties on your side. Do you want to proceed?", (Dictionary<string, object>)null);
		}
		return ((GameMenuTroopSelectionVM)this).GetWarningMessageOnDone();
	}
}

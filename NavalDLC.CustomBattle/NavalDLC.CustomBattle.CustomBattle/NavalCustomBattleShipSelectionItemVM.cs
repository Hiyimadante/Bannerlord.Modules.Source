using System;
using System.Collections.Generic;
using NavalDLC.CustomBattle.CustomBattle.SelectionItem;
using SandBox.ViewModelCollection.Input;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.CustomBattle.CustomBattle;

public class NavalCustomBattleShipSelectionItemVM : ViewModel
{
	private readonly bool _isPlayerSide;

	private readonly NavalCustomBattleShipSelectionPopUpVM _shipSelectionPopUp;

	private readonly Action _onShipSelectedOrUpgraded;

	private readonly Action<NavalCustomBattleShipItemVM> _onShipFocused;

	private InputKeyItemVM _cycleTierInputKey;

	private bool _isRelevant;

	private bool _isHovered;

	private bool _isSelectedItemEligible;

	private bool _hasSelectedItem;

	private bool _canBecomeEmpty;

	private bool _isRaid;

	private NavalCustomBattleShipItemVM _selectedItem;

	private HintViewModel _clearShipHint;

	private HintViewModel _notRelevantHint;

	public InputKeyItemVM CycleTierInputKey
	{
		get
		{
			return _cycleTierInputKey;
		}
		set
		{
			if (value != _cycleTierInputKey)
			{
				_cycleTierInputKey = value;
				((ViewModel)this).OnPropertyChangedWithValue<InputKeyItemVM>(value, "CycleTierInputKey");
			}
		}
	}

	[DataSourceProperty]
	public bool IsRelevant
	{
		get
		{
			return _isRelevant;
		}
		set
		{
			if (value != _isRelevant)
			{
				_isRelevant = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "IsRelevant");
			}
		}
	}

	[DataSourceProperty]
	public bool IsHovered
	{
		get
		{
			return _isHovered;
		}
		set
		{
			if (value != _isHovered)
			{
				_isHovered = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "IsHovered");
			}
		}
	}

	[DataSourceProperty]
	public bool IsSelectedItemEligible
	{
		get
		{
			return _isSelectedItemEligible;
		}
		set
		{
			if (value != _isSelectedItemEligible)
			{
				_isSelectedItemEligible = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "IsSelectedItemEligible");
			}
		}
	}

	[DataSourceProperty]
	public bool HasSelectedItem
	{
		get
		{
			return _hasSelectedItem;
		}
		set
		{
			if (value != _hasSelectedItem)
			{
				_hasSelectedItem = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "HasSelectedItem");
			}
		}
	}

	[DataSourceProperty]
	public bool CanBecomeEmpty
	{
		get
		{
			return _canBecomeEmpty;
		}
		set
		{
			if (value != _canBecomeEmpty)
			{
				_canBecomeEmpty = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "CanBecomeEmpty");
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
				UpdateIsSelectedItemEligible();
			}
		}
	}

	[DataSourceProperty]
	public NavalCustomBattleShipItemVM SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			if (value != _selectedItem)
			{
				_selectedItem = value;
				((ViewModel)this).OnPropertyChangedWithValue<NavalCustomBattleShipItemVM>(value, "SelectedItem");
				HasSelectedItem = _selectedItem != null;
			}
		}
	}

	[DataSourceProperty]
	public HintViewModel ClearShipHint
	{
		get
		{
			return _clearShipHint;
		}
		set
		{
			if (value != _clearShipHint)
			{
				_clearShipHint = value;
				((ViewModel)this).OnPropertyChangedWithValue<HintViewModel>(value, "ClearShipHint");
			}
		}
	}

	[DataSourceProperty]
	public HintViewModel NotRelevantHint
	{
		get
		{
			return _notRelevantHint;
		}
		set
		{
			if (value != _notRelevantHint)
			{
				_notRelevantHint = value;
				((ViewModel)this).OnPropertyChangedWithValue<HintViewModel>(value, "NotRelevantHint");
			}
		}
	}

	public NavalCustomBattleShipSelectionItemVM(bool isPlayerSide, NavalCustomBattleShipSelectionPopUpVM shipSelectionPopUp, Action onShipSelectedOrUpgraded, Action<NavalCustomBattleShipItemVM> onShipFocused)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		((ViewModel)this)._002Ector();
		_isPlayerSide = isPlayerSide;
		_shipSelectionPopUp = shipSelectionPopUp;
		_onShipSelectedOrUpgraded = onShipSelectedOrUpgraded;
		_onShipFocused = onShipFocused;
		ClearShipHint = new HintViewModel(new TextObject("{=On45SbIp}Clear ship", (Dictionary<string, object>)null), (string)null);
		NotRelevantHint = new HintViewModel(new TextObject("{=VpQVzOiV}Limited in selected game mode", (Dictionary<string, object>)null), (string)null);
		UpdateIsSelectedItemEligible();
		IsRelevant = true;
	}

	public override void RefreshValues()
	{
		((ViewModel)this).RefreshValues();
		NavalCustomBattleShipItemVM selectedItem = SelectedItem;
		if (selectedItem != null)
		{
			((ViewModel)selectedItem).RefreshValues();
		}
		InputKeyItemVM cycleTierInputKey = CycleTierInputKey;
		if (cycleTierInputKey != null)
		{
			((ViewModel)cycleTierInputKey).RefreshValues();
		}
	}

	public void SetHull(ShipHull shipHull)
	{
		if (shipHull == null)
		{
			SelectedItem = null;
		}
		else if (shipHull != SelectedItem?.ShipHull)
		{
			SelectedItem = new NavalCustomBattleShipItemVM(shipHull, _isPlayerSide, _onShipSelectedOrUpgraded);
		}
		_onShipSelectedOrUpgraded?.Invoke();
		UpdateIsSelectedItemEligible();
	}

	public void ExecuteClearShip()
	{
		OnConfirm(null);
	}

	public void ExecuteOpenPopUp()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		bool canSelectEmpty = !HasSelectedItem || CanBecomeEmpty;
		_shipSelectionPopUp.OpenPopUp(((object)new TextObject("{=QVlyuUu6}Select Ship", (Dictionary<string, object>)null)).ToString(), SelectedItem?.ShipHull, canSelectEmpty, GetIsHullDisabled, OnConfirm);
	}

	private bool GetIsHullDisabled(ShipHull shipHull)
	{
		if (IsRaid)
		{
			return !NavalCustomBattleHelper.CanShipHullBeUsedInRaid(shipHull);
		}
		return false;
	}

	public void ExecuteHoverBegin()
	{
		IsHovered = true;
		_onShipFocused?.Invoke(SelectedItem);
	}

	public void ExecuteHoverEnd()
	{
		IsHovered = false;
		_onShipFocused?.Invoke(null);
	}

	private void OnConfirm(ShipHull selectedHull)
	{
		SetHull(selectedHull);
	}

	public override void OnFinalize()
	{
		((ViewModel)this).OnFinalize();
		InputKeyItemVM cycleTierInputKey = CycleTierInputKey;
		if (cycleTierInputKey != null)
		{
			((ViewModel)cycleTierInputKey).OnFinalize();
		}
	}

	private void UpdateIsSelectedItemEligible()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (!HasSelectedItem)
		{
			IsSelectedItemEligible = true;
			return;
		}
		IsSelectedItemEligible = !GetIsHullDisabled(SelectedItem.ShipHull);
		SelectedItem.DisabledHint = (IsSelectedItemEligible ? ((HintViewModel)null) : new HintViewModel(new TextObject("{=d3WMrFKo}Not usable in selected game mode", (Dictionary<string, object>)null), (string)null));
	}

	public void SetCycleTierInputKey(HotKey hotkey)
	{
		CycleTierInputKey = InputKeyItemVM.CreateFromHotKey(hotkey, true);
	}
}

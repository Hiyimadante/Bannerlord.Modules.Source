using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NavalDLC.CustomBattle.CustomBattle.SelectionItem;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.CustomBattle;
using TaleWorlds.MountAndBlade.ViewModelCollection.Input;

namespace NavalDLC.CustomBattle.CustomBattle;

public class NavalCustomBattleVM : ViewModel
{
	public NavalCustomBattleShipItemVM FocusedShipItem;

	private readonly ICustomBattleProvider _nextCustomBattleProvider;

	private NavalCustomBattleTroopTypeSelectionPopUpVM _troopTypeSelectionPopUp;

	private NavalCustomBattleShipSelectionPopUpVM _shipSelectionPopUp;

	private NavalCustomBattleSideVM _enemySide;

	private NavalCustomBattleSideVM _playerSide;

	private NavalCustomBattleMapSelectionGroupVM _mapSelectionGroup;

	private NavalCustomBattleGameTypeSelectionGroupVM _gameTypeSelectionGroup;

	private string _randomizeButtonText;

	private string _backButtonText;

	private string _startButtonText;

	private string _switchButtonText;

	private string _titleText;

	private bool _canConfirm;

	private HintViewModel _confirmHint;

	private bool _canSwitchMode;

	private HintViewModel _switchHint;

	private InputKeyItemVM _startInputKey;

	private InputKeyItemVM _cancelInputKey;

	private InputKeyItemVM _resetInputKey;

	private InputKeyItemVM _randomizeInputKey;

	[DataSourceProperty]
	public NavalCustomBattleTroopTypeSelectionPopUpVM TroopTypeSelectionPopUp
	{
		get
		{
			return _troopTypeSelectionPopUp;
		}
		set
		{
			if (value != _troopTypeSelectionPopUp)
			{
				_troopTypeSelectionPopUp = value;
				((ViewModel)this).OnPropertyChangedWithValue<NavalCustomBattleTroopTypeSelectionPopUpVM>(value, "TroopTypeSelectionPopUp");
			}
		}
	}

	[DataSourceProperty]
	public NavalCustomBattleShipSelectionPopUpVM ShipSelectionPopUp
	{
		get
		{
			return _shipSelectionPopUp;
		}
		set
		{
			if (value != _shipSelectionPopUp)
			{
				_shipSelectionPopUp = value;
				((ViewModel)this).OnPropertyChangedWithValue<NavalCustomBattleShipSelectionPopUpVM>(value, "ShipSelectionPopUp");
			}
		}
	}

	[DataSourceProperty]
	public string RandomizeButtonText
	{
		get
		{
			return _randomizeButtonText;
		}
		set
		{
			if (value != _randomizeButtonText)
			{
				_randomizeButtonText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "RandomizeButtonText");
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
	public string BackButtonText
	{
		get
		{
			return _backButtonText;
		}
		set
		{
			if (value != _backButtonText)
			{
				_backButtonText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "BackButtonText");
			}
		}
	}

	[DataSourceProperty]
	public string StartButtonText
	{
		get
		{
			return _startButtonText;
		}
		set
		{
			if (value != _startButtonText)
			{
				_startButtonText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "StartButtonText");
			}
		}
	}

	[DataSourceProperty]
	public string SwitchButtonText
	{
		get
		{
			return _switchButtonText;
		}
		set
		{
			if (value != _switchButtonText)
			{
				_switchButtonText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "SwitchButtonText");
			}
		}
	}

	[DataSourceProperty]
	public NavalCustomBattleSideVM EnemySide
	{
		get
		{
			return _enemySide;
		}
		set
		{
			if (value != _enemySide)
			{
				_enemySide = value;
				((ViewModel)this).OnPropertyChangedWithValue<NavalCustomBattleSideVM>(value, "EnemySide");
			}
		}
	}

	[DataSourceProperty]
	public NavalCustomBattleSideVM PlayerSide
	{
		get
		{
			return _playerSide;
		}
		set
		{
			if (value != _playerSide)
			{
				_playerSide = value;
				((ViewModel)this).OnPropertyChangedWithValue<NavalCustomBattleSideVM>(value, "PlayerSide");
			}
		}
	}

	[DataSourceProperty]
	public NavalCustomBattleMapSelectionGroupVM MapSelectionGroup
	{
		get
		{
			return _mapSelectionGroup;
		}
		set
		{
			if (value != _mapSelectionGroup)
			{
				_mapSelectionGroup = value;
				((ViewModel)this).OnPropertyChangedWithValue<NavalCustomBattleMapSelectionGroupVM>(value, "MapSelectionGroup");
			}
		}
	}

	[DataSourceProperty]
	public NavalCustomBattleGameTypeSelectionGroupVM GameTypeSelectionGroup
	{
		get
		{
			return _gameTypeSelectionGroup;
		}
		set
		{
			if (value != _gameTypeSelectionGroup)
			{
				_gameTypeSelectionGroup = value;
				((ViewModel)this).OnPropertyChangedWithValue<NavalCustomBattleGameTypeSelectionGroupVM>(value, "GameTypeSelectionGroup");
			}
		}
	}

	[DataSourceProperty]
	public bool CanConfirm
	{
		get
		{
			return _canConfirm;
		}
		set
		{
			if (value != _canConfirm)
			{
				_canConfirm = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "CanConfirm");
			}
		}
	}

	[DataSourceProperty]
	public HintViewModel ConfirmHint
	{
		get
		{
			return _confirmHint;
		}
		set
		{
			if (value != _confirmHint)
			{
				_confirmHint = value;
				((ViewModel)this).OnPropertyChangedWithValue<HintViewModel>(value, "ConfirmHint");
			}
		}
	}

	[DataSourceProperty]
	public bool CanSwitchMode
	{
		get
		{
			return _canSwitchMode;
		}
		set
		{
			if (value != _canSwitchMode)
			{
				_canSwitchMode = value;
				((ViewModel)this).OnPropertyChangedWithValue(value, "CanSwitchMode");
			}
		}
	}

	[DataSourceProperty]
	public HintViewModel SwitchHint
	{
		get
		{
			return _switchHint;
		}
		set
		{
			if (value != _switchHint)
			{
				_switchHint = value;
				((ViewModel)this).OnPropertyChangedWithValue<HintViewModel>(value, "SwitchHint");
			}
		}
	}

	public InputKeyItemVM StartInputKey
	{
		get
		{
			return _startInputKey;
		}
		set
		{
			if (value != _startInputKey)
			{
				_startInputKey = value;
				((ViewModel)this).OnPropertyChangedWithValue<InputKeyItemVM>(value, "StartInputKey");
			}
		}
	}

	public InputKeyItemVM CancelInputKey
	{
		get
		{
			return _cancelInputKey;
		}
		set
		{
			if (value != _cancelInputKey)
			{
				_cancelInputKey = value;
				((ViewModel)this).OnPropertyChangedWithValue<InputKeyItemVM>(value, "CancelInputKey");
			}
		}
	}

	public InputKeyItemVM ResetInputKey
	{
		get
		{
			return _resetInputKey;
		}
		set
		{
			if (value != _resetInputKey)
			{
				_resetInputKey = value;
				((ViewModel)this).OnPropertyChangedWithValue<InputKeyItemVM>(value, "ResetInputKey");
			}
		}
	}

	public InputKeyItemVM RandomizeInputKey
	{
		get
		{
			return _randomizeInputKey;
		}
		set
		{
			if (value != _randomizeInputKey)
			{
				_randomizeInputKey = value;
				((ViewModel)this).OnPropertyChangedWithValue<InputKeyItemVM>(value, "RandomizeInputKey");
			}
		}
	}

	public NavalCustomBattleVM()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		((ViewModel)this)._002Ector();
		TroopTypeSelectionPopUp = new NavalCustomBattleTroopTypeSelectionPopUpVM();
		ShipSelectionPopUp = new NavalCustomBattleShipSelectionPopUpVM();
		PlayerSide = new NavalCustomBattleSideVM(new TextObject("{=BC7n6qxk}PLAYER", (Dictionary<string, object>)null), isPlayerSide: true, TroopTypeSelectionPopUp, ShipSelectionPopUp, OnShipFocused, UpdateCanConfirm, OnSelectedCharactersChanged);
		EnemySide = new NavalCustomBattleSideVM(new TextObject("{=35IHscBa}ENEMY", (Dictionary<string, object>)null), isPlayerSide: false, TroopTypeSelectionPopUp, ShipSelectionPopUp, OnShipFocused, UpdateCanConfirm, OnSelectedCharactersChanged);
		OnSelectedCharactersChanged();
		MapSelectionGroup = new NavalCustomBattleMapSelectionGroupVM();
		GameTypeSelectionGroup = new NavalCustomBattleGameTypeSelectionGroupVM(OnGameTypeChange, UpdateIsLandSide);
		CanSwitchMode = CustomBattleFactory.GetProviderCount() > 1;
		if (CanSwitchMode)
		{
			_nextCustomBattleProvider = CustomBattleFactory.CollectNextProvider(typeof(NavalCustomBattleProvider));
			SwitchHint = new HintViewModel(new TextObject("{=Jfe53wbr}Switch to {PROVIDER_NAME}", (Dictionary<string, object>)null).SetTextVariable("PROVIDER_NAME", _nextCustomBattleProvider.GetName()), (string)null);
		}
		ConfirmHint = new HintViewModel();
		UpdateCanConfirm();
		((ViewModel)this).RefreshValues();
	}

	private static NavalCustomBattleCompositionData GetBattleCompositionDataFromCompositionGroup(NavalCustomBattleArmyCompositionGroupVM compositionGroup)
	{
		return new NavalCustomBattleCompositionData((float)compositionGroup.RangedInfantryComposition.CompositionValue / 100f, (float)compositionGroup.MeleeCavalryComposition.CompositionValue / 100f, (float)compositionGroup.RangedCavalryComposition.CompositionValue / 100f);
	}

	private static List<BasicCharacterObject>[] GetTroopSelections(NavalCustomBattleArmyCompositionGroupVM armyComposition)
	{
		return new List<BasicCharacterObject>[4]
		{
			(from x in (IEnumerable<NavalCustomBattleTroopTypeVM>)armyComposition.MeleeInfantryComposition.TroopTypes
				where x.IsSelected
				select x.Character).ToList(),
			(from x in (IEnumerable<NavalCustomBattleTroopTypeVM>)armyComposition.RangedInfantryComposition.TroopTypes
				where x.IsSelected
				select x.Character).ToList(),
			(from x in (IEnumerable<NavalCustomBattleTroopTypeVM>)armyComposition.MeleeCavalryComposition.TroopTypes
				where x.IsSelected
				select x.Character).ToList(),
			(from x in (IEnumerable<NavalCustomBattleTroopTypeVM>)armyComposition.RangedCavalryComposition.TroopTypes
				where x.IsSelected
				select x.Character).ToList()
		};
	}

	public void SetActiveState(bool isActive)
	{
		if (isActive)
		{
			EnemySide.UpdateCharacterVisual();
			PlayerSide.UpdateCharacterVisual();
		}
		else
		{
			EnemySide.CurrentSelectedCharacter = null;
			PlayerSide.CurrentSelectedCharacter = null;
		}
	}

	private void OnSelectedCharactersChanged()
	{
		if (PlayerSide?.CharacterSelectionGroup == null || EnemySide?.CharacterSelectionGroup == null)
		{
			return;
		}
		BasicCharacterObject val = PlayerSide.CharacterSelectionGroup.SelectedItem?.Character;
		BasicCharacterObject val2 = EnemySide.CharacterSelectionGroup.SelectedItem?.Character;
		foreach (NavalCustomBattleCharacterItemVM item in (Collection<NavalCustomBattleCharacterItemVM>)(object)PlayerSide.CharacterSelectionGroup.ItemList)
		{
			((SelectorItemVM)item).CanBeSelected = item.Character != val2;
		}
		foreach (NavalCustomBattleCharacterItemVM item2 in (Collection<NavalCustomBattleCharacterItemVM>)(object)EnemySide.CharacterSelectionGroup.ItemList)
		{
			((SelectorItemVM)item2).CanBeSelected = item2.Character != val;
		}
	}

	private void OnGameTypeChange(string gameTypeStringId)
	{
		MapSelectionGroup.OnGameTypeChange(gameTypeStringId);
		UpdateIsLandSide();
		PlayerSide?.OnGameTypeChange(gameTypeStringId);
		EnemySide?.OnGameTypeChange(gameTypeStringId);
		UpdateCanConfirm();
	}

	private void UpdateIsLandSide()
	{
		if (PlayerSide != null && EnemySide != null && GameTypeSelectionGroup != null)
		{
			if (GameTypeSelectionGroup.SelectedGameTypeStringId == "NavalRaid")
			{
				PlayerSide.IsLandSide = GameTypeSelectionGroup.SelectedPlayerSide == NavalCustomBattlePlayerSide.Defender;
				EnemySide.IsLandSide = GameTypeSelectionGroup.SelectedPlayerSide == NavalCustomBattlePlayerSide.Attacker;
			}
			else
			{
				PlayerSide.IsLandSide = false;
				EnemySide.IsLandSide = false;
			}
		}
	}

	private void UpdateCanConfirm()
	{
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		if (PlayerSide == null || EnemySide == null || GameTypeSelectionGroup == null)
		{
			return;
		}
		List<string> list = new List<string>();
		if (GameTypeSelectionGroup.SelectedGameTypeStringId == "NavalRaid")
		{
			CanConfirm = (PlayerSide.IsLandSide || ((IEnumerable<NavalCustomBattleShipSelectionItemVM>)PlayerSide.ShipSelectionGroup.ShipSelectionItems).All((NavalCustomBattleShipSelectionItemVM x) => !x.IsRelevant || !x.HasSelectedItem || x.IsSelectedItemEligible)) && (EnemySide.IsLandSide || ((IEnumerable<NavalCustomBattleShipSelectionItemVM>)EnemySide.ShipSelectionGroup.ShipSelectionItems).All((NavalCustomBattleShipSelectionItemVM x) => !x.IsRelevant || !x.HasSelectedItem || x.IsSelectedItemEligible));
			if (!CanConfirm)
			{
				if (!PlayerSide.IsLandSide)
				{
					list.AddRange(from x in (IEnumerable<NavalCustomBattleShipSelectionItemVM>)PlayerSide.ShipSelectionGroup.ShipSelectionItems
						where x.IsRelevant && x.HasSelectedItem && !x.IsSelectedItemEligible
						select x.SelectedItem.Name);
				}
				if (!EnemySide.IsLandSide)
				{
					list.AddRange(from x in (IEnumerable<NavalCustomBattleShipSelectionItemVM>)EnemySide.ShipSelectionGroup.ShipSelectionItems
						where x.IsRelevant && x.HasSelectedItem && !x.IsSelectedItemEligible
						select x.SelectedItem.Name);
				}
				list = list.Distinct().ToList();
			}
		}
		else
		{
			CanConfirm = true;
		}
		ConfirmHint.HintText = (CanConfirm ? null : new TextObject("{=MC7KdXJm}Following ship types are not eligible for the selected game mode: {INELIGIBLE_SHIPS}", (Dictionary<string, object>)null).SetTextVariable("INELIGIBLE_SHIPS", string.Join(", ", list)));
	}

	public override void RefreshValues()
	{
		((ViewModel)this).RefreshValues();
		RandomizeButtonText = ((object)GameTexts.FindText("str_randomize", (string)null)).ToString();
		StartButtonText = ((object)GameTexts.FindText("str_start", (string)null)).ToString();
		BackButtonText = ((object)GameTexts.FindText("str_back", (string)null)).ToString();
		SwitchButtonText = ((object)GameTexts.FindText("str_switch", (string)null)).ToString();
		TitleText = ((object)GameTexts.FindText("str_naval_custom_battle", (string)null)).ToString();
		((ViewModel)EnemySide).RefreshValues();
		((ViewModel)PlayerSide).RefreshValues();
		((ViewModel)MapSelectionGroup).RefreshValues();
		((ViewModel)GameTypeSelectionGroup).RefreshValues();
		NavalCustomBattleTroopTypeSelectionPopUpVM troopTypeSelectionPopUp = TroopTypeSelectionPopUp;
		if (troopTypeSelectionPopUp != null)
		{
			((ViewModel)troopTypeSelectionPopUp).RefreshValues();
		}
		NavalCustomBattleShipSelectionPopUpVM shipSelectionPopUp = ShipSelectionPopUp;
		if (shipSelectionPopUp != null)
		{
			((ViewModel)shipSelectionPopUp).RefreshValues();
		}
	}

	public void ExecuteBack()
	{
		Game.Current.GameStateManager.PopState(0);
	}

	private NavalCustomBattleData PrepareBattleData()
	{
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		BasicCharacterObject selectedCharacter = PlayerSide.SelectedCharacter;
		BasicCharacterObject selectedCharacter2 = EnemySide.SelectedCharacter;
		int armySize = PlayerSide.CompositionGroup.ArmySize;
		int armySize2 = EnemySide.CompositionGroup.ArmySize;
		bool isPlayerAttacker = GameTypeSelectionGroup.SelectedPlayerSide == NavalCustomBattlePlayerSide.Attacker;
		BasicCultureObject faction = PlayerSide.FactionSelectionGroup.SelectedItem.Faction;
		BasicCultureObject faction2 = EnemySide.FactionSelectionGroup.SelectedItem.Faction;
		List<IShipOrigin>[] customBattleShipLists = NavalCustomBattleHelper.GetCustomBattleShipLists(PlayerSide.IsLandSide ? new List<IShipOrigin>() : PlayerSide.ShipSelectionGroup.GetSelectedShips(), EnemySide.IsLandSide ? new List<IShipOrigin>() : EnemySide.ShipSelectionGroup.GetSelectedShips());
		int num = (PlayerSide.IsLandSide ? 1 : customBattleShipLists[0].Count);
		int num2 = (EnemySide.IsLandSide ? 1 : customBattleShipLists[1].Count);
		int[] troopCounts = NavalCustomBattleHelper.GetTroopCounts(armySize, num, GetBattleCompositionDataFromCompositionGroup(PlayerSide.CompositionGroup));
		int[] troopCounts2 = NavalCustomBattleHelper.GetTroopCounts(armySize2, num2, GetBattleCompositionDataFromCompositionGroup(EnemySide.CompositionGroup));
		List<BasicCharacterObject>[] troopSelections = GetTroopSelections(PlayerSide.CompositionGroup);
		List<BasicCharacterObject>[] troopSelections2 = GetTroopSelections(EnemySide.CompositionGroup);
		List<BasicCharacterObject> list = new List<BasicCharacterObject>();
		foreach (BasicCharacterObject character in NavalCustomBattleData.Characters)
		{
			if (character != selectedCharacter && character != selectedCharacter2)
			{
				list.Add(character);
			}
		}
		CustomBattleCombatant[] customBattleParties = NavalCustomBattleHelper.GetCustomBattleParties(selectedCharacter, selectedCharacter2, list, faction, troopCounts, troopSelections, num, faction2, troopCounts2, troopSelections2, num2, isPlayerAttacker);
		return NavalCustomBattleHelper.PrepareBattleData(selectedCharacter, customBattleParties[0], customBattleShipLists[0], customBattleParties[1], customBattleShipLists[1], GameTypeSelectionGroup.SelectedGameTypeStringId, MapSelectionGroup.SelectedMap?.MapId, MapSelectionGroup.SelectedSeasonId, MapSelectionGroup.SelectedTimeOfDay, MapSelectionGroup.SelectedWindStrength, MapSelectionGroup.SelectedWindDirection, MapSelectionGroup.SelectedMap.Terrain, MapSelectionGroup.SelectedMap.ForcedSceneLevel);
	}

	public void ExecuteStart()
	{
		if (CanConfirm)
		{
			NavalCustomBattleHelper.StartGame(PrepareBattleData());
		}
	}

	public void ExecuteRandomize()
	{
		int targetDeckSize = MBRandom.RandomInt(40, 500);
		MapSelectionGroup.RandomizeAll();
		GameTypeSelectionGroup.RandomizeAll();
		PlayerSide.Randomize(targetDeckSize);
		EnemySide.Randomize(targetDeckSize);
	}

	public override void OnFinalize()
	{
		((ViewModel)this).OnFinalize();
		((ViewModel)StartInputKey).OnFinalize();
		((ViewModel)CancelInputKey).OnFinalize();
		((ViewModel)ResetInputKey).OnFinalize();
		((ViewModel)RandomizeInputKey).OnFinalize();
		NavalCustomBattleTroopTypeSelectionPopUpVM troopTypeSelectionPopUp = TroopTypeSelectionPopUp;
		if (troopTypeSelectionPopUp != null)
		{
			((ViewModel)troopTypeSelectionPopUp).OnFinalize();
		}
		NavalCustomBattleShipSelectionPopUpVM shipSelectionPopUp = ShipSelectionPopUp;
		if (shipSelectionPopUp != null)
		{
			((ViewModel)shipSelectionPopUp).OnFinalize();
		}
	}

	public void ExecuteSwitchToNextCustomBattle()
	{
		if (CanSwitchMode)
		{
			ExecuteBack();
			GameStateManager.Current = Module.CurrentModule.GlobalGameStateManager;
			_nextCustomBattleProvider.StartCustomBattle();
		}
	}

	private void OnShipFocused(NavalCustomBattleShipItemVM focusedItem)
	{
		FocusedShipItem = focusedItem;
	}

	public void SetStartInputKey(HotKey hotkey)
	{
		StartInputKey = InputKeyItemVM.CreateFromHotKey(hotkey, true);
	}

	public void SetCancelInputKey(HotKey hotkey)
	{
		CancelInputKey = InputKeyItemVM.CreateFromHotKey(hotkey, true);
		TroopTypeSelectionPopUp?.SetCancelInputKey(hotkey);
		ShipSelectionPopUp?.SetCloseInputKey(hotkey);
	}

	public void SetResetInputKey(HotKey hotkey)
	{
		ResetInputKey = InputKeyItemVM.CreateFromHotKey(hotkey, true);
		TroopTypeSelectionPopUp?.SetResetInputKey(hotkey);
	}

	public void SetRandomizeInputKey(HotKey hotkey)
	{
		RandomizeInputKey = InputKeyItemVM.CreateFromHotKey(hotkey, true);
	}

	public void SetCycleTierInputKey(HotKey hotkey)
	{
		PlayerSide.SetCycleTierInputKey(hotkey);
		EnemySide.SetCycleTierInputKey(hotkey);
	}
}

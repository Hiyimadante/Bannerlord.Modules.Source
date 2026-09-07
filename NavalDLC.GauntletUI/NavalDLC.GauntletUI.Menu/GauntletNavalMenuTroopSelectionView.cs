using System;
using System.Collections.Generic;
using NavalDLC.View.GameMenus;
using NavalDLC.ViewModelCollection.GameMenus;
using SandBox.View;
using SandBox.View.Map;
using SandBox.View.Menu;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.TroopSelection;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.ScreenSystem;

namespace NavalDLC.GauntletUI.Menu;

[OverrideView(typeof(NavalMenuTroopSelectionView))]
public class GauntletNavalMenuTroopSelectionView : MenuView
{
	private readonly Action<TroopRoster, List<Ship>> _onDone;

	private readonly TroopRoster _fullRoster;

	private readonly TroopRoster _initialTroopSelections;

	private readonly Func<CharacterObject, bool> _changeChangeStatusOfTroop;

	private readonly int _minSelectableTroopCount;

	private readonly int _minSelectableShipCount;

	private readonly int _maxSelectableShipCount;

	private readonly List<Ship> _eligibleShips;

	private readonly List<Ship> _initialShipSelections;

	private readonly bool _anyOtherPartiesOnPlayerSide;

	private GauntletLayer _layerAsGauntletLayer;

	private NavalGameMenuTroopSelectionVM _dataSource;

	private GauntletMovieIdentifier _movie;

	public GauntletNavalMenuTroopSelectionView(TroopRoster fullRoster, TroopRoster initialTroopSelections, List<Ship> eligibleShips, List<Ship> initialShipSelections, Func<CharacterObject, bool> changeChangeStatusOfTroop, Action<TroopRoster, List<Ship>> onDone, int minSelectableTroopCount, int minSelectableShipCount, int maxSelectableShipCount, bool anyOtherPartiesOnPlayerSide)
	{
		_onDone = onDone;
		_fullRoster = fullRoster;
		_initialTroopSelections = initialTroopSelections;
		_changeChangeStatusOfTroop = changeChangeStatusOfTroop;
		_minSelectableTroopCount = minSelectableTroopCount;
		_minSelectableShipCount = minSelectableShipCount;
		_maxSelectableShipCount = maxSelectableShipCount;
		_eligibleShips = eligibleShips;
		_initialShipSelections = initialShipSelections;
		_anyOtherPartiesOnPlayerSide = anyOtherPartiesOnPlayerSide;
	}

	protected override void OnInitialize()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		((SandboxView)this).OnInitialize();
		NavalGameMenuTroopSelectionVM navalGameMenuTroopSelectionVM = new NavalGameMenuTroopSelectionVM(_fullRoster, _initialTroopSelections, _eligibleShips, _initialShipSelections, _changeChangeStatusOfTroop, OnDone, _minSelectableTroopCount, _minSelectableShipCount, _maxSelectableShipCount, _anyOtherPartiesOnPlayerSide);
		((GameMenuTroopSelectionVM)navalGameMenuTroopSelectionVM).IsEnabled = true;
		_dataSource = navalGameMenuTroopSelectionVM;
		((GameMenuTroopSelectionVM)_dataSource).SetCancelInputKey(HotKeyManager.GetCategory("GenericPanelGameKeyCategory").GetHotKey("Exit"));
		((GameMenuTroopSelectionVM)_dataSource).SetDoneInputKey(HotKeyManager.GetCategory("GenericPanelGameKeyCategory").GetHotKey("Confirm"));
		((GameMenuTroopSelectionVM)_dataSource).SetResetInputKey(HotKeyManager.GetCategory("GenericPanelGameKeyCategory").GetHotKey("Reset"));
		((SandboxView)this).Layer = (ScreenLayer)new GauntletLayer("NavalMapTroopSelection", 206, false);
		ScreenLayer layer = ((SandboxView)this).Layer;
		_layerAsGauntletLayer = (GauntletLayer)(object)((layer is GauntletLayer) ? layer : null);
		((SandboxView)this).Layer.InputRestrictions.SetInputRestrictions(true, (InputUsageMask)7);
		((SandboxView)this).Layer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericPanelGameKeyCategory"));
		((SandboxView)this).Layer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericCampaignPanelsGameKeyCategory"));
		_movie = _layerAsGauntletLayer.LoadMovie("NavalGameMenuTroopSelection", (ViewModel)(object)_dataSource);
		((SandboxView)this).Layer.IsFocusLayer = true;
		ScreenManager.TrySetFocus((ScreenLayer)(object)_layerAsGauntletLayer);
		((MenuView)this).MenuViewContext.AddLayer(((SandboxView)this).Layer);
		ScreenBase topScreen = ScreenManager.TopScreen;
		MapScreen val;
		if ((val = (MapScreen)(object)((topScreen is MapScreen) ? topScreen : null)) != null)
		{
			val.SetIsInHideoutTroopManage(true);
		}
	}

	private void OnDone(TroopRoster troops, List<Ship> ships)
	{
		MapScreen.Instance.SetIsInHideoutTroopManage(false);
		((MenuView)this).MenuViewContext.CloseTroopSelection();
		Action<TroopRoster, List<Ship>> onDone = _onDone;
		if (onDone != null)
		{
			Common.DynamicInvokeWithLog((Delegate)onDone, new object[2] { troops, ships });
		}
	}

	protected override void OnFinalize()
	{
		((SandboxView)this).Layer.IsFocusLayer = false;
		ScreenManager.TryLoseFocus(((SandboxView)this).Layer);
		((ViewModel)_dataSource).OnFinalize();
		_dataSource = null;
		_layerAsGauntletLayer.ReleaseMovie(_movie);
		((MenuView)this).MenuViewContext.RemoveLayer(((SandboxView)this).Layer);
		_movie = null;
		((SandboxView)this).Layer = null;
		_layerAsGauntletLayer = null;
		MapScreen.Instance.SetIsInHideoutTroopManage(false);
		((SandboxView)this).OnFinalize();
	}

	protected override void OnFrameTick(float dt)
	{
		((SandboxView)this).OnFrameTick(dt);
		if (_dataSource != null)
		{
			((GameMenuTroopSelectionVM)_dataSource).IsFiveStackModifierActive = ((SandboxView)this).Layer.Input.IsHotKeyDown("FiveStackModifier");
			((GameMenuTroopSelectionVM)_dataSource).IsEntireStackModifierActive = ((SandboxView)this).Layer.Input.IsHotKeyDown("EntireStackModifier");
		}
		ScreenLayer layer = ((SandboxView)this).Layer;
		if (layer != null && layer.Input.IsHotKeyPressed("Exit"))
		{
			UISoundsHelper.PlayUISound("event:/ui/default");
			((GameMenuTroopSelectionVM)_dataSource).ExecuteCancel();
		}
		else
		{
			ScreenLayer layer2 = ((SandboxView)this).Layer;
			if (layer2 != null && layer2.Input.IsHotKeyPressed("Confirm") && ((GameMenuTroopSelectionVM)_dataSource).IsDoneEnabled)
			{
				UISoundsHelper.PlayUISound("event:/ui/default");
				((GameMenuTroopSelectionVM)_dataSource).ExecuteDone();
			}
			else
			{
				ScreenLayer layer3 = ((SandboxView)this).Layer;
				if (layer3 != null && layer3.Input.IsHotKeyPressed("Reset"))
				{
					UISoundsHelper.PlayUISound("event:/ui/default");
					((GameMenuTroopSelectionVM)_dataSource).ExecuteReset();
				}
			}
		}
		NavalGameMenuTroopSelectionVM dataSource = _dataSource;
		if (dataSource != null && !((GameMenuTroopSelectionVM)dataSource).IsEnabled)
		{
			((MenuView)this).MenuViewContext.CloseTroopSelection();
		}
	}

	protected override void OnMapConversationActivated()
	{
		((MenuView)this).OnMapConversationActivated();
		if (_layerAsGauntletLayer != null)
		{
			ScreenManager.SetSuspendLayer((ScreenLayer)(object)_layerAsGauntletLayer, true);
		}
	}

	protected override void OnMapConversationDeactivated()
	{
		((MenuView)this).OnMapConversationDeactivated();
		if (_layerAsGauntletLayer != null)
		{
			ScreenManager.SetSuspendLayer((ScreenLayer)(object)_layerAsGauntletLayer, false);
		}
	}
}

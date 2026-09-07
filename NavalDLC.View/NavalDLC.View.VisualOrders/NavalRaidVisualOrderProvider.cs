using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.VisualOrders.OrderSets;
using TaleWorlds.MountAndBlade.View.VisualOrders.Orders.ToggleOrders;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual.Default.Orders.FormOrders;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual.Default.Orders.MovementOrders;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order.Visual.Default.Orders.ToggleOrders;

namespace NavalDLC.View.VisualOrders;

public class NavalRaidVisualOrderProvider : VisualOrderProvider
{
	public override MBReadOnlyList<VisualOrderSet> GetOrders()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		Mission current = Mission.Current;
		int num;
		if (current == null)
		{
			num = 0;
		}
		else
		{
			Team playerTeam = current.PlayerTeam;
			num = ((((playerTeam != null) ? new BattleSideEnum?(playerTeam.Side) : ((BattleSideEnum?)null)) == (BattleSideEnum?)1) ? 1 : 0);
		}
		bool flag = (byte)num != 0;
		MBList<VisualOrderSet> val = new MBList<VisualOrderSet>();
		GenericVisualOrderSet val2 = new GenericVisualOrderSet("order_type_movement", new TextObject("{=KiJd6Xik}Movement", (Dictionary<string, object>)null), true, true);
		((VisualOrderSet)val2).AddOrder((VisualOrder)new MoveVisualOrder("order_movement_move"));
		((VisualOrderSet)val2).AddOrder((VisualOrder)new FollowMeVisualOrder("order_movement_follow"));
		((VisualOrderSet)val2).AddOrder((VisualOrder)new ChargeVisualOrder("order_movement_charge"));
		((VisualOrderSet)val2).AddOrder((VisualOrder)new AdvanceVisualOrder("order_movement_advance"));
		((VisualOrderSet)val2).AddOrder((VisualOrder)new FallbackVisualOrder("order_movement_fallback"));
		((VisualOrderSet)val2).AddOrder((VisualOrder)new StopVisualOrder("order_movement_stop"));
		if (!flag)
		{
			((VisualOrderSet)val2).AddOrder((VisualOrder)new RetreatVisualOrder("order_movement_retreat"));
		}
		((VisualOrderSet)val2).AddOrder((VisualOrder)new ReturnVisualOrder());
		GenericVisualOrderSet val3 = new GenericVisualOrderSet("order_type_form", new TextObject("{=iBk2wbn3}Form", (Dictionary<string, object>)null), true, true);
		ArrangementVisualOrder val4 = new ArrangementVisualOrder((ArrangementOrderEnum)2, "order_form_line");
		ArrangementVisualOrder val5 = new ArrangementVisualOrder((ArrangementOrderEnum)5, "order_form_close");
		((VisualOrderSet)val3).AddOrder((VisualOrder)(object)val4);
		((VisualOrderSet)val3).AddOrder((VisualOrder)(object)val5);
		((VisualOrderSet)val3).AddOrder((VisualOrder)new ArrangementVisualOrder((ArrangementOrderEnum)3, "order_form_loose"));
		((VisualOrderSet)val3).AddOrder((VisualOrder)new ArrangementVisualOrder((ArrangementOrderEnum)0, "order_form_circular"));
		((VisualOrderSet)val3).AddOrder((VisualOrder)new ArrangementVisualOrder((ArrangementOrderEnum)7, "order_form_schiltron"));
		((VisualOrderSet)val3).AddOrder((VisualOrder)new ArrangementVisualOrder((ArrangementOrderEnum)6, "order_form_v"));
		((VisualOrderSet)val3).AddOrder((VisualOrder)new ArrangementVisualOrder((ArrangementOrderEnum)1, "order_form_column"));
		((VisualOrderSet)val3).AddOrder((VisualOrder)new ArrangementVisualOrder((ArrangementOrderEnum)4, "order_form_scatter"));
		((VisualOrderSet)val3).AddOrder((VisualOrder)new ReturnVisualOrder());
		GenericVisualOrderSet val6 = new GenericVisualOrderSet("order_type_toggle", new TextObject("{=0HTNYQz2}Toggle", (Dictionary<string, object>)null), false, false);
		ToggleFacingVisualOrder val7 = new ToggleFacingVisualOrder("order_toggle_facing");
		GenericToggleVisualOrder val8 = new GenericToggleVisualOrder("order_toggle_fire", (OrderType)32, (OrderType)31);
		GenericToggleVisualOrder val9 = (GameNetwork.IsMultiplayer ? ((GenericToggleVisualOrder)null) : new GenericToggleVisualOrder("order_toggle_ai", (OrderType)36, (OrderType)37));
		TransferTroopsVisualOrder val10 = ((GameNetwork.IsMultiplayer | flag) ? ((TransferTroopsVisualOrder)null) : new TransferTroopsVisualOrder());
		((VisualOrderSet)val6).AddOrder((VisualOrder)(object)val7);
		((VisualOrderSet)val6).AddOrder((VisualOrder)(object)val8);
		if (val9 != null)
		{
			((VisualOrderSet)val6).AddOrder((VisualOrder)(object)val9);
		}
		if (val10 != null)
		{
			((VisualOrderSet)val6).AddOrder((VisualOrder)(object)val10);
		}
		((VisualOrderSet)val6).AddOrder((VisualOrder)new ReturnVisualOrder());
		((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)(object)val2);
		((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)(object)val3);
		((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)(object)val6);
		if (!Input.IsGamepadActive)
		{
			((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)new SingleVisualOrderSet((VisualOrder)(object)val8));
			if (val9 != null)
			{
				((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)new SingleVisualOrderSet((VisualOrder)(object)val9));
			}
			((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)new SingleVisualOrderSet((VisualOrder)(object)val7));
			((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)new SingleVisualOrderSet((VisualOrder)(object)val5));
			((List<VisualOrderSet>)(object)val).Add((VisualOrderSet)new SingleVisualOrderSet((VisualOrder)(object)val4));
		}
		return (MBReadOnlyList<VisualOrderSet>)(object)val;
	}

	public override bool IsAvailable()
	{
		return NavalDLCHelpers.IsNavalRaidMissionOpen();
	}
}

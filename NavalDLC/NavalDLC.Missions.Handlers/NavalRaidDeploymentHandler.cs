using System;
using System.Collections.Generic;
using System.Linq;
using NavalDLC.Missions.AI.TeamAI;
using NavalDLC.Missions.Deployment;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.Handlers;

public class NavalRaidDeploymentHandler : DeploymentHandler
{
	private NavalRaidMissionDeploymentPlanningLogic _navalRaidDeploymentPlan;

	private NavalShipsLogic _navalShipsLogic;

	public NavalRaidDeploymentHandler(bool isPlayerAttacker)
		: base(isPlayerAttacker)
	{
	}

	public override void OnBehaviorInitialize()
	{
		((DeploymentHandler)this).OnBehaviorInitialize();
		_navalShipsLogic = ((MissionBehavior)this).Mission.GetMissionBehavior<NavalShipsLogic>();
		((MissionBehavior)this).Mission.GetDeploymentPlan<NavalRaidMissionDeploymentPlanningLogic>(ref _navalRaidDeploymentPlan);
	}

	public override void OnRemoveBehavior()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		((DeploymentHandler)this).OnRemoveBehavior();
		if (((DeploymentHandler)this).PlayerTeam != null)
		{
			((DeploymentHandler)this).PlayerTeam.OnOrderIssued -= new OnOrderIssuedDelegate(OrderController_OnOrderIssued);
		}
	}

	public override void AfterStart()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((DeploymentHandler)this).AfterStart();
		((DeploymentHandler)this).PlayerTeam.OnOrderIssued += new OnOrderIssuedDelegate(OrderController_OnOrderIssued);
	}

	public override void AutoDeployTeamUsingDeploymentPlan(Team team)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)team.Side == 1)
		{
			AutoDeployAttackerTeam(team);
		}
		else
		{
			AutoDeployDefenderTeam(team);
		}
	}

	private void AutoDeployAttackerTeam(Team team)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		((MissionDeploymentPlanningLogic)_navalRaidDeploymentPlan).RemakeDeploymentPlan(((MissionBehavior)this).Mission.PlayerTeam);
		List<Formation> list = ((IEnumerable<Formation>)team.FormationsIncludingEmpty).ToList();
		if (list.Count > 0)
		{
			bool isTeleportingShips = _navalShipsLogic.IsTeleportingShips;
			_navalShipsLogic.SetTeleportShips(value: true);
			MBQueue<(MissionShip, Oriented2DArea)> val = new MBQueue<(MissionShip, Oriented2DArea)>();
			Vec2 targetDirection;
			foreach (Formation item4 in list)
			{
				FormationClass formationIndex = item4.FormationIndex;
				ShipAssignment shipAssignment = _navalShipsLogic.GetShipAssignment(team.TeamSide, formationIndex);
				IFormationDeploymentPlan formationPlan = ((MissionDeploymentPlanningLogic)_navalRaidDeploymentPlan).GetFormationPlan(team, formationIndex, false);
				MissionShip missionShip = shipAssignment.MissionShip;
				if (missionShip != null && formationPlan != null && formationPlan.HasFrame())
				{
					MatrixFrame frame = formationPlan.GetFrame();
					Vec2 asVec = ((Vec3)(ref frame.origin)).AsVec2;
					targetDirection = ((Vec3)(ref frame.rotation.f)).AsVec2;
					Vec2 val2 = ((Vec2)(ref targetDirection)).Normalized();
					targetDirection = missionShip.MissionShipObject.DeploymentArea;
					Oriented2DArea item = new Oriented2DArea(ref asVec, ref val2, ref targetDirection);
					((Queue<(MissionShip, Oriented2DArea)>)(object)val).Enqueue((missionShip, item));
				}
			}
			int num = 0;
			int num2 = ((Queue<(MissionShip, Oriented2DArea)>)(object)val).Count * 5;
			while (!Extensions.IsEmpty<(MissionShip, Oriented2DArea)>((IEnumerable<(MissionShip, Oriented2DArea)>)val) && num < num2)
			{
				var (missionShip2, area) = ((Queue<(MissionShip, Oriented2DArea)>)(object)val).Dequeue();
				if (_navalShipsLogic.IsAreaFreeOfShipCollision(in area, 1f, missionShip2.Index))
				{
					ShipOrder shipOrder = missionShip2.ShipOrder;
					Vec2 globalCenter = ((Oriented2DArea)(ref area)).GlobalCenter;
					targetDirection = ((Oriented2DArea)(ref area)).GlobalForward;
					shipOrder.SetShipMovementOrder(globalCenter, in targetDirection);
				}
				else
				{
					((Queue<(MissionShip, Oriented2DArea)>)(object)val).Enqueue((missionShip2, area));
				}
				num++;
			}
			while (!Extensions.IsEmpty<(MissionShip, Oriented2DArea)>((IEnumerable<(MissionShip, Oriented2DArea)>)val))
			{
				(MissionShip, Oriented2DArea) tuple2 = ((Queue<(MissionShip, Oriented2DArea)>)(object)val).Dequeue();
				MissionShip item2 = tuple2.Item1;
				Oriented2DArea item3 = tuple2.Item2;
				ShipOrder shipOrder2 = item2.ShipOrder;
				Vec2 globalCenter2 = ((Oriented2DArea)(ref item3)).GlobalCenter;
				targetDirection = ((Oriented2DArea)(ref item3)).GlobalForward;
				shipOrder2.SetShipMovementOrder(globalCenter2, in targetDirection);
			}
			if ((team.IsPlayerTeam ? team.PlayerOrderController : team.MasterOrderController) is NavalOrderController navalOrderController)
			{
				((OrderController)navalOrderController).SelectAllFormations(false);
				((OrderController)navalOrderController).SetOrder((OrderType)37);
				((OrderController)navalOrderController).SetFormationUpdateEnabledAfterSetOrder(false);
				((OrderController)navalOrderController).SetOrder((OrderType)34);
				((OrderController)navalOrderController).SetOrder((OrderType)32);
				((OrderController)navalOrderController).SetOrder((OrderType)6);
				((OrderController)navalOrderController).SetFormationUpdateEnabledAfterSetOrder(true);
				((OrderController)navalOrderController).ClearSelectedFormations();
				Formation val3 = ((IEnumerable<Formation>)team.FormationsIncludingEmpty).FirstOrDefault((Formation x) => NavalDLCHelpers.IsPlayerCaptainOfFormationShip(x));
				if (val3 != null)
				{
					((OrderController)navalOrderController).SelectFormation(val3);
					((OrderController)navalOrderController).SetOrder((OrderType)34);
					((OrderController)navalOrderController).SetFormationUpdateEnabledAfterSetOrder(true);
					((OrderController)navalOrderController).ClearSelectedFormations();
				}
			}
			else
			{
				Debug.FailedAssert("Team order controller is not of type naval order controller", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\MissionLogics\\NavalRaidDeploymentHandler.cs", "AutoDeployAttackerTeam", 168);
			}
			_navalShipsLogic.SetTeleportShips(isTeleportingShips);
		}
		if (team.IsPlayerTeam && base._deploymentMissionController is NavalDeploymentMissionController navalDeploymentMissionController)
		{
			navalDeploymentMissionController.OnPlayerShipsUpdated();
		}
	}

	private void AutoDeployDefenderTeam(Team team)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		List<Formation> list = ((IEnumerable<Formation>)team.FormationsIncludingEmpty).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		bool isTeleportingAgents = ((MissionBehavior)this).Mission.IsTeleportingAgents;
		((MissionBehavior)this).Mission.IsTeleportingAgents = true;
		OrderController val = (team.IsPlayerTeam ? team.PlayerOrderController : team.MasterOrderController);
		val.SelectAllFormations(false);
		SetDefaultFormationOrders(val);
		val.ClearSelectedFormations();
		IMissionDeploymentPlan deploymentPlan = ((MissionBehavior)this).Mission.DeploymentPlan;
		if (deploymentPlan.IsPlanMade(team))
		{
			WorldPosition val2 = default(WorldPosition);
			Vec2 val3 = default(Vec2);
			foreach (Formation item in list)
			{
				IFormationDeploymentPlan formationPlan = deploymentPlan.GetFormationPlan(team, item.FormationIndex, false);
				((MissionBehavior)this).Mission.GetFormationSpawnFrame(item.Team, item.FormationIndex, false, ref val2, ref val3, true);
				if (formationPlan.HasDimensions)
				{
					item.SetFormOrder(FormOrder.FormOrderCustom(formationPlan.PlannedWidth), true);
				}
				item.SetMovementOrder(MovementOrder.MovementOrderMove(val2));
				item.SetFacingOrder(FacingOrder.FacingOrderLookAtDirection(val3));
				WorldPosition? val4 = val2;
				Vec2? val5 = val3;
				ArrangementOrder arrangementOrder = item.ArrangementOrder;
				item.SetPositioning(val4, val5, (int?)((ArrangementOrder)(ref arrangementOrder)).GetUnitSpacing());
				item.ApplyActionOnEachUnit((Action<Agent>)delegate(Agent agent)
				{
					agent.ForceUpdateCachedAndFormationValues(true, false);
				}, (Agent)null);
				item.SetHasPendingUnitPositions(false);
				item.SetMovementOrder(MovementOrder.MovementOrderStop);
			}
		}
		else
		{
			Debug.FailedAssert("Failed to deploy team. Initial deployment plan is not made yet.", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\NavalDLC\\Missions\\MissionLogics\\NavalRaidDeploymentHandler.cs", "AutoDeployDefenderTeam", 228);
		}
		foreach (Formation item2 in list)
		{
			item2.ApplyActionOnEachUnit((Action<Agent>)delegate(Agent agent)
			{
				agent.ForceUpdateCachedAndFormationValues(true, false);
			}, (Agent)null);
			item2.SetHasPendingUnitPositions(false);
		}
		((MissionBehavior)this).Mission.IsTeleportingAgents = isTeleportingAgents;
	}

	private void SetDefaultFormationOrders(OrderController orderController)
	{
		orderController.SetOrder((OrderType)37);
		orderController.SetFormationUpdateEnabledAfterSetOrder(false);
		orderController.SetOrder((OrderType)34);
		orderController.SetOrder((OrderType)32);
		orderController.SetOrder((OrderType)16);
		orderController.SetOrder((OrderType)6);
		orderController.SetOrder((OrderType)((((MissionBehavior)this).Mission.IsSiegeBattle || ((MissionBehavior)this).Mission.IsSallyOutBattle) ? 36 : 37));
		orderController.SetFormationUpdateEnabledAfterSetOrder(true);
	}

	public override void ForceUpdateAllUnits()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((DeploymentHandler)this).PlayerTeam.Side == 0)
		{
			DeploymentHandler.OrderController_OnOrderIssued_Aux((OrderType)1, (MBReadOnlyList<Formation>)(object)((DeploymentHandler)this).PlayerTeam.FormationsIncludingSpecialAndEmpty, (OrderController)null, Array.Empty<object>());
		}
	}

	private void OrderController_OnOrderIssued(OrderType orderType, MBReadOnlyList<Formation> appliedFormations, OrderController orderController, params object[] delegateParams)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		DeploymentHandler.OrderController_OnOrderIssued_Aux(orderType, appliedFormations, orderController, delegateParams);
	}
}

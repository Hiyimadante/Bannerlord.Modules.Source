using System.Collections.Generic;
using System.Linq;
using NavalDLC.Missions.NavalPhysics;
using NavalDLC.Missions.Objects;
using NavalDLC.Missions.Objects.UsableMachines;
using NavalDLC.Missions.ShipControl;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class NavalRaidMissionController : MissionLogic
{
	public const string PlayerStandingPointEntityTag = "sp_naval_raid_player_spawn";

	private const int MaxPathNodeCount = 8;

	private const int MaxAllowedShipCount = 4;

	public NavalShipsLogic _shipsLogic;

	public NavalAgentsLogic _agentsLogic;

	private ShipCollisionOutcomeLogic _shipCollisionOutcomeLogic;

	public MatrixFrame[][] _landingFrames;

	private int[] _shipNextPathNodeIndices;

	public MatrixFrame[] _jumpingFrames;

	private readonly HashSet<MissionShip> _approachingShoutsPlayed = new HashSet<MissionShip>();

	private SoundEvent _warningBellsSoundEvent;

	private bool _hasLandingStarted;

	private bool _hasLandingCompleted;

	public override void OnBehaviorInitialize()
	{
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		_shipsLogic = Mission.Current.GetMissionBehavior<NavalShipsLogic>();
		_agentsLogic = Mission.Current.GetMissionBehavior<NavalAgentsLogic>();
		_shipCollisionOutcomeLogic = Mission.Current.GetMissionBehavior<ShipCollisionOutcomeLogic>();
		_shipsLogic.ShipPreparedForAbandonmentEvent += OnShipPreparedForAbandonment;
		_shipsLogic.ShipSpawnedEvent += OnShipSpawned;
		_shipsLogic.ShipCollisionEvent += OnShipCollision;
		_landingFrames = new MatrixFrame[4][];
		for (int i = 0; i < _landingFrames.Length; i++)
		{
			_landingFrames[i] = (MatrixFrame[])(object)new MatrixFrame[8];
		}
		foreach (GameEntity item in Mission.Current.Scene.FindEntitiesWithTagExpression("landing(_\\d+)*"))
		{
			for (int j = 0; j < 8; j++)
			{
				string mainTag = $"landing_00{j + 1}";
				string text = item.Tags.FirstOrDefault((string tag) => tag.Contains(mainTag));
				if (!string.IsNullOrEmpty(text))
				{
					if (int.TryParse(text.Replace(mainTag + "_", ""), out var result))
					{
						_landingFrames[j][result] = item.GetGlobalFrame();
						break;
					}
					if (item.HasTag(text))
					{
						_landingFrames[j][0] = item.GetGlobalFrame();
						break;
					}
				}
			}
		}
		_jumpingFrames = (MatrixFrame[])(object)new MatrixFrame[4];
		foreach (GameEntity item2 in Mission.Current.Scene.FindEntitiesWithTagExpression("jumping(_\\d+)*"))
		{
			for (int num = 0; num < 8; num++)
			{
				if (item2.HasTag($"jumping_00{num + 1}"))
				{
					_jumpingFrames[num] = item2.GetGlobalFrame();
					break;
				}
			}
		}
		_shipNextPathNodeIndices = new int[4];
		for (int num2 = 0; num2 < _shipNextPathNodeIndices.Length; num2++)
		{
			_shipNextPathNodeIndices[num2] = 8;
		}
	}

	private void OnShipCollision(MissionShip ship, WeakGameEntity targetEntity, BodyFlags bodyFlags, Vec3 averageContactPoint, Vec3 totalImpulseOnShip, bool isFirstImpact)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (isFirstImpact && targetEntity == (GameEntity)null && Extensions.HasAnyFlag<BodyFlags>(bodyFlags, (BodyFlags)33554432))
		{
			_shipCollisionOutcomeLogic.ActivateCooldownForShip(ship, float.MaxValue);
		}
	}

	private void OnShipSpawned(MissionShip ship)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		foreach (UsableMachine item in (List<UsableMachine>)(object)MBExtensions.CollectScriptComponentsIncludingChildrenRecursive<UsableMachine>(((ScriptComponentBehavior)ship).GameEntity))
		{
			foreach (StandingPoint item2 in (List<StandingPoint>)(object)item.StandingPoints)
			{
				((UsableMissionObject)item2).SetIsDisabledForPlayersSynched(true);
			}
		}
		ship.ShipOrder.SetEnforcedSailUsage(-1);
		if (ship.ShipOrigin.IsPlayerShip)
		{
			WeakGameEntity gameEntity = ((ScriptComponentBehavior)ship).GameEntity;
			WeakGameEntity firstChildEntityWithTagRecursive = ((WeakGameEntity)(ref gameEntity)).GetFirstChildEntityWithTagRecursive("sp_naval_raid_player_spawn");
			if (firstChildEntityWithTagRecursive != (GameEntity)null)
			{
				GameEntity playerStandingPointEntity = GameEntity.CreateFromWeakEntity(firstChildEntityWithTagRecursive);
				ship.SetPlayerStandingPointEntity(playerStandingPointEntity);
			}
		}
	}

	private void OnShipPreparedForAbandonment(MissionShip ship)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected I4, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		Vec3 center = ship.Physics.PhysicsBoundingBoxWithoutChildren.center;
		MatrixFrame globalFrame = ship.GlobalFrame;
		center = ((MatrixFrame)(ref globalFrame)).TransformToParent(ref center);
		SortedList<float, ShipAttachmentPointMachine> sortedList = new SortedList<float, ShipAttachmentPointMachine>();
		foreach (ShipAttachmentPointMachine item in (List<ShipAttachmentPointMachine>)(object)ship.AttachmentPointMachines)
		{
			WeakGameEntity gameEntity = ((ScriptComponentBehavior)item).GameEntity;
			Vec3 globalPosition = ((WeakGameEntity)(ref gameEntity)).GlobalPosition;
			Vec3 f = _jumpingFrames[ship.Index].rotation.f;
			((Vec3)(ref f)).Normalize();
			Vec3 val = globalPosition - center;
			Vec3 val2 = val;
			gameEntity = ((ScriptComponentBehavior)item).GameEntity;
			val = val2 + ((WeakGameEntity)(ref gameEntity)).GetGlobalFrame().rotation.f;
			((Vec3)(ref val)).Normalize();
			float key = Vec3.DotProduct(val, f);
			sortedList.Add(key, item);
		}
		int num = 0;
		ShipType type = ship.ShipOrigin.Hull.Type;
		switch ((int)type)
		{
		case 0:
			num = 4;
			break;
		case 1:
			num = 6;
			break;
		case 2:
			num = 8;
			break;
		}
		for (int i = 0; i < sortedList.Count; i++)
		{
			ShipAttachmentPointMachine shipAttachmentPointMachine = sortedList.Values[i];
			if (i >= sortedList.Count - num)
			{
				shipAttachmentPointMachine.SetJumpOffAction(ActionIndexCache.act_raid_jump);
				continue;
			}
			((UsableMachine)shipAttachmentPointMachine).SetIsDisabledForAI(true);
			((ScriptComponentBehavior)shipAttachmentPointMachine).SetScriptComponentToTick(((ScriptComponentBehavior)shipAttachmentPointMachine).GetTickRequirement());
			foreach (StandingPoint item2 in (List<StandingPoint>)(object)((UsableMachine)shipAttachmentPointMachine).StandingPoints)
			{
				((UsableMissionObject)item2).SetIsDisabledForPlayersSynched(true);
			}
		}
	}

	public override void OnDeploymentFinished()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		foreach (MissionShip item in (List<MissionShip>)(object)_shipsLogic.AllShips)
		{
			if (item.IsPlayerShip)
			{
				item.SetPlayerStandingPointEntity();
			}
			GameEntityPhysicsExtensions.UpdateBodyRestOffset(((ScriptComponentBehavior)item).GameEntity, 0f - item.MissionShipObject.LandingDepth);
			for (int num = 7; num >= 0; num--)
			{
				if (!((MatrixFrame)(ref _landingFrames[item.Index][num])).IsZero)
				{
					_shipNextPathNodeIndices[item.Index] = num;
					break;
				}
			}
			item.SetController(ShipControllerType.AI, autoUpdateController: false);
			ShipOrder shipOrder = item.ShipOrder;
			Vec2 asVec = ((Vec3)(ref _landingFrames[item.Index][_shipNextPathNodeIndices[item.Index]].origin)).AsVec2;
			Vec2 targetDirection = ((Vec3)(ref _landingFrames[item.Index][_shipNextPathNodeIndices[item.Index]].rotation.f)).AsVec2;
			targetDirection = ((Vec2)(ref targetDirection)).Normalized();
			shipOrder.SetShipMovementOrder(asVec, in targetDirection);
			item.SetCanBeTakenOver(value: false);
			if (item.ShipSiegeWeapon == null)
			{
				continue;
			}
			((SynchedMissionObject)item.ShipSiegeWeapon).SetDisabledSynched();
			WeakGameEntity val = ((ScriptComponentBehavior)item.ShipSiegeWeapon).GameEntity;
			while (val != (GameEntity)null && !((WeakGameEntity)(ref val)).HasTag("upgrade_slot"))
			{
				val = ((WeakGameEntity)(ref val)).Parent;
			}
			WeakGameEntity gameEntity = ((ScriptComponentBehavior)item.ShipSiegeWeapon).GameEntity;
			((WeakGameEntity)(ref gameEntity)).SetVisibilityExcludeParents(false);
			List<WeakGameEntity> list = new List<WeakGameEntity>();
			((WeakGameEntity)(ref val)).GetChildrenRecursive(ref list);
			foreach (WeakGameEntity item2 in list)
			{
				WeakGameEntity current2 = item2;
				((WeakGameEntity)(ref current2)).SetVisibilityExcludeParents(false);
			}
		}
		Formation formation = ((MissionBehavior)this).Mission.DefenderTeam.GetFormation((FormationClass)1);
		if (formation != null)
		{
			formation.SetArrangementOrder(ArrangementOrder.ArrangementOrderScatter);
		}
		GameEntity val2 = Mission.Current.Scene.FindEntityWithTag("player_spawn_frame");
		if (val2 != (GameEntity)null)
		{
			_warningBellsSoundEvent = SoundEvent.CreateEventFromString("event:/mission/ambient/detail/warning_bells", Mission.Current.Scene);
			_warningBellsSoundEvent.PlayInPosition(val2.GetGlobalFrame().origin);
		}
	}

	public override void OnMissionTick(float dt)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Invalid comparison between Unknown and I4
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		foreach (MissionShip item in (List<MissionShip>)(object)_shipsLogic.AllShips)
		{
			if (item.ShipOrder.MovementOrderEnum != ShipOrder.ShipMovementOrderEnum.Move)
			{
				continue;
			}
			Vec2 position = ((Vec3)(ref _landingFrames[item.Index][_shipNextPathNodeIndices[item.Index]].origin)).AsVec2;
			MatrixFrame globalFrame = item.GlobalFrame;
			float num = ((Vec2)(ref position)).DistanceSquared(((Vec3)(ref globalFrame.origin)).AsVec2);
			if (_shipNextPathNodeIndices[item.Index] == 0)
			{
				if (num > 225f && num < 400f)
				{
					MatrixFrame globalFrame2 = item.GlobalFrame;
					globalFrame2.rotation.u = Vec3.Up;
					NavalDLC.Missions.NavalPhysics.NavalPhysics physics = item.Physics;
					position = ((Vec3)(ref _landingFrames[item.Index][0].origin)).AsVec2;
					physics.SetAnchorFrame(in position, ((Vec3)(ref _landingFrames[item.Index][0].rotation.f)).AsVec2);
					item.SetAnchor(isAnchored: true);
					item.EnableBlockers();
					if (_approachingShoutsPlayed.Add(item))
					{
						globalFrame = item.GlobalFrame;
						SoundManager.StartOneShotEvent("event:/alerts/naval/getting_rammed", ref globalFrame.origin);
					}
				}
				else if (!item.BeingAbandoned && num < 225f)
				{
					item.ShipOrder.SetShipStopOrder();
					string obj = (((int)item.ShipOrigin.Hull.Type == 2) ? "event:/mission/movement/vessel/ship_ground_heavy" : "event:/mission/movement/vessel/ship_ground");
					globalFrame = item.GlobalFrame;
					SoundManager.StartOneShotEvent(obj, ref globalFrame.origin);
					globalFrame = item.GlobalFrame;
					SoundManager.StartOneShotEvent("event:/alerts/report/battle_winning", ref globalFrame.origin);
					item.PrepareForAbandonment();
					item.Formation.SetMovementOrder(MovementOrder.MovementOrderCharge);
					_hasLandingStarted = true;
					(((MissionBehavior)this).Mission.DefenderTeam.TeamAI as TeamAINavalRaidDefenderComponent).OnShipLanded();
				}
			}
			else if (num < 2500f)
			{
				_shipNextPathNodeIndices[item.Index]--;
				ShipOrder shipOrder = item.ShipOrder;
				Vec2 asVec = ((Vec3)(ref _landingFrames[item.Index][_shipNextPathNodeIndices[item.Index]].origin)).AsVec2;
				position = ((Vec3)(ref _landingFrames[item.Index][_shipNextPathNodeIndices[item.Index]].rotation.f)).AsVec2;
				shipOrder.SetShipMovementOrder(asVec, in position);
			}
		}
		if (!_hasLandingStarted || _hasLandingCompleted)
		{
			return;
		}
		_hasLandingCompleted = true;
		foreach (Agent item2 in (List<Agent>)(object)Mission.Current.AttackerTeam.ActiveAgents)
		{
			if (item2.IsAIControlled && item2.GetSteppedEntity() != (GameEntity)null)
			{
				_hasLandingCompleted = false;
				break;
			}
		}
		if (_hasLandingCompleted)
		{
			(((MissionBehavior)this).Mission.DefenderTeam.TeamAI as TeamAINavalRaidDefenderComponent).OnLandingCompleted();
		}
	}

	public override void OnFixedMissionTick(float fixedDt)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		foreach (MissionShip item in (List<MissionShip>)(object)_shipsLogic.AllShips)
		{
			if (item.ShipOrder.MovementOrderEnum == ShipOrder.ShipMovementOrderEnum.Stop && item.BeingAbandoned)
			{
				item.SetAnchor(isAnchored: false);
				WeakGameEntity gameEntity = ((ScriptComponentBehavior)item).GameEntity;
				MatrixFrame bodyWorldTransform = ((WeakGameEntity)(ref gameEntity)).GetBodyWorldTransform();
				Vec3 u = bodyWorldTransform.rotation.u;
				Vec3 f = bodyWorldTransform.rotation.f;
				Vec3 val = u - f * Vec3.DotProduct(u, f);
				((Vec3)(ref val)).Normalize();
				Vec3 val2 = Vec3.Up - f * Vec3.DotProduct(Vec3.Up, f);
				((Vec3)(ref val2)).Normalize();
				float num = MathF.Atan2(Vec3.DotProduct(f, Vec3.CrossProduct(val2, val)), Vec3.DotProduct(val2, val));
				float num2 = Vec3.DotProduct(item.Physics.AngularVelocity, f);
				float num3 = 1.8f;
				float num4 = 1f;
				float num5 = 240f / fixedDt / num3;
				float num6 = num5 * num5;
				float num7 = 2f * num4 * num5;
				Vec3 val3 = f * ((0f - num) * num6 - num2 * num7);
				val3 /= 4200000f;
				item.Physics.ApplyTorque(in val3, (ForceMode)3);
			}
		}
	}

	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		Team team = agent.Team;
		if (agent.IsAIControlled && team.IsAttacker)
		{
			AgentNavalComponent component = agent.GetComponent<AgentNavalComponent>();
			component.SetBlockOffShipConsideration(canCheckOffShipConsideration: false);
			component.SetBlockFormationCleanupOnShipAdabandonment(canCleanFormationOnShipAdabandonment: false);
			AgentNavalAIComponent component2 = agent.GetComponent<AgentNavalAIComponent>();
			int index = agent.Formation.Index;
			component2.ActivateSwimToShore(_jumpingFrames[index]);
		}
	}

	public override void OnAgentControllerSetToPlayer(Agent agent)
	{
		agent.GetComponent<AgentNavalAIComponent>().DeactivateSwimToShore();
	}

	public override void OnMissionStateFinalized()
	{
		_shipsLogic.ShipPreparedForAbandonmentEvent -= OnShipPreparedForAbandonment;
		_shipsLogic.ShipSpawnedEvent -= OnShipSpawned;
		_shipsLogic.ShipCollisionEvent -= OnShipCollision;
		if (_warningBellsSoundEvent != null)
		{
			_warningBellsSoundEvent.Stop();
			_warningBellsSoundEvent = null;
		}
	}

	public override void OnMissionResultReady(MissionResult missionResult)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
		{
			item.SetAgentFlags((AgentFlag)(item.GetAgentFlags() & -9));
		}
	}
}

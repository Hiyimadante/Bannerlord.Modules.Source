using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class BehaviorNavalRaidCliffShooting : BehaviorComponent
{
	private WorldPosition _defensePosition;

	private TacticalPosition _tacticalDefendPosition;

	public BehaviorNavalRaidCliffShooting(Formation formation)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		_defensePosition = WorldPosition.Invalid;
		((BehaviorComponent)this)._002Ector(formation);
		((BehaviorComponent)this).CalculateCurrentOrder();
	}

	public void SetTacticalDefendPosition(TacticalPosition tacticalPosition)
	{
		_tacticalDefendPosition = tacticalPosition;
	}

	protected override void CalculateCurrentOrder()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		WorldPosition val;
		Vec2 val2;
		Vec2 val4;
		if (_tacticalDefendPosition != null)
		{
			Vec2 val3;
			if (_tacticalDefendPosition.IsInsurmountable)
			{
				Vec2 averageEnemyPosition = ((BehaviorComponent)this).Formation.Team.QuerySystem.AverageEnemyPosition;
				val = _tacticalDefendPosition.Position;
				val2 = averageEnemyPosition - ((WorldPosition)(ref val)).AsVec2;
				val3 = ((Vec2)(ref val2)).Normalized();
			}
			else
			{
				val3 = _tacticalDefendPosition.Direction;
			}
			val4 = val3;
		}
		else if (((BehaviorComponent)this).Formation.CachedClosestEnemyFormation == null)
		{
			val4 = ((BehaviorComponent)this).Formation.Direction;
		}
		else
		{
			val2 = ((BehaviorComponent)this).Formation.Direction;
			val = ((BehaviorComponent)this).Formation.CachedClosestEnemyFormation.Formation.CachedMedianPosition;
			Vec2 val5 = ((WorldPosition)(ref val)).AsVec2 - ((BehaviorComponent)this).Formation.CachedAveragePosition;
			Vec2 val6;
			if (!(((Vec2)(ref val2)).DotProduct(((Vec2)(ref val5)).Normalized()) < 0.5f))
			{
				val6 = ((BehaviorComponent)this).Formation.Direction;
			}
			else
			{
				val = ((BehaviorComponent)this).Formation.CachedClosestEnemyFormation.Formation.CachedMedianPosition;
				val6 = ((WorldPosition)(ref val)).AsVec2 - ((BehaviorComponent)this).Formation.CachedAveragePosition;
			}
			Vec2 val7 = val6;
			val4 = ((Vec2)(ref val7)).Normalized();
		}
		if (_tacticalDefendPosition != null)
		{
			if (!_tacticalDefendPosition.IsInsurmountable)
			{
				((BehaviorComponent)this).CurrentOrder = MovementOrder.MovementOrderMove(_tacticalDefendPosition.Position);
			}
			else
			{
				val = _tacticalDefendPosition.Position;
				Vec2 vec = ((WorldPosition)(ref val)).AsVec2 + _tacticalDefendPosition.Width * 0.5f * val4;
				WorldPosition position = _tacticalDefendPosition.Position;
				((WorldPosition)(ref position)).SetVec2(vec);
				((BehaviorComponent)this).CurrentOrder = MovementOrder.MovementOrderMove(position);
			}
			base.CurrentFacingOrder = ((!_tacticalDefendPosition.IsInsurmountable) ? FacingOrder.FacingOrderLookAtDirection(val4) : FacingOrder.FacingOrderLookAtEnemy);
		}
		else if (((WorldPosition)(ref _defensePosition)).IsValid)
		{
			((BehaviorComponent)this).CurrentOrder = MovementOrder.MovementOrderMove(_defensePosition);
			base.CurrentFacingOrder = FacingOrder.FacingOrderLookAtDirection(val4);
		}
		else
		{
			WorldPosition cachedMedianPosition = ((BehaviorComponent)this).Formation.CachedMedianPosition;
			((WorldPosition)(ref cachedMedianPosition)).SetVec2(((BehaviorComponent)this).Formation.CachedAveragePosition);
			((BehaviorComponent)this).CurrentOrder = MovementOrder.MovementOrderMove(cachedMedianPosition);
			base.CurrentFacingOrder = FacingOrder.FacingOrderLookAtDirection(val4);
		}
	}

	public override void TickOccasionally()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		((BehaviorComponent)this).CalculateCurrentOrder();
		((BehaviorComponent)this).Formation.SetMovementOrder(((BehaviorComponent)this).CurrentOrder);
		((BehaviorComponent)this).Formation.SetFacingOrder(base.CurrentFacingOrder);
		Vec2 cachedAveragePosition = ((BehaviorComponent)this).Formation.CachedAveragePosition;
		MovementOrder currentOrder = ((BehaviorComponent)this).CurrentOrder;
		if (((Vec2)(ref cachedAveragePosition)).DistanceSquared(((MovementOrder)(ref currentOrder)).GetPosition(((BehaviorComponent)this).Formation)) < 100f)
		{
			if (_tacticalDefendPosition != null)
			{
				int countOfUnits = ((BehaviorComponent)this).Formation.CountOfUnits;
				float num = ((BehaviorComponent)this).Formation.Interval * (float)(countOfUnits - 1) + ((BehaviorComponent)this).Formation.UnitDiameter * (float)countOfUnits;
				float num2 = MathF.Min(_tacticalDefendPosition.Width, num / 3f);
				((BehaviorComponent)this).Formation.SetFormOrder(FormOrder.FormOrderCustom(num2), true);
			}
		}
		else
		{
			((BehaviorComponent)this).Formation.SetArrangementOrder(ArrangementOrder.ArrangementOrderScatter);
		}
	}

	protected override void OnBehaviorActivatedAux()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		((BehaviorComponent)this).CalculateCurrentOrder();
		((BehaviorComponent)this).Formation.SetMovementOrder(((BehaviorComponent)this).CurrentOrder);
		((BehaviorComponent)this).Formation.SetFacingOrder(base.CurrentFacingOrder);
		((BehaviorComponent)this).Formation.SetArrangementOrder(ArrangementOrder.ArrangementOrderScatter);
		((BehaviorComponent)this).Formation.SetFiringOrder(FiringOrder.FiringOrderFireAtWill);
		((BehaviorComponent)this).Formation.SetFormOrder(FormOrder.FormOrderWide, true);
	}

	public override void ResetBehavior()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		((BehaviorComponent)this).ResetBehavior();
		_defensePosition = WorldPosition.Invalid;
		_tacticalDefendPosition = null;
	}

	protected override float GetAiWeight()
	{
		return 1f;
	}
}

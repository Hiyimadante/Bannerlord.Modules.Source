using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class TacticNavalRaidDefense : TacticComponent
{
	private TacticalPosition _chokePointTacticalPosition;

	private TacticalPosition _linkedRangedDefensivePosition;

	private bool _hasLandingCompleted;

	private TeamAINavalRaidDefenderComponent _teamAI;

	public TacticNavalRaidDefense(Team team)
		: base(team)
	{
		_teamAI = team.TeamAI as TeamAINavalRaidDefenderComponent;
	}

	protected override void ManageFormationCounts()
	{
		((TacticComponent)this).AssignTacticFormations1121();
	}

	private void FightOffAttackers()
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		if (((TacticComponent)this).Team.IsPlayerTeam && !((TacticComponent)this).Team.IsPlayerGeneral && ((TacticComponent)this).Team.IsPlayerSergeant)
		{
			((TacticComponent)this).SoundTacticalHorn(TacticComponent.MoveHornSoundIndex);
		}
		if (base._mainInfantry != null)
		{
			base._mainInfantry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._mainInfantry);
			base._mainInfantry.AI.SetBehaviorWeight<BehaviorNavalRaidHoldChokePoint>(1f).SetTacticalDefendPosition(_chokePointTacticalPosition);
		}
		if (base._archers != null)
		{
			base._archers.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._archers);
			base._archers.AI.SetBehaviorWeight<BehaviorSkirmishLine>(1f);
			base._archers.AI.SetBehaviorWeight<BehaviorScreenedSkirmish>(1f);
			if (_linkedRangedDefensivePosition != null)
			{
				base._archers.AI.SetBehaviorWeight<BehaviorNavalRaidCliffShooting>(1f).SetTacticalDefendPosition(_linkedRangedDefensivePosition);
			}
		}
		if (base._leftCavalry != null)
		{
			base._leftCavalry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._leftCavalry);
			base._leftCavalry.AI.SetBehaviorWeight<BehaviorProtectFlank>(1f).FlankSide = (BehaviorSide)0;
			base._leftCavalry.AI.SetBehaviorWeight<BehaviorCavalryScreen>(1f);
		}
		if (base._rightCavalry != null)
		{
			base._rightCavalry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._rightCavalry);
			base._rightCavalry.AI.SetBehaviorWeight<BehaviorProtectFlank>(1f).FlankSide = (BehaviorSide)2;
			base._rightCavalry.AI.SetBehaviorWeight<BehaviorCavalryScreen>(1f);
		}
		if (base._rangedCavalry != null)
		{
			base._rangedCavalry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._rangedCavalry);
			base._rangedCavalry.AI.SetBehaviorWeight<BehaviorMountedSkirmish>(1f);
			base._rangedCavalry.AI.SetBehaviorWeight<BehaviorHorseArcherSkirmish>(1f);
		}
	}

	private void Defend()
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		if (((TacticComponent)this).Team.IsPlayerTeam && !((TacticComponent)this).Team.IsPlayerGeneral && ((TacticComponent)this).Team.IsPlayerSergeant)
		{
			((TacticComponent)this).SoundTacticalHorn(TacticComponent.MoveHornSoundIndex);
		}
		if (base._mainInfantry != null)
		{
			base._mainInfantry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._mainInfantry);
			base._mainInfantry.AI.SetBehaviorWeight<BehaviorNavalRaidHoldChokePoint>(1000f).SetTacticalDefendPosition(_chokePointTacticalPosition);
		}
		if (base._archers != null)
		{
			base._archers.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._archers);
			base._archers.AI.SetBehaviorWeight<BehaviorSkirmishLine>(1f);
			base._archers.AI.SetBehaviorWeight<BehaviorScreenedSkirmish>(1f);
			if (_linkedRangedDefensivePosition != null)
			{
				base._archers.AI.SetBehaviorWeight<BehaviorNavalRaidCliffShooting>(1000f).SetTacticalDefendPosition(_linkedRangedDefensivePosition);
			}
		}
		if (base._leftCavalry != null)
		{
			base._leftCavalry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._leftCavalry);
			base._leftCavalry.AI.SetBehaviorWeight<BehaviorProtectFlank>(1f).FlankSide = (BehaviorSide)0;
			base._leftCavalry.AI.SetBehaviorWeight<BehaviorCavalryScreen>(1f);
		}
		if (base._rightCavalry != null)
		{
			base._rightCavalry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._rightCavalry);
			base._rightCavalry.AI.SetBehaviorWeight<BehaviorProtectFlank>(1f).FlankSide = (BehaviorSide)2;
			base._rightCavalry.AI.SetBehaviorWeight<BehaviorCavalryScreen>(1f);
		}
		if (base._rangedCavalry != null)
		{
			base._rangedCavalry.AI.ResetBehaviorWeights();
			TacticComponent.SetDefaultBehaviorWeights(base._rangedCavalry);
			base._rangedCavalry.AI.SetBehaviorWeight<BehaviorMountedSkirmish>(1f);
			base._rangedCavalry.AI.SetBehaviorWeight<BehaviorHorseArcherSkirmish>(1f);
		}
	}

	protected override bool CheckAndSetAvailableFormationsChanged()
	{
		int aIControlledFormationCount = ((TacticComponent)this).Team.GetAIControlledFormationCount();
		bool num = aIControlledFormationCount != base._AIControlledFormationCount;
		if (num)
		{
			base._AIControlledFormationCount = aIControlledFormationCount;
			base.IsTacticReapplyNeeded = true;
		}
		if (!num)
		{
			if ((base._mainInfantry == null || (base._mainInfantry.CountOfUnits != 0 && base._mainInfantry.QuerySystem.IsInfantryFormation)) && (base._archers == null || (base._archers.CountOfUnits != 0 && base._archers.QuerySystem.IsRangedFormation)) && (base._leftCavalry == null || (base._leftCavalry.CountOfUnits != 0 && base._leftCavalry.QuerySystem.IsCavalryFormation)) && (base._rightCavalry == null || (base._rightCavalry.CountOfUnits != 0 && base._rightCavalry.QuerySystem.IsCavalryFormation)))
			{
				if (base._rangedCavalry != null)
				{
					if (base._rangedCavalry.CountOfUnits != 0)
					{
						return !base._rangedCavalry.QuerySystem.IsRangedCavalryFormation;
					}
					return true;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	public override void TickOccasionally()
	{
		if (!((TacticComponent)this).AreFormationsCreated)
		{
			return;
		}
		if (_hasLandingCompleted != _teamAI.LandingCompleted)
		{
			base.IsTacticReapplyNeeded = true;
			_hasLandingCompleted = _teamAI.LandingCompleted;
		}
		if (((TacticComponent)this).CheckAndSetAvailableFormationsChanged() || base.IsTacticReapplyNeeded)
		{
			((TacticComponent)this).ManageFormationCounts();
			if (!_hasLandingCompleted)
			{
				Defend();
			}
			else
			{
				FightOffAttackers();
			}
			base.IsTacticReapplyNeeded = false;
		}
		((TacticComponent)this).TickOccasionally();
	}

	protected override float GetTacticWeight()
	{
		if (!((TacticComponent)this).Team.TeamAI.IsCurrentTactic((TacticComponent)(object)this) || _chokePointTacticalPosition == null || !IsTacticalPositionEligible(_chokePointTacticalPosition))
		{
			DetermineChokePoints();
		}
		if (_chokePointTacticalPosition == null)
		{
			return 0f;
		}
		if (!_teamAI.LandingCompleted)
		{
			return 1000f;
		}
		if (!((TeamAIComponent)_teamAI).IsDefenseApplicable)
		{
			return 0.1f;
		}
		return 1f;
	}

	private bool IsTacticalPositionEligible(TacticalPosition tacticalPosition)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		if ((int)tacticalPosition.TacticalPositionType == 2)
		{
			return true;
		}
		if (((TacticComponent)this).CheckAndDetermineFormation(ref base._mainInfantry, (Func<Formation, bool>)((Formation f) => f.CountOfUnits > 0 && f.QuerySystem.IsInfantryFormation)))
		{
			Vec2 val = ((TacticComponent)this).Team.QuerySystem.AveragePosition;
			WorldPosition position = tacticalPosition.Position;
			float num = ((Vec2)(ref val)).Distance(((WorldPosition)(ref position)).AsVec2);
			val = ((TacticComponent)this).Team.QuerySystem.AverageEnemyPosition;
			float num2 = ((Vec2)(ref val)).Distance(base._mainInfantry.CachedAveragePosition);
			if (num > 20f && num > num2 * 0.5f)
			{
				return false;
			}
			if (base._mainInfantry.MaximumWidth < tacticalPosition.Width)
			{
				return false;
			}
			Vec2 averageEnemyPosition = ((TacticComponent)this).Team.QuerySystem.AverageEnemyPosition;
			position = tacticalPosition.Position;
			val = averageEnemyPosition - ((WorldPosition)(ref position)).AsVec2;
			val = ((Vec2)(ref val)).Normalized();
			float num3 = ((Vec2)(ref val)).DotProduct(tacticalPosition.Direction);
			if (tacticalPosition.IsInsurmountable)
			{
				return MathF.Abs(num3) >= 0.5f;
			}
			return num3 >= 0.5f;
		}
		return false;
	}

	private float GetTacticalPositionScore(TacticalPosition tacticalPosition)
	{
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		if (((TacticComponent)this).CheckAndDetermineFormation(ref base._mainInfantry, (Func<Formation, bool>)((Formation f) => f.CountOfUnits > 0 && f.QuerySystem.IsInfantryFormation)))
		{
			float num = MBMath.Lerp(1f, 1.5f, MBMath.ClampFloat(tacticalPosition.Slope, 0f, 60f) / 60f, 1E-05f);
			int countOfUnits = base._mainInfantry.CountOfUnits;
			float num2 = base._mainInfantry.Interval * (float)(countOfUnits - 1) + base._mainInfantry.UnitDiameter * (float)countOfUnits;
			float num3 = MBMath.Lerp(0.67f, 1.5f, (MBMath.ClampFloat(num2 / tacticalPosition.Width, 0.5f, 3f) - 0.5f) / 2.5f, 1E-05f);
			float num4 = 1f;
			if (((TacticComponent)this).CheckAndDetermineFormation(ref base._archers, (Func<Formation, bool>)((Formation f) => f.CountOfUnits > 0 && f.QuerySystem.IsRangedFormation)) && tacticalPosition.LinkedTacticalPositions.Where(delegate(TacticalPosition lcp)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Invalid comparison between Unknown and I4
				return (int)lcp.TacticalPositionType == 3;
			}).ToList().Count > 0)
			{
				num4 = MBMath.Lerp(1f, 1.5f, (MBMath.ClampFloat(((TacticComponent)this).Team.QuerySystem.RangedRatio, 0.05f, 0.25f) - 0.05f) * 5f, 1E-05f);
			}
			Vec2 cachedAveragePosition = base._mainInfantry.CachedAveragePosition;
			WorldPosition position = tacticalPosition.Position;
			float num5 = ((Vec2)(ref cachedAveragePosition)).Distance(((WorldPosition)(ref position)).AsVec2);
			float num6 = MBMath.Lerp(0.7f, 1f, (150f - MBMath.ClampFloat(num5, 50f, 150f)) / 100f, 1E-05f);
			return num * num3 * num4 * num6;
		}
		return 0f;
	}

	protected override bool ResetTacticalPositions()
	{
		DetermineChokePoints();
		return true;
	}

	private void DetermineChokePoints()
	{
		IEnumerable<(TacticalPosition tp, float)> first = from tp in ((TacticComponent)this).Team.TeamAI.TacticalPositions.Where(delegate(TacticalPosition tp)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Invalid comparison between Unknown and I4
				return (int)tp.TacticalPositionType == 2 && IsTacticalPositionEligible(tp);
			})
			select (tp: tp, GetTacticalPositionScore(tp));
		IEnumerable<(TacticalPosition, float)> second = from tp in ((TacticComponent)this).Team.TeamAI.TacticalRegions.SelectMany((TacticalRegion r) => r.LinkedTacticalPositions.Where(delegate(TacticalPosition tpftr)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Invalid comparison between Unknown and I4
				return (int)tpftr.TacticalPositionType == 2 && IsTacticalPositionEligible(tpftr);
			}))
			select (tp: tp, GetTacticalPositionScore(tp));
		IEnumerable<(TacticalPosition, float)> enumerable = first.Concat<(TacticalPosition, float)>(second);
		if (enumerable.Any())
		{
			TacticalPosition item = Extensions.MaxBy<(TacticalPosition, float), float>(enumerable, (Func<(TacticalPosition, float), float>)(((TacticalPosition tp, float) pst) => pst.Item2)).Item1;
			if (item != _chokePointTacticalPosition)
			{
				_chokePointTacticalPosition = item;
				base.IsTacticReapplyNeeded = true;
			}
			if (_chokePointTacticalPosition.LinkedTacticalPositions.Count > 0)
			{
				TacticalPosition val = _chokePointTacticalPosition.LinkedTacticalPositions.FirstOrDefault();
				if (val != _linkedRangedDefensivePosition)
				{
					_linkedRangedDefensivePosition = val;
					base.IsTacticReapplyNeeded = true;
				}
			}
			else
			{
				_linkedRangedDefensivePosition = null;
			}
		}
		else
		{
			_chokePointTacticalPosition = null;
		}
	}
}

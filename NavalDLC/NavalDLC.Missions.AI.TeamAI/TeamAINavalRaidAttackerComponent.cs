using System.Collections.Generic;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.TeamAI;

public class TeamAINavalRaidAttackerComponent : TeamAIComponent
{
	private readonly bool _isRiverBattle;

	private NavalShipsLogic _navalShipsLogic;

	private SpawnPathData _spawnPathData;

	public NavalQuerySystem TeamNavalQuerySystem { get; protected set; }

	public bool UseSpawnPathApproachPosition
	{
		get
		{
			if (_isRiverBattle)
			{
				return _spawnPathData.IsValid;
			}
			return false;
		}
	}

	public TeamAINavalRaidAttackerComponent(Mission currentMission, Team currentTeam, float thinkTimerTime, float applyTimerTime)
		: base(currentMission, currentTeam, thinkTimerTime, applyTimerTime)
	{
		TeamNavalQuerySystem = new NavalQuerySystem(currentTeam);
		base.Team.DisableDetachmentTicking();
		_isRiverBattle = Mission.Current.Scene.GetNavmeshFaceCountBetweenTwoIds(1, 1) > 0;
	}

	public override void OnUnitAddedToFormationForTheFirstTime(Formation formation)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Invalid comparison between Unknown and I4
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		if (GameNetwork.IsServer)
		{
			formation.ForceCalculateCaches();
			if (formation.AI.GetBehavior<BehaviorCharge>() == null)
			{
				if ((int)formation.FormationIndex == 8)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorGeneral(formation));
				}
				else if ((int)formation.FormationIndex == 9)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorProtectGeneral(formation));
				}
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorPullBack(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRegroup(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorReserve(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRetreat(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorStop(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorTacticalCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPInfantry(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPLastFlagLastStand(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPMounted(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPMountedRanged(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSergeantMPRanged(formation));
			}
		}
		else
		{
			if (GameNetwork.IsClientOrReplay)
			{
				return;
			}
			formation.ForceCalculateCaches();
			if (formation.AI.GetBehavior<BehaviorCharge>() == null)
			{
				if ((int)formation.FormationIndex == 8)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorGeneral(formation));
				}
				else if ((int)formation.FormationIndex == 9)
				{
					formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorProtectGeneral(formation));
				}
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorPullBack(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRegroup(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorReserve(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorRetreat(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorStop(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorTacticalCharge(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorAdvance(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCautiousAdvance(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorCavalryScreen(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorDefend(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorDefensiveRing(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorFireFromInfantryCover(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorFlank(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorHoldHighGround(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorHorseArcherSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorMountedSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorProtectFlank(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorScreenedSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSkirmish(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSkirmishBehindFormation(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorSkirmishLine(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorVanguard(formation));
				formation.AI.AddAiBehavior((BehaviorComponent)new BehaviorShootFromCliff(formation));
			}
		}
	}

	public override void OnDeploymentFinished()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		foreach (Formation item in (List<Formation>)(object)base.Team.FormationsIncludingEmpty)
		{
			item.OnDeploymentFinished();
		}
		_navalShipsLogic = Mission.Current.GetMissionBehavior<NavalShipsLogic>();
		if (Mission.Current.IsBattleSpawnPathSelectorInitialized)
		{
			_spawnPathData = Mission.Current.GetInitialSpawnPathData(base.Team.Side);
		}
	}
}

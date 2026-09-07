using System.Collections.Generic;
using NavalDLC.CharacterDevelopment;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.ComponentInterfaces;

public class NavalCustomBattleAgentStatCalculateModel : AgentStatCalculateModel
{
	private const int MinMarinerSkillToConsiderAgentAsMariner = 40;

	public override float GetDifficultyModifier()
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetDifficultyModifier();
	}

	public override bool CanAgentRideMount(Agent agent, Agent targetMount)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.CanAgentRideMount(agent, targetMount);
	}

	public override void InitializeAgentStatsAfterDeploymentFinished(Agent agent)
	{
		((MBGameModel<AgentStatCalculateModel>)this).BaseModel.InitializeAgentStatsAfterDeploymentFinished(agent);
		NavalShipsLogic missionBehavior = Mission.Current.GetMissionBehavior<NavalShipsLogic>();
		AgentDrivenProperties agentDrivenProperties = agent.AgentDrivenProperties;
		if (missionBehavior == null)
		{
			return;
		}
		foreach (MissionShip item in (List<MissionShip>)(object)missionBehavior.AllShips)
		{
			if (item.GetIsAgentOnShip(agent, bypassSteppedShipCheck: true))
			{
				agentDrivenProperties.MeleeWeaponDamageMultiplierBonus += item.ShipOrigin.CrewMeleeDamageFactor;
				break;
			}
		}
	}

	public override void InitializeMissionEquipmentAfterDeploymentFinished(Agent agent)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		((MBGameModel<AgentStatCalculateModel>)this).BaseModel.InitializeMissionEquipmentAfterDeploymentFinished(agent);
		NavalShipsLogic missionBehavior = Mission.Current.GetMissionBehavior<NavalShipsLogic>();
		if (missionBehavior == null || Mission.Current.IsNavalRaidBattle)
		{
			return;
		}
		foreach (MissionShip item in (List<MissionShip>)(object)missionBehavior.AllShips)
		{
			if (!item.GetIsAgentOnShip(agent, bypassSteppedShipCheck: true))
			{
				continue;
			}
			bool flag = MathF.Abs(item.ShipOrigin.CrewShieldHitPointsFactor) > 1E-05f;
			bool flag2 = item.ShipOrigin.AdditionalArcherQuivers != 0;
			bool flag3 = item.ShipOrigin.AdditionalThrowingWeaponStack != 0;
			if (!(flag | flag2 | flag3))
			{
				break;
			}
			for (EquipmentIndex val = (EquipmentIndex)0; (int)val < 4; val = (EquipmentIndex)(val + 1))
			{
				MissionWeapon val2 = agent.Equipment[val];
				if (((MissionWeapon)(ref val2)).IsEmpty)
				{
					continue;
				}
				val2 = agent.Equipment[val];
				WeaponComponentData weaponComponentDataForUsage = ((MissionWeapon)(ref val2)).GetWeaponComponentDataForUsage(0);
				if (weaponComponentDataForUsage.IsShield)
				{
					if (flag)
					{
						MissionEquipment equipment = agent.Equipment;
						EquipmentIndex val3 = val;
						val2 = agent.Equipment[val];
						equipment.SetHitPointsOfSlot(val3, (short)((float)((MissionWeapon)(ref val2)).ModifiedMaxHitPoints * (1f + item.ShipOrigin.CrewShieldHitPointsFactor)), true);
						flag = false;
					}
				}
				else
				{
					if (!weaponComponentDataForUsage.IsConsumable)
					{
						continue;
					}
					if (weaponComponentDataForUsage.IsRangedWeapon)
					{
						if (flag3)
						{
							MissionEquipment equipment2 = agent.Equipment;
							EquipmentIndex val4 = val;
							val2 = agent.Equipment[val];
							equipment2.SetAmountOfSlot(val4, (short)(((MissionWeapon)(ref val2)).ModifiedMaxAmount * (1 + item.ShipOrigin.AdditionalThrowingWeaponStack)), true);
							EquipmentIndex val5 = val;
							val2 = agent.Equipment[val];
							agent.SetWeaponAmountInSlot(val5, ((MissionWeapon)(ref val2)).Amount, true);
							flag3 = false;
						}
					}
					else if (weaponComponentDataForUsage.IsAmmo && flag2)
					{
						MissionEquipment equipment3 = agent.Equipment;
						EquipmentIndex val6 = val;
						val2 = agent.Equipment[val];
						equipment3.SetAmountOfSlot(val6, (short)(((MissionWeapon)(ref val2)).ModifiedMaxAmount * (1 + item.ShipOrigin.AdditionalArcherQuivers)), true);
						EquipmentIndex val7 = val;
						val2 = agent.Equipment[val];
						agent.SetWeaponAmountInSlot(val7, ((MissionWeapon)(ref val2)).Amount, true);
						flag2 = false;
					}
				}
			}
			break;
		}
	}

	public override void InitializeAgentStats(Agent agent, Equipment spawnEquipment, AgentDrivenProperties agentDrivenProperties, AgentBuildData agentBuildData)
	{
		((MBGameModel<AgentStatCalculateModel>)this).BaseModel.InitializeAgentStats(agent, spawnEquipment, agentDrivenProperties, agentBuildData);
	}

	public override void InitializeMissionEquipment(Agent agent)
	{
		((MBGameModel<AgentStatCalculateModel>)this).BaseModel.InitializeMissionEquipment(agent);
	}

	public override void UpdateAgentStats(Agent agent, AgentDrivenProperties agentDrivenProperties)
	{
		((MBGameModel<AgentStatCalculateModel>)this).BaseModel.UpdateAgentStats(agent, agentDrivenProperties);
		if (Mission.Current.IsNavalBattle && agent.IsHuman)
		{
			UpdateNavalHumanStats(agent, agentDrivenProperties);
		}
	}

	private void UpdateNavalHumanStats(Agent agent, AgentDrivenProperties agentDrivenProperties)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		bool flag = ((AgentStatCalculateModel)this).GetEffectiveSkill(agent, NavalSkills.Mariner) >= 40;
		MissionEquipment equipment = agent.Equipment;
		EquipmentIndex primaryWieldedItemIndex = agent.GetPrimaryWieldedItemIndex();
		object obj;
		if ((int)primaryWieldedItemIndex == -1)
		{
			obj = null;
		}
		else
		{
			MissionWeapon val = equipment[primaryWieldedItemIndex];
			obj = ((MissionWeapon)(ref val)).CurrentUsageItem;
		}
		WeaponComponentData val2 = (WeaponComponentData)obj;
		if (val2 != null && val2.IsRangedWeapon && !flag)
		{
			float num = 1.3f;
			agentDrivenProperties.WeaponMaxMovementAccuracyPenalty *= num;
			agentDrivenProperties.WeaponMaxUnsteadyAccuracyPenalty *= num;
			agentDrivenProperties.AiShooterErrorWoRangeUpdate += 0.2f;
			agentDrivenProperties.WeaponInaccuracy *= 1.3f;
			agentDrivenProperties.WeaponRotationalAccuracyPenaltyInRadians *= 1.3f;
			agentDrivenProperties.WeaponExternalAccelerationAccuracyPenalty += 0.03f;
		}
		if (!flag)
		{
			agentDrivenProperties.MaxSpeedMultiplier *= 0.8f;
			agentDrivenProperties.DamageMultiplierBonus -= 0.2f;
		}
	}

	public override int GetEffectiveSkill(Agent agent, SkillObject skill)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetEffectiveSkill(agent, skill);
	}

	public override float GetWeaponDamageMultiplier(Agent agent, WeaponComponentData weapon)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetWeaponDamageMultiplier(agent, weapon);
	}

	public override float GetEquipmentStealthBonus(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetEquipmentStealthBonus(agent);
	}

	public override float GetSneakAttackMultiplier(Agent agent, WeaponComponentData weapon)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetSneakAttackMultiplier(agent, weapon);
	}

	public override float GetKnockBackResistance(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetKnockBackResistance(agent);
	}

	public override float GetKnockDownResistance(Agent agent, StrikeType strikeType = (StrikeType)(-1))
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetKnockDownResistance(agent, strikeType);
	}

	public override float GetDismountResistance(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetDismountResistance(agent);
	}

	public override float GetWeaponInaccuracy(Agent agent, WeaponComponentData weapon, int weaponSkill)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetWeaponInaccuracy(agent, weapon, weaponSkill);
	}

	public override float GetInteractionDistance(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetInteractionDistance(agent);
	}

	public override float GetMaxCameraZoom(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetMaxCameraZoom(agent);
	}

	public override string GetMissionDebugInfoForAgent(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetMissionDebugInfoForAgent(agent);
	}

	public override float GetEffectiveMaxHealth(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetEffectiveMaxHealth(agent);
	}

	public override float GetEnvironmentSpeedFactor(Agent agent)
	{
		return ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetEnvironmentSpeedFactor(agent);
	}

	public override float GetBreatheHoldMaxDuration(Agent agent, float baseBreatheHoldMaxDuration)
	{
		if (agent.IsHuman)
		{
			float num = ((MBGameModel<AgentStatCalculateModel>)this).BaseModel.GetBreatheHoldMaxDuration(agent, baseBreatheHoldMaxDuration);
			if (((AgentStatCalculateModel)this).GetEffectiveSkill(agent, NavalSkills.Mariner) >= 40)
			{
				num += 20f;
			}
			return num;
		}
		return 1E+09f;
	}
}

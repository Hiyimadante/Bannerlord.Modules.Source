using System;
using System.Collections.Generic;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

public class MissionFormationTargetSelectionHandler : MissionView
{
	public const float MaxDistanceForFocusCheck = 1000f;

	public const float MinDistanceForFocusCheck = 10f;

	public readonly float MaxDistanceToCenterForFocus;

	private readonly List<(Formation, float)> _distanceCache;

	private readonly MBList<Formation> _focusedFormationCache;

	private Vec2 _centerOfScreen;

	private bool _isTargetingDisabled;

	private Camera ActiveCamera => base.MissionScreen.CustomCamera ?? base.MissionScreen.CombatCamera;

	public event Action<MBReadOnlyList<Formation>> OnFormationFocused;

	public MissionFormationTargetSelectionHandler()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		MaxDistanceToCenterForFocus = 70f * (Screen.RealScreenResolutionHeight / 1080f);
		_centerOfScreen = new Vec2(Screen.RealScreenResolutionWidth / 2f, Screen.RealScreenResolutionHeight / 2f);
		base._002Ector();
		_distanceCache = new List<(Formation, float)>();
		_focusedFormationCache = new MBList<Formation>();
	}

	public override void OnPreDisplayMissionTick(float dt)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		((MissionBehavior)this).OnPreDisplayMissionTick(dt);
		_distanceCache.Clear();
		((List<Formation>)(object)_focusedFormationCache).Clear();
		Mission mission = ((MissionBehavior)this).Mission;
		if (((mission != null) ? mission.Teams : null) == null)
		{
			return;
		}
		if (!_isTargetingDisabled)
		{
			Vec3 position = ActiveCamera.Position;
			_centerOfScreen.x = Screen.RealScreenResolutionWidth / 2f;
			_centerOfScreen.y = Screen.RealScreenResolutionHeight / 2f;
			for (int i = 0; i < ((List<Team>)(object)((MissionBehavior)this).Mission.Teams).Count; i++)
			{
				Team val = ((List<Team>)(object)((MissionBehavior)this).Mission.Teams)[i];
				if (val.IsPlayerAlly)
				{
					continue;
				}
				for (int j = 0; j < ((List<Formation>)(object)val.FormationsIncludingEmpty).Count; j++)
				{
					Formation val2 = ((List<Formation>)(object)val.FormationsIncludingEmpty)[j];
					if (val2.CountOfUnits > 0)
					{
						TryGetFormationDistanceToCenter(val2, position, out var isFormationFocusable, out var distanceToScreenCenter);
						if (isFormationFocusable)
						{
							_distanceCache.Add((val2, distanceToScreenCenter));
						}
					}
				}
			}
		}
		if (_distanceCache.Count == 0)
		{
			OnFormationFocused?.Invoke(null);
			return;
		}
		Formation val3 = null;
		float num = MaxDistanceToCenterForFocus;
		for (int k = 0; k < _distanceCache.Count; k++)
		{
			(Formation, float) tuple = _distanceCache[k];
			if (tuple.Item2 == 0f)
			{
				((List<Formation>)(object)_focusedFormationCache).Add(tuple.Item1);
			}
			else if (tuple.Item2 < num)
			{
				num = tuple.Item2;
				(val3, _) = tuple;
			}
		}
		if (val3 != null)
		{
			((List<Formation>)(object)_focusedFormationCache).Add(val3);
		}
		OnFormationFocused?.Invoke((MBReadOnlyList<Formation>)(object)_focusedFormationCache);
	}

	private void TryGetFormationDistanceToCenter(Formation formation, Vec3 cameraPosition, out bool isFormationFocusable, out float distanceToScreenCenter)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		WorldPosition cachedMedianPosition = formation.CachedMedianPosition;
		Vec2 val = ((WorldPosition)(ref cachedMedianPosition)).AsVec2;
		float num = ((Vec2)(ref val)).Distance(((Vec3)(ref cameraPosition)).AsVec2);
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		MBWindowManager.WorldToScreenInsideUsableArea(ActiveCamera, ((WorldPosition)(ref cachedMedianPosition)).GetGroundVec3() + new Vec3(0f, 0f, 3f, -1f), ref num2, ref num3, ref num4);
		bool flag = num4 <= 0f;
		if (num >= 1000f)
		{
			distanceToScreenCenter = 2.1474836E+09f;
			isFormationFocusable = false;
		}
		else if (num <= 10f)
		{
			isFormationFocusable = !flag;
			distanceToScreenCenter = 0f;
		}
		else if (flag)
		{
			isFormationFocusable = false;
			distanceToScreenCenter = 2.1474836E+09f;
		}
		else
		{
			isFormationFocusable = true;
			val = new Vec2(num2, num3);
			distanceToScreenCenter = ((Vec2)(ref val)).Distance(_centerOfScreen);
		}
	}

	public void SetIsFormationTargetingDisabled(bool isDisabled)
	{
		if (_isTargetingDisabled != isDisabled)
		{
			_isTargetingDisabled = isDisabled;
			if (isDisabled)
			{
				_distanceCache.Clear();
				((List<Formation>)(object)_focusedFormationCache).Clear();
				OnFormationFocused?.Invoke(null);
			}
		}
	}

	public override void OnRemoveBehavior()
	{
		_distanceCache.Clear();
		((List<Formation>)(object)_focusedFormationCache).Clear();
		OnFormationFocused = null;
		base.OnRemoveBehavior();
	}
}

using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.Missions.NavalPhysics;

public class CustomNavalPhysicsParameters : ScriptComponentBehavior
{
	public bool BehaveLikeShip;

	public float FloatingForceMultiplier;

	public float LinearFrictionMultiplierRight;

	public float LinearFrictionMultiplierLeft;

	public float LinearFrictionMultiplierForward;

	public float LinearFrictionMultiplierBackward;

	public float LinearFrictionMultiplierUp;

	public float LinearFrictionMultiplierDown;

	public Vec3 AngularFrictionMultiplier;

	public float ContinuousDriftSpeed;

	public CustomNavalPhysicsParameters()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		FloatingForceMultiplier = 1f;
		LinearFrictionMultiplierRight = 1f;
		LinearFrictionMultiplierLeft = 1f;
		LinearFrictionMultiplierForward = 1f;
		LinearFrictionMultiplierBackward = 1f;
		LinearFrictionMultiplierUp = 1f;
		LinearFrictionMultiplierDown = 1f;
		AngularFrictionMultiplier = Vec3.One;
		((ScriptComponentBehavior)this)._002Ector();
	}

	protected override void OnInit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		((ScriptComponentBehavior)this).OnInit();
		WeakGameEntity gameEntity = ((ScriptComponentBehavior)this).GameEntity;
		((WeakGameEntity)(ref gameEntity)).GetFirstScriptOfType<NavalPhysics>().SetContinuousDriftSpeed(ContinuousDriftSpeed);
	}

	protected override void OnEditorTick(float dt)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		((ScriptComponentBehavior)this).OnEditorTick(dt);
		WeakGameEntity gameEntity = ((ScriptComponentBehavior)this).GameEntity;
		((WeakGameEntity)(ref gameEntity)).GetFirstScriptOfType<NavalPhysics>()?.SetContinuousDriftSpeed(ContinuousDriftSpeed);
	}
}

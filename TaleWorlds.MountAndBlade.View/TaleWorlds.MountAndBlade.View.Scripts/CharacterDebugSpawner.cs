using System;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Scripts;

public class CharacterDebugSpawner : ScriptComponentBehavior
{
	private readonly ActionIndexCache[] _actionIndices;

	public readonly ActionIndexCache PoseAction;

	public string LordName;

	public bool IsWeaponWielded;

	private Vec2 MovementDirection;

	private float MovementSpeed;

	private float PhaseDiff;

	private float Time;

	private float ActionSetTimer;

	private float ActionChangeInterval;

	private float MovementDirectionChange;

	private static MBGameManager _editorGameManager = null;

	private static int _editorGameManagerRefCount = 0;

	private static bool isFinished = false;

	private static int gameTickFrameNo = -1;

	private bool CreateFaceImmediately;

	private AgentVisuals _agentVisuals;

	public uint ClothColor1 { get; private set; }

	public uint ClothColor2 { get; private set; }

	protected override void OnInit()
	{
		((ScriptComponentBehavior)this).OnInit();
		ClothColor1 = uint.MaxValue;
		ClothColor2 = uint.MaxValue;
	}

	protected override void OnEditorInit()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		((ScriptComponentBehavior)this).OnEditorInit();
		if (_editorGameManager == null)
		{
			_editorGameManager = (MBGameManager)new EditorGameManager();
		}
		_editorGameManagerRefCount++;
	}

	protected override void OnEditorTick(float dt)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		if (!isFinished && gameTickFrameNo != Utilities.EngineFrameNo)
		{
			gameTickFrameNo = Utilities.EngineFrameNo;
			isFinished = !((GameManagerBase)_editorGameManager).DoLoadingForGameManager();
		}
		if (Game.Current != null && _agentVisuals == null)
		{
			MovementDirection.x = MBRandom.RandomFloatNormal;
			MovementDirection.y = MBRandom.RandomFloatNormal;
			((Vec2)(ref MovementDirection)).Normalize();
			MovementSpeed = MBRandom.RandomFloat * 9f + 1f;
			PhaseDiff = MBRandom.RandomFloat;
			MovementDirectionChange = MBRandom.RandomFloatNormal * MathF.PI;
			Time = 0f;
			ActionSetTimer = 0f;
			ActionChangeInterval = MBRandom.RandomFloat * 0.5f + 0.5f;
			SpawnCharacter();
		}
		MatrixFrame globalFrame = _agentVisuals.GetVisuals().GetGlobalFrame();
		_agentVisuals.GetVisuals().SetFrame(ref globalFrame);
		Vec3 val = default(Vec3);
		((Vec3)(ref val))._002Ector(MovementDirection, 0f, -1f);
		((Vec3)(ref val)).RotateAboutZ(MovementDirectionChange * dt);
		MovementDirection.x = val.x;
		MovementDirection.y = val.y;
		float num = MovementSpeed * (MathF.Sin(PhaseDiff + Time) * 0.5f) + 2f;
		Vec2 agentLocalSpeed = MovementDirection * num;
		_agentVisuals.SetAgentLocalSpeed(agentLocalSpeed);
		Time += dt;
		if (Time - ActionSetTimer > ActionChangeInterval)
		{
			ActionSetTimer = Time;
			_agentVisuals.SetAction(in _actionIndices[MBRandom.RandomInt(_actionIndices.Length)]);
		}
	}

	protected override void OnRemoved(int removeReason)
	{
		((ScriptComponentBehavior)this).OnRemoved(removeReason);
		Reset();
		_editorGameManagerRefCount--;
		if (_editorGameManagerRefCount == 0)
		{
			_editorGameManager = null;
			isFinished = false;
		}
	}

	protected override void OnEditorVariableChanged(string variableName)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		((ScriptComponentBehavior)this).OnEditorVariableChanged(variableName);
		switch (variableName)
		{
		case "LordName":
		{
			BasicCharacterObject val2 = Game.Current.ObjectManager.GetObject<BasicCharacterObject>(LordName);
			AgentVisualsData copyAgentVisualsData = _agentVisuals.GetCopyAgentVisualsData();
			copyAgentVisualsData.BodyProperties(val2.GetBodyProperties((Equipment)null, -1)).SkeletonType((SkeletonType)(val2.IsFemale ? 1 : 0)).ActionSet(MBGlobals.GetActionSetWithSuffix(copyAgentVisualsData.MonsterData, val2.IsFemale, "_poses"))
				.Equipment(val2.Equipment)
				.UseMorphAnims(true);
			_agentVisuals.Refresh(needBatchedVersionForWeaponMeshes: false, copyAgentVisualsData);
			break;
		}
		case "PoseAction":
			_agentVisuals?.SetAction(in PoseAction);
			break;
		case "IsWeaponWielded":
		{
			BasicCharacterObject val = Game.Current.ObjectManager.GetObject<BasicCharacterObject>(LordName);
			WieldWeapon(CharacterCode.CreateFrom(val));
			break;
		}
		}
	}

	public void SetClothColors(uint color1, uint color2)
	{
		ClothColor1 = color1;
		ClothColor2 = color2;
	}

	public void SpawnCharacter()
	{
		BasicCharacterObject val = Game.Current.ObjectManager.GetObject<BasicCharacterObject>(LordName);
		if (val != null)
		{
			CharacterCode characterCode = CharacterCode.CreateFrom(val);
			InitWithCharacter(characterCode);
		}
	}

	public void Reset()
	{
		_agentVisuals?.Reset();
	}

	public void InitWithCharacter(CharacterCode characterCode)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		WeakGameEntity gameEntity = ((ScriptComponentBehavior)this).GameEntity;
		GameEntity val = GameEntity.CreateEmpty(((WeakGameEntity)(ref gameEntity)).Scene, false, true, true);
		val.Name = "TableauCharacterAgentVisualsEntity";
		Monster baseMonsterFromRace = FaceGen.GetBaseMonsterFromRace(characterCode.Race);
		AgentVisualsData obj = new AgentVisualsData().Equipment(characterCode.CalculateEquipment()).BodyProperties(characterCode.BodyProperties).Race(characterCode.Race)
			.Frame(val.GetGlobalFrame())
			.SkeletonType((SkeletonType)(characterCode.IsFemale ? 1 : 0))
			.Entity(val)
			.ActionSet(MBGlobals.GetActionSetWithSuffix(baseMonsterFromRace, characterCode.IsFemale, "_facegen"))
			.ActionCode(ref ActionIndexCache.act_inventory_idle_start);
		gameEntity = ((ScriptComponentBehavior)this).GameEntity;
		_agentVisuals = AgentVisuals.Create(obj.Scene(((WeakGameEntity)(ref gameEntity)).Scene).Monster(baseMonsterFromRace).PrepareImmediately(CreateFaceImmediately)
			.Banner(characterCode.Banner)
			.ClothColor1(ClothColor1)
			.ClothColor2(ClothColor2), "CharacterDebugSpawner", isRandomProgress: false, needBatchedVersionForWeaponMeshes: false, forceUseFaceCache: false);
		_agentVisuals.SetAction(in PoseAction, MBRandom.RandomFloat);
		gameEntity = ((ScriptComponentBehavior)this).GameEntity;
		((WeakGameEntity)(ref gameEntity)).AddChild(val.WeakEntity, false);
		WieldWeapon(characterCode);
		_agentVisuals.GetVisuals().GetSkeleton().TickAnimationsAndForceUpdate(0.1f, _agentVisuals.GetVisuals().GetGlobalFrame(), true);
	}

	public void WieldWeapon(CharacterCode characterCode)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		if (!IsWeaponWielded)
		{
			return;
		}
		int num = -1;
		int num2 = -1;
		Equipment val = characterCode.CalculateEquipment();
		for (int i = 0; i < 4; i++)
		{
			EquipmentElement val2 = val[i];
			ItemObject item = ((EquipmentElement)(ref val2)).Item;
			if (((item != null) ? item.PrimaryWeapon : null) == null)
			{
				continue;
			}
			if (num2 == -1)
			{
				val2 = val[i];
				if (Extensions.HasAnyFlag<ItemFlags>(((EquipmentElement)(ref val2)).Item.ItemFlags, (ItemFlags)524288))
				{
					num2 = i;
				}
			}
			if (num == -1)
			{
				val2 = val[i];
				if (Extensions.HasAnyFlag<WeaponFlags>(((EquipmentElement)(ref val2)).Item.PrimaryWeapon.WeaponFlags, (WeaponFlags)3))
				{
					num = i;
				}
			}
		}
		if (num != -1 || num2 != -1)
		{
			AgentVisualsData copyAgentVisualsData = _agentVisuals.GetCopyAgentVisualsData();
			copyAgentVisualsData.RightWieldedItemIndex(num).LeftWieldedItemIndex(num2).ActionCode(ref PoseAction);
			_agentVisuals.Refresh(needBatchedVersionForWeaponMeshes: false, copyAgentVisualsData);
		}
	}

	public CharacterDebugSpawner()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_066d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		_actionIndices = (ActionIndexCache[])(object)new ActionIndexCache[97]
		{
			ActionIndexCache.Create("act_start_conversation"),
			ActionIndexCache.Create("act_stand_conversation"),
			ActionIndexCache.Create("act_start_angry_conversation"),
			ActionIndexCache.Create("act_stand_angry_conversation"),
			ActionIndexCache.Create("act_start_sad_conversation"),
			ActionIndexCache.Create("act_stand_sad_conversation"),
			ActionIndexCache.Create("act_start_happy_conversation"),
			ActionIndexCache.Create("act_stand_happy_conversation"),
			ActionIndexCache.Create("act_start_busy_conversation"),
			ActionIndexCache.Create("act_stand_busy_conversation"),
			ActionIndexCache.Create("act_explaining_conversation"),
			ActionIndexCache.Create("act_introduction_conversation"),
			ActionIndexCache.Create("act_wondering_conversation"),
			ActionIndexCache.Create("act_unknown_conversation"),
			ActionIndexCache.Create("act_friendly_conversation"),
			ActionIndexCache.Create("act_offer_conversation"),
			ActionIndexCache.Create("act_negative_conversation"),
			ActionIndexCache.Create("act_affermative_conversation"),
			ActionIndexCache.Create("act_secret_conversation"),
			ActionIndexCache.Create("act_remember_conversation"),
			ActionIndexCache.Create("act_laugh_conversation"),
			ActionIndexCache.Create("act_threat_conversation"),
			ActionIndexCache.Create("act_scared_conversation"),
			ActionIndexCache.Create("act_flirty_conversation"),
			ActionIndexCache.Create("act_thanks_conversation"),
			ActionIndexCache.Create("act_farewell_conversation"),
			ActionIndexCache.Create("act_troop_cavalry_sword"),
			ActionIndexCache.Create("act_inventory_idle_start"),
			ActionIndexCache.Create("act_inventory_idle"),
			ActionIndexCache.Create("act_character_developer_idle"),
			ActionIndexCache.Create("act_inventory_cloth_equip"),
			ActionIndexCache.Create("act_inventory_glove_equip"),
			ActionIndexCache.Create("act_jump"),
			ActionIndexCache.Create("act_jump_loop"),
			ActionIndexCache.Create("act_jump_end"),
			ActionIndexCache.Create("act_jump_end_hard"),
			ActionIndexCache.Create("act_jump_left_stance"),
			ActionIndexCache.Create("act_jump_loop_left_stance"),
			ActionIndexCache.Create("act_jump_end_left_stance"),
			ActionIndexCache.Create("act_jump_end_hard_left_stance"),
			ActionIndexCache.Create("act_jump_forward"),
			ActionIndexCache.Create("act_jump_forward_loop"),
			ActionIndexCache.Create("act_jump_forward_end"),
			ActionIndexCache.Create("act_jump_forward_end_hard"),
			ActionIndexCache.Create("act_jump_forward_left_stance"),
			ActionIndexCache.Create("act_jump_forward_loop_left_stance"),
			ActionIndexCache.Create("act_jump_forward_end_left_stance"),
			ActionIndexCache.Create("act_jump_forward_end_hard_left_stance"),
			ActionIndexCache.Create("act_jump_backward"),
			ActionIndexCache.Create("act_jump_backward_loop"),
			ActionIndexCache.Create("act_jump_backward_end"),
			ActionIndexCache.Create("act_jump_backward_end_hard"),
			ActionIndexCache.Create("act_jump_backward_left_stance"),
			ActionIndexCache.Create("act_jump_backward_loop_left_stance"),
			ActionIndexCache.Create("act_jump_backward_end_left_stance"),
			ActionIndexCache.Create("act_jump_backward_end_hard_left_stance"),
			ActionIndexCache.Create("act_jump_forward_right"),
			ActionIndexCache.Create("act_jump_forward_right_left_stance"),
			ActionIndexCache.Create("act_jump_forward_left"),
			ActionIndexCache.Create("act_jump_forward_left_left_stance"),
			ActionIndexCache.Create("act_jump_right"),
			ActionIndexCache.Create("act_jump_right_loop"),
			ActionIndexCache.Create("act_jump_right_end"),
			ActionIndexCache.Create("act_jump_right_end_hard"),
			ActionIndexCache.Create("act_jump_left"),
			ActionIndexCache.Create("act_jump_left_loop"),
			ActionIndexCache.Create("act_jump_left_end"),
			ActionIndexCache.Create("act_jump_left_end_hard"),
			ActionIndexCache.Create("act_jump_loop_long"),
			ActionIndexCache.Create("act_jump_loop_long_left_stance"),
			ActionIndexCache.Create("act_throne_sit_down_from_front"),
			ActionIndexCache.Create("act_throne_stand_up_to_front"),
			ActionIndexCache.Create("act_throne_sit_idle"),
			ActionIndexCache.Create("act_sit_down_from_front"),
			ActionIndexCache.Create("act_sit_down_from_right"),
			ActionIndexCache.Create("act_sit_down_from_left"),
			ActionIndexCache.Create("act_sit_down_on_floor_1"),
			ActionIndexCache.Create("act_sit_down_on_floor_2"),
			ActionIndexCache.Create("act_sit_down_on_floor_3"),
			ActionIndexCache.Create("act_stand_up_to_front"),
			ActionIndexCache.Create("act_stand_up_to_right"),
			ActionIndexCache.Create("act_stand_up_to_left"),
			ActionIndexCache.Create("act_stand_up_floor_1"),
			ActionIndexCache.Create("act_stand_up_floor_2"),
			ActionIndexCache.Create("act_stand_up_floor_3"),
			ActionIndexCache.Create("act_sit_1"),
			ActionIndexCache.Create("act_sit_2"),
			ActionIndexCache.Create("act_sit_3"),
			ActionIndexCache.Create("act_sit_4"),
			ActionIndexCache.Create("act_sit_5"),
			ActionIndexCache.Create("act_sit_6"),
			ActionIndexCache.Create("act_sit_7"),
			ActionIndexCache.Create("act_sit_8"),
			ActionIndexCache.Create("act_sit_idle_on_floor_1"),
			ActionIndexCache.Create("act_sit_idle_on_floor_2"),
			ActionIndexCache.Create("act_sit_idle_on_floor_3"),
			ActionIndexCache.Create("act_sit_conversation")
		};
		PoseAction = ActionIndexCache.act_walk_idle_unarmed;
		LordName = "main_hero";
		CreateFaceImmediately = true;
		((ScriptComponentBehavior)this)._002Ector();
	}
}

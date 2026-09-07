using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Missions.NameMarker;

public static class MissionNameMarkerHelper
{
	public static readonly Vec3 AgentHeightOffset;

	public static readonly Vec3 DefaultHeightOffset;

	public const string NameTypeNeutral = "Normal";

	public const string NameTypeFriendly = "Friendly";

	public const string NameTypeEnemy = "Enemy";

	public const string NameTypeNoble = "Noble";

	public const string NameTypePassage = "Passage";

	public const string NameTypeEnemyPassage = "Passage";

	public const string IconTypeCommonArea = "common_area";

	public const string IconTypeStealthArea = "stealth_area";

	public const string IconTypeCharacter = "character";

	public const string IconTypePrisoner = "prisoner";

	public const string IconTypeNoble = "noble";

	public const string IconTypeBarber = "barber";

	public const string IconTypeSentry = "sentry";

	public const string IconTypeBlacksmith = "blacksmith";

	public const string IconTypeGameHost = "game_host";

	public const string IconTypeHermit = "hermit";

	public const string IconTypeShipWright = "shipwright";

	public const string IconTypeQuest = "quest";

	static MissionNameMarkerHelper()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		AgentHeightOffset = new Vec3(0f, 0f, 0.35f, -1f);
		DefaultHeightOffset = new Vec3(0f, 0f, 2f, -1f);
	}
}

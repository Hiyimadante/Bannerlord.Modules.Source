using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace NavalDLC.CustomBattle;

public struct NavalCustomBattleSceneData
{
	[CompilerGenerated]
	private TerrainType _003CTerrain_003Ek__BackingField;

	public string SceneID { get; private set; }

	public TextObject Name { get; private set; }

	public TerrainType Terrain
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CTerrain_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CTerrain_003Ek__BackingField = value;
		}
	}

	public string ForcedSceneLevel { get; private set; }

	public NavalCustomBattleSceneData(string sceneID, TextObject name, TerrainType terrain, string forcedSceneLevel)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		SceneID = sceneID;
		Name = name;
		Terrain = terrain;
		ForcedSceneLevel = forcedSceneLevel;
	}
}

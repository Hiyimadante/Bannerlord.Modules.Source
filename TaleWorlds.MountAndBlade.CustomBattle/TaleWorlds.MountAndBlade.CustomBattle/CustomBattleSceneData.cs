using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.CustomBattle;

public struct CustomBattleSceneData
{
	[CompilerGenerated]
	private TerrainType _003CTerrain_003Ek__BackingField;

	[CompilerGenerated]
	private ForestDensity _003CForestDensity_003Ek__BackingField;

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

	public List<TerrainType> TerrainTypes { get; private set; }

	public ForestDensity ForestDensity
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CForestDensity_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CForestDensity_003Ek__BackingField = value;
		}
	}

	public bool IsSiegeMap { get; private set; }

	public bool IsVillageMap { get; private set; }

	public bool IsLordsHallMap { get; private set; }

	public string ForcedSceneLevel { get; private set; }

	public CustomBattleSceneData(string sceneID, TextObject name, TerrainType terrain, List<TerrainType> terrainTypes, ForestDensity forestDensity, bool isSiegeMap, bool isVillageMap, bool isLordsHallMap, string forcedSceneLevel)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		SceneID = sceneID;
		Name = name;
		Terrain = terrain;
		TerrainTypes = terrainTypes;
		ForestDensity = forestDensity;
		IsSiegeMap = isSiegeMap;
		IsVillageMap = isVillageMap;
		IsLordsHallMap = isLordsHallMap;
		ForcedSceneLevel = forcedSceneLevel;
	}
}

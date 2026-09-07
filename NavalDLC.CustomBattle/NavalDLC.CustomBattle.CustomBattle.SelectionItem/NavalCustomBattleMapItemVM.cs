using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Library;

namespace NavalDLC.CustomBattle.CustomBattle.SelectionItem;

public class NavalCustomBattleMapItemVM : SelectorItemVM
{
	private string _searchedText;

	[CompilerGenerated]
	private TerrainType _003CTerrain_003Ek__BackingField;

	public string _nameText;

	public string MapName { get; private set; }

	public string MapId { get; private set; }

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

	[DataSourceProperty]
	public string NameText
	{
		get
		{
			return _nameText;
		}
		set
		{
			if (_nameText != value)
			{
				_nameText = value;
				((ViewModel)this).OnPropertyChangedWithValue<string>(value, "NameText");
			}
		}
	}

	public NavalCustomBattleMapItemVM(string mapName, string mapId, TerrainType terrain, string forcedSceneLevel)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		((SelectorItemVM)this)._002Ector(mapName);
		MapName = mapName;
		MapId = mapId;
		NameText = mapName;
		Terrain = terrain;
		ForcedSceneLevel = forcedSceneLevel;
	}

	public void UpdateSearchedText(string searchedText)
	{
		_searchedText = searchedText;
		string text = null;
		if (MapName.IndexOf(_searchedText, StringComparison.OrdinalIgnoreCase) != -1)
		{
			text = MapName.Substring(MapName.IndexOf(_searchedText, StringComparison.OrdinalIgnoreCase), _searchedText.Length);
		}
		if (!string.IsNullOrEmpty(text))
		{
			NameText = MapName.Replace(text, "<a>" + text + "</a>");
		}
		else
		{
			NameText = MapName;
		}
	}
}

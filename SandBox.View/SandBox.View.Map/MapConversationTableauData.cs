using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace SandBox.View.Map;

public class MapConversationTableauData
{
	[CompilerGenerated]
	private ConversationCharacterData _003CPlayerCharacterData_003Ek__BackingField;

	[CompilerGenerated]
	private ConversationCharacterData _003CConversationPartnerData_003Ek__BackingField;

	[CompilerGenerated]
	private TerrainType _003CConversationTerrainType_003Ek__BackingField;

	public ConversationCharacterData PlayerCharacterData
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CPlayerCharacterData_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CPlayerCharacterData_003Ek__BackingField = value;
		}
	}

	public ConversationCharacterData ConversationPartnerData
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CConversationPartnerData_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CConversationPartnerData_003Ek__BackingField = value;
		}
	}

	public TerrainType ConversationTerrainType
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CConversationTerrainType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CConversationTerrainType_003Ek__BackingField = value;
		}
	}

	public float TimeOfDay { get; private set; }

	public bool IsCurrentTerrainUnderSnow { get; private set; }

	public Settlement Settlement { get; private set; }

	public string LocationId { get; private set; }

	public bool IsSnowing { get; private set; }

	public bool IsRaining { get; private set; }

	private MapConversationTableauData()
	{
	}

	public static MapConversationTableauData CreateFrom(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData, TerrainType terrainType, float timeOfDay, bool isCurrentTerrainUnderSnow, Settlement settlement, string locationId, bool isRaining, bool isSnowing)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return new MapConversationTableauData
		{
			PlayerCharacterData = playerCharacterData,
			ConversationPartnerData = conversationPartnerData,
			ConversationTerrainType = terrainType,
			TimeOfDay = timeOfDay,
			IsCurrentTerrainUnderSnow = isCurrentTerrainUnderSnow,
			Settlement = settlement,
			LocationId = locationId,
			IsRaining = isRaining,
			IsSnowing = isSnowing
		};
	}
}

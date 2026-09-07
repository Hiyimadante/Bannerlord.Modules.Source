using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices.Avatar;

namespace TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;

public class AvatarThumbnailCreationData : ThumbnailCreationData
{
	[CompilerGenerated]
	private ImageType _003CImageType_003Ek__BackingField;

	public string AvatarID { get; private set; }

	public byte[] AvatarBytes { get; private set; }

	public uint Width { get; private set; }

	public uint Height { get; private set; }

	public ImageType ImageType
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CImageType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CImageType_003Ek__BackingField = value;
		}
	}

	public AvatarThumbnailCreationData(string avatarID, byte[] avatarBytes, uint width, uint height, ImageType imageType)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector(avatarID, null, null);
		AvatarID = avatarID;
		AvatarBytes = avatarBytes;
		Width = width;
		Height = height;
		ImageType = imageType;
	}
}

using System;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.FlagMarker.Targets;

public class MissionAlwaysVisibleMarkerTargetVM : MissionMarkerTargetVM
{
	private Vec3 _position;

	private Action<MissionAlwaysVisibleMarkerTargetVM> _onRemove;

	public MissionPeer TargetPeer { get; private set; }

	public override Vec3 WorldPosition
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _position;
		}
	}

	protected override float HeightOffset => 0.75f;

	public MissionAlwaysVisibleMarkerTargetVM(MissionPeer peer, Vec3 position, Action<MissionAlwaysVisibleMarkerTargetVM> onRemove)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector(MissionMarkerType.Peer);
		TargetPeer = peer;
		_position = position;
		_onRemove = onRemove;
	}

	public void ExecuteRemove()
	{
		_onRemove?.Invoke(this);
	}
}

using System;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Friends;

public class MPLobbyFriendItemVM : MPLobbyPlayerBaseVM
{
	private Action<MPLobbyPlayerBaseVM> _onActivatePlayerActions;

	public MPLobbyFriendItemVM(PlayerId ID, Action<MPLobbyPlayerBaseVM> onActivatePlayerActions, Action<PlayerId> onInviteToClan = null, Action<PlayerId> onFriendRequestAnswered = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector(ID, string.Empty, onInviteToClan, onFriendRequestAnswered);
		_onActivatePlayerActions = onActivatePlayerActions;
	}

	private void ExecuteActivatePlayerActions()
	{
		_onActivatePlayerActions(this);
	}
}

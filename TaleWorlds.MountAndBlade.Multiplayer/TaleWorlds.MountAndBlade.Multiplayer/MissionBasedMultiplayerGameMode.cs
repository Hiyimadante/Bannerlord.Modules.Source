using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade.Multiplayer;

public class MissionBasedMultiplayerGameMode : MultiplayerGameMode
{
	public MissionBasedMultiplayerGameMode(string name)
		: base(name)
	{
	}

	public override void JoinCustomGame(JoinGameData joinGameData)
	{
		LobbyGameStateCustomGameClient lobbyGameStateCustomGameClient = Game.Current.GameStateManager.CreateState<LobbyGameStateCustomGameClient>();
		lobbyGameStateCustomGameClient.SetStartingParameters(NetworkMain.GameClient, joinGameData.GameServerProperties.Address, joinGameData.GameServerProperties.Port, joinGameData.PeerIndex, joinGameData.SessionKey);
		Game.Current.GameStateManager.PushState((GameState)(object)lobbyGameStateCustomGameClient, 0);
	}

	public override void StartMultiplayerGame(string scene)
	{
		if (Mission.Current != null)
		{
			Debug.FailedAssert("Starting multiplayer game while a mission is ongoing", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade.Multiplayer\\MissionBasedMultiplayerGameMode.cs", "StartMultiplayerGame", 31);
		}
		GameStateManager current = GameStateManager.Current;
		if (((current != null) ? current.ActiveState : null) is MissionState)
		{
			Debug.FailedAssert("Starting multiplayer game while in mission state", "C:\\BuildAgent\\work\\mb3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade.Multiplayer\\MissionBasedMultiplayerGameMode.cs", "StartMultiplayerGame", 37);
		}
		if (((MultiplayerGameMode)this).Name == "TeamDeathmatch")
		{
			MultiplayerMissions.OpenTeamDeathmatchMission(scene);
		}
		else if (((MultiplayerGameMode)this).Name == "Duel")
		{
			MultiplayerMissions.OpenDuelMission(scene);
		}
		else if (((MultiplayerGameMode)this).Name == "Siege")
		{
			MultiplayerMissions.OpenSiegeMission(scene);
		}
		else if (((MultiplayerGameMode)this).Name == "Battle")
		{
			MultiplayerMissions.OpenBattleMission(scene);
		}
		else if (((MultiplayerGameMode)this).Name == "Captain")
		{
			MultiplayerMissions.OpenCaptainMission(scene);
		}
		else if (((MultiplayerGameMode)this).Name == "Skirmish")
		{
			MultiplayerMissions.OpenSkirmishMission(scene);
		}
	}
}

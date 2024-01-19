using Fusion;
using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{
    public NetworkRunner RunnerServer;

    public void Init(NetworkRunner runner, NetworkEvents events)
    {
        RunnerServer = runner;

        events.PlayerJoined = new NetworkEvents.PlayerEvent();
        events.PlayerLeft = new NetworkEvents.PlayerEvent();

        events.PlayerJoined.AddListener(OnPlayerJoined);
        events.PlayerLeft.AddListener(OnPlayerLeft);
    }

    private async void OnPlayerJoined(NetworkRunner runner, PlayerRef playerRef)
    {
        var player = await Utils.GetAsset<Player>("Player");
        RunnerServer.Spawn(player, inputAuthority: playerRef);
    }

    private void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }
}
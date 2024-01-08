using Fusion;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Player _playerPrefab;

    private void Start()
    {
        RunnerController.Instance.NetworkEventsCreated += Init;
    }

    private void Init(NetworkEvents events)
    {
        events.PlayerJoined.AddListener(OnPlayerJoined);
        events.PlayerLeft.AddListener(OnPlayerLeft);
    }

    private void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            runner.Spawn(_playerPrefab, inputAuthority: player);
        }
    }

    private void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }
}

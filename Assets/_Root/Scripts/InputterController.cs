using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class InputterController : Singleton<InputterController>
{
    [SerializeField] private Inputter _inputterPrefab;
    public Dictionary<PlayerRef, Inputter> Inputters;

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
            var inputter = runner.Spawn(_inputterPrefab, inputAuthority: player);
            Inputters.Add(player, inputter);
        }
    }

    private void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }
}

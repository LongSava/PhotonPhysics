using System;
using System.Threading.Tasks;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerController : Singleton<RunnerController>
{
    public RunnerMode Mode;
    public NetworkRunner[] Runners;

    private async void Start()
    {
        switch (Mode)
        {
            case RunnerMode.Client:
                Runners = new NetworkRunner[1];
                await AddRunner(GameMode.Client, 0);
                break;
            case RunnerMode.Server:
                Runners = new NetworkRunner[1];
                await AddRunner(GameMode.Server, 0);
                break;
            case RunnerMode.ServerAndOnePlayer:
                Runners = new NetworkRunner[2];
                await AddRunner(GameMode.Server, 0);
                await AddRunner(GameMode.Client, 1);
                break;
            case RunnerMode.ServerAndTwoPlayer:
                Runners = new NetworkRunner[3];
                await AddRunner(GameMode.Server, 0);
                await AddRunner(GameMode.Client, 1);
                await AddRunner(GameMode.Client, 2);
                break;
        }

#if UNITY_EDITOR
        var runnerSelector = gameObject.AddComponent<RunnerSelector>();
        runnerSelector.Init(Runners);
        foreach (var runner in Runners)
        {
            if (runner.IsServer)
            {
                runner.GetComponent<NetworkEvents>().PlayerJoined.AddListener((runner, playerRef) => runnerSelector.ChangeVisibleAndProvideInput(Runners.Length - 1));
            }
        }
#endif
    }

    private async Task AddRunner(GameMode gameMode, int index)
    {
        var runner = new GameObject("Runner" + gameMode).AddComponent<NetworkRunner>();
        runner.IsVisible = false;
        runner.ProvideInput = false;

        var events = runner.AddComponent<NetworkEvents>();

        await runner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            CustomLobbyName = "Photon",
            SessionName = "Photon",
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

        if (runner.IsServer) runner.AddComponent<RunnerSpawner>().Init(runner, events);
        if (runner.IsClient) runner.AddComponent<RunnerInputter>().Init(events);

        Runners[index] = runner;
    }
}

public enum RunnerMode
{
    Client,
    Server,
    ServerAndOnePlayer,
    ServerAndTwoPlayer
}

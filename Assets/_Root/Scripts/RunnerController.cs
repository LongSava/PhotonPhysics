using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public enum RunnerMode
{
    Client,
    Server,
    ServerAndOnePlayer,
    ServerAndTwoPlayer
}

public class RunnerController : Singleton<RunnerController>
{
    public RunnerMode Mode;
    public NetworkRunner[] Runners;
    public Action<NetworkEvents> NetworkEventsCreated;
    public Action StartCompleted;

    private async void Start()
    {
        switch (Mode)
        {
            case RunnerMode.Client:
                Runners = new NetworkRunner[1];
                Runners[0] = await AddRunner(GameMode.Client);
                break;
            case RunnerMode.Server:
                Runners = new NetworkRunner[1];
                Runners[0] = await AddRunner(GameMode.Server);
                break;
            case RunnerMode.ServerAndOnePlayer:
                Runners = new NetworkRunner[2];
                Runners[0] = await AddRunner(GameMode.Server);
                Runners[1] = await AddRunner(GameMode.Client);
                break;
            case RunnerMode.ServerAndTwoPlayer:
                Runners = new NetworkRunner[3];
                Runners[0] = await AddRunner(GameMode.Server);
                Runners[1] = await AddRunner(GameMode.Client);
                Runners[2] = await AddRunner(GameMode.Client);
                break;
        }

        StartCompleted?.Invoke();
    }

    private async Task<NetworkRunner> AddRunner(GameMode gameMode)
    {
        var runnerObject = new GameObject("Runner");

        var runner = runnerObject.AddComponent<NetworkRunner>();
        runner.ProvideInput = false;
        runner.IsVisible = false;

        var events = runnerObject.AddComponent<NetworkEvents>();
        events.PlayerJoined = new NetworkEvents.PlayerEvent();
        events.PlayerLeft = new NetworkEvents.PlayerEvent();
        events.OnInput = new NetworkEvents.InputEvent();

        NetworkEventsCreated?.Invoke(events);

        await runner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            CustomLobbyName = "SavaOcean",
            SessionName = "SavaOcean",
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

        return runner;
    }
}


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
        gameObject.AddComponent<RunnerSelector>().Init(Runners);
#endif
    }

    private async Task AddRunner(GameMode gameMode, int index)
    {
        var runner = new GameObject("Runner" + gameMode).AddComponent<NetworkRunner>();
        runner.IsVisible = false;
        runner.ProvideInput = false;

        var events = runner.AddComponent<NetworkEvents>();
        events.OnInput = new NetworkEvents.InputEvent();

        await runner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            CustomLobbyName = "PhotonPhysics",
            SessionName = "PhotonPhysics",
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

        if (runner.IsServer) runner.AddComponent<RunnerSpawner>().Init(runner, events);

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

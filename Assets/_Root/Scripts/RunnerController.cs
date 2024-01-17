using System.Collections.Generic;
using System.Threading.Tasks;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerController : Singleton<RunnerController>
{
    public RunnerMode Mode;
    public List<NetworkRunner> Runners;

    private async void Start()
    {
        switch (Mode)
        {
            case RunnerMode.Client:
                await AddRunner(GameMode.Client);
                break;
            case RunnerMode.Server:
                await AddRunner(GameMode.Server);
                break;
            case RunnerMode.ServerAndOnePlayer:
                await AddRunner(GameMode.Server);
                await AddRunner(GameMode.Client);
                break;
            case RunnerMode.ServerAndTwoPlayer:
                await AddRunner(GameMode.Server);
                await AddRunner(GameMode.Client);
                await AddRunner(GameMode.Client);
                break;
        }

#if UNITY_EDITOR
        gameObject.AddComponent<RunnerSelector>().Init(Runners);
#endif
    }

    private async Task AddRunner(GameMode gameMode)
    {
        var runner = new GameObject("Runner" + gameMode).AddComponent<NetworkRunner>();
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

        Runners.Add(runner);
    }
}

public enum RunnerMode
{
    Client,
    Server,
    ServerAndOnePlayer,
    ServerAndTwoPlayer
}

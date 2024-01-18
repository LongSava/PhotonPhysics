using Fusion;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class RunnerSelector : MonoBehaviour
{
    public NetworkRunner[] Runners;
    public InputActions InputActions;

    public void Init(NetworkRunner[] runners)
    {
        Runners = runners;

        InputActions = new InputActions();
        InputActions.Enable();

        ChangeVisibleAndProvideInput(Runners.Length - 1);

        InputActions.Selector.SelectServerVisibleAndInput.performed += context => ChangeVisibleAndProvideInput(0);
        InputActions.Selector.SelectClient0VisibleAndInput.performed += context => ChangeVisibleAndProvideInput(1);
        InputActions.Selector.SelectClient1VisibleAndInput.performed += context => ChangeVisibleAndProvideInput(2);

        InputActions.Selector.SelectClient0Input.performed += context => ChangeProvideInput(1);
        InputActions.Selector.SelectClient1Input.performed += context => ChangeProvideInput(2);
    }

    private void ChangeVisibleAndProvideInput(int index)
    {
        ChangeVisible(index);
        ChangeProvideInput(index);
    }

    private void ChangeVisible(int index)
    {
        for (int i = 0; i < Runners.Length; i++)
        {
            Visible(Runners[i], i == index);
        }
    }

    private void Visible(NetworkRunner runner, bool enabled)
    {
        runner.IsVisible = enabled;

        foreach (var gameObject in runner.SimulationUnityScene.GetRootGameObjects())
        {
            gameObject.EnableComponentsInChildren<Camera>(enabled);
        }
    }

    private void ChangeProvideInput(int index)
    {
        for (int i = 0; i < Runners.Length; i++)
        {
            ProvideInput(Runners[i], i == index);
        }
    }

    private void ProvideInput(NetworkRunner runner, bool enabled)
    {
        runner.ProvideInput = enabled;

        foreach (var gameObject in runner.SimulationUnityScene.GetRootGameObjects())
        {
            gameObject.EnableComponentsInChildren<InputActionManager>(enabled);
        }
    }
}

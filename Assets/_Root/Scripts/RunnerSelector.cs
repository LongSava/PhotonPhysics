using System.Collections;
using Fusion;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
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

        InputActions.Selector.SelectServerVisibleAndInput.performed += context => ChangeVisibleAndProvideInput(0);
        InputActions.Selector.SelectClient0VisibleAndInput.performed += context => ChangeVisibleAndProvideInput(1);
        InputActions.Selector.SelectClient1VisibleAndInput.performed += context => ChangeVisibleAndProvideInput(2);

        InputActions.Selector.SelectClient0Input.performed += context => ChangeProvideInput(1);
        InputActions.Selector.SelectClient1Input.performed += context => ChangeProvideInput(2);

        StartCoroutine(CheckDevice());
    }

    private IEnumerator CheckDevice()
    {
        while (true)
        {
            int count = 0;
            foreach (var runner in Runners)
            {
                foreach (var gameObject in runner.SimulationUnityScene.GetRootGameObjects())
                {
                    if (gameObject.GetComponentInChildren<Device>() != null)
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == Runners.Length - 1)
            {
                ChangeVisibleAndProvideInput(Runners.Length - 1);
                break;
            }
            yield return null;
        }
    }

    public void ChangeVisibleAndProvideInput(int index)
    {
        ChangeVisible(index);
        ChangeProvideInput(index);
    }

    public void ChangeVisible(int index)
    {
        foreach (var runner in Runners) Visible(runner, false);
        Visible(Runners[index], true);
    }

    public void Visible(NetworkRunner runner, bool enabled)
    {
        runner.IsVisible = enabled;

        foreach (var gameObject in runner.SimulationUnityScene.GetRootGameObjects())
        {
            gameObject.EnableComponentsInChildren<Camera>(enabled);
        }
    }

    private void ChangeProvideInput(int index)
    {
        foreach (var runner in Runners) ProvideInput(runner, false);
        ProvideInput(Runners[index], true);
    }

    private void ProvideInput(NetworkRunner runner, bool enabled)
    {
        runner.ProvideInput = enabled;

        foreach (var gameObject in runner.SimulationUnityScene.GetRootGameObjects())
        {
            gameObject.EnableComponentsInChildren<TrackedPoseDriver>(enabled);
            gameObject.EnableComponentsInChildren<XRBaseController>(enabled);
        }
    }
}

using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class RunnerSelector : MonoBehaviour
{
    public List<NetworkRunner> Runners;
    public InputActions InputActions;

    public void Init(List<NetworkRunner> runners)
    {
        Runners = runners;

        InputActions = new InputActions();
        InputActions.Enable();

        ChangeVisibleAndProvideInput(Runners.Count - 1);

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
        foreach (var runner in Runners) runner.IsVisible = false;
        Runners[index].IsVisible = true;
    }

    private void ChangeProvideInput(int index)
    {
        foreach (var runner in Runners) runner.ProvideInput = false;
        Runners[index].ProvideInput = true;
    }
}

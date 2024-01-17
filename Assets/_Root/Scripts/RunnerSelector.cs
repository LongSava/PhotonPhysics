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
        ChangeVisibleAndProvideInput(Runners.Count - 1);
    }

    private void Update()
    {
        if (InputActions.Selector.SelectServerVisibleAndInput.IsPressed()) ChangeVisibleAndProvideInput(0);
        if (InputActions.Selector.SelectClient0VisibleAndInput.IsPressed()) ChangeVisibleAndProvideInput(1);
        if (InputActions.Selector.SelectClient1VisibleAndInput.IsPressed()) ChangeVisibleAndProvideInput(2);

        if (InputActions.Selector.SelectClient0Input.IsPressed()) ChangeProvideInput(1);
        if (InputActions.Selector.SelectClient1Input1.IsPressed()) ChangeProvideInput(2);
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

using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class RunnerSelector : MonoBehaviour
{
    public List<NetworkRunner> Runners;

    public void Init(List<NetworkRunner> runners)
    {
        Runners = runners;
        ChangeVisibleAndProvideInput(Runners.Count - 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote)) ChangeVisibleAndProvideInput(0);
        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeVisibleAndProvideInput(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeVisibleAndProvideInput(2);

        if (Input.GetKeyDown(KeyCode.Keypad1)) ChangeProvideInput(1);
        if (Input.GetKeyDown(KeyCode.Keypad2)) ChangeProvideInput(2);
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

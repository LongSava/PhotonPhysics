using Fusion;
using UnityEngine;

public class RunnerSelector : MonoBehaviour
{
    public NetworkRunner[] Runners => RunnerController.Instance.Runners;

    private void Start()
    {
        RunnerController.Instance.StartCompleted += Init;
    }

    private void Init()
    {
        var index = RunnerController.Instance.Runners.Length - 1;
        ChangeVisibleAndProvideInputToRunner(index);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote)) ChangeVisibleAndProvideInputToRunner(0);
        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeVisibleAndProvideInputToRunner(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeVisibleAndProvideInputToRunner(2);

        if (Input.GetKeyDown(KeyCode.Keypad1)) ChangeProvideInputToRunner(1);
        if (Input.GetKeyDown(KeyCode.Keypad2)) ChangeProvideInputToRunner(2);
    }

    private void ChangeVisibleAndProvideInputToRunner(int index)
    {
        ChangeVisibleToRunner(index);
        ChangeProvideInputToRunner(index);
    }

    private void ChangeVisibleToRunner(int index)
    {
        foreach (var runner in Runners) runner.IsVisible = false;
        Runners[index].IsVisible = true;
    }

    private void ChangeProvideInputToRunner(int index)
    {
        foreach (var runner in Runners) runner.ProvideInput = false;
        Runners[index].ProvideInput = true;
    }
}

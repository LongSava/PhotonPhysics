using Fusion;
using UnityEngine;

public class RunnerInputter : MonoBehaviour
{
    public InputActions InputActions;
    public InputNetwork InputNetwork;

    public void Init(NetworkEvents events)
    {
        events.OnInput = new NetworkEvents.InputEvent();

        events.OnInput.AddListener(OnInput);

        InputActions = new InputActions();
        InputNetwork = new InputNetwork();
    }

    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        InputNetwork.Direction = InputActions.Player.Move.ReadValue<Vector2>();

        input.Set(InputNetwork);
    }
}

public struct InputNetwork : INetworkInput
{
    public Vector2 Direction;
}

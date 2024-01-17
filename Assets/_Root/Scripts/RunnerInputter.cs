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

        InputActions.Player.Move.performed += context => InputNetwork.Direction = context.ReadValue<Vector2>();
        InputActions.Player.Move.canceled += context => InputNetwork.Direction = Vector2.zero;

        InputActions.Player.Rotate.performed += context => InputNetwork.Rotation = context.ReadValue<Vector2>();
        InputActions.Player.Rotate.canceled += context => InputNetwork.Rotation = Vector2.zero;
    }

    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        input.Set(InputNetwork);
    }
}

public struct InputNetwork : INetworkInput
{
    public Vector2 Direction;
    public Vector2 Rotation;
}

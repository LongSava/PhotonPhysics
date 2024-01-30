using Fusion;
using UnityEngine;

public class Inputter : NetworkBehaviour
{
    public InputActions InputActions;
    [Networked] public InputDataNetwork InputData { get; set; }

    public override void Spawned()
    {
        if (HasInputAuthority)
        {
            InputActions = new InputActions();
            InputActions.Enable();
            Runner.GetComponent<NetworkEvents>().OnInput.AddListener(OnInput);
        }
    }

    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var inputData = GetInputData();

        input.Set(inputData);
    }

    public virtual InputDataNetwork GetInputData()
    {
        return new InputDataNetwork
        {
            Direction = InputActions.Player.Move.ReadValue<Vector2>(),
            Rotation = InputActions.Player.Rotate.ReadValue<Vector2>(),
            GripLeft = InputActions.Player.GripLeft.ReadValue<float>(),
            GripRight = InputActions.Player.GripRight.ReadValue<float>()
        };
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputDataNetwork inputData) && HasStateAuthority)
        {
            InputData = inputData;
        }
    }
}

public struct InputDataNetwork : INetworkInput
{
    public Vector2 Direction;
    public Vector2 Rotation;
    public Vector3 PositionHead;
    public Quaternion RotationHead;
    public Vector3 PositionLeftHand;
    public Quaternion RotationLeftHand;
    public Vector3 PositionRightHand;
    public Quaternion RotationRightHand;
    public float GripLeft;
    public float GripRight;
}

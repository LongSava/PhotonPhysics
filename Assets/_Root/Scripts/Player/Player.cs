using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Rigidbody Rigidbody;
    public Model Model;
    public LocalDevice LocalDevice;
    public RemoteDevice RemoteDevice;
    public Transform InterpolateTarget;
    public InputActions InputActions;
    [Networked] InputDataNetwork InputData { get; set; }

    public override async void Spawned()
    {
        Model = await Runner.InstantiateOrigin<Model>("Model", InterpolateTarget);

        if (HasInputAuthority)
        {
            InputActions = new InputActions();
            InputActions.Enable();

            Runner.GetComponent<NetworkEvents>().OnInput.AddListener(OnInput);

            LocalDevice = await Runner.InstantiateOrigin<LocalDevice>("LocalDevice", InterpolateTarget);
            Model.Init(LocalDevice.Head, LocalDevice.LeftHand, LocalDevice.RightHand);
        }
        else
        {
            RemoteDevice = await Runner.InstantiateOrigin<RemoteDevice>("RemoteDevice", InterpolateTarget);
            Model.Init(RemoteDevice.Head, RemoteDevice.LeftHand, RemoteDevice.RightHand);
        }
    }

    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var inputData = new InputDataNetwork
        {
            Direction = InputActions.Player.Move.ReadValue<Vector2>(),
            Rotation = InputActions.Player.Rotate.ReadValue<Vector2>(),
            PositionHead = LocalDevice.Head.position,
            RotationHead = LocalDevice.Head.rotation,
            PositionLeftHand = LocalDevice.LeftHand.position,
            RotationLeftHand = LocalDevice.LeftHand.rotation,
            PositionRightHand = LocalDevice.RightHand.position,
            RotationRightHand = LocalDevice.RightHand.rotation,
            GripLeft = InputActions.Player.GripLeft.ReadValue<float>(),
            GripRight = InputActions.Player.GripRight.ReadValue<float>()
        };

        input.Set(inputData);
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputDataNetwork inputData) && HasStateAuthority)
        {
            InputData = inputData;
        }

        if (HasInputAuthority || HasStateAuthority)
        {
            Rigidbody.MovePosition(transform.position + transform.forward * InputData.Direction.y * Runner.DeltaTime);
            transform.Rotate(new Vector3(0, InputData.Rotation.x, 0) * Runner.DeltaTime * 100);
        }

        if (!HasInputAuthority && RemoteDevice != null)
        {
            RemoteDevice.Head.position = InputData.PositionHead;
            RemoteDevice.Head.rotation = InputData.RotationHead;
            RemoteDevice.LeftHand.position = InputData.PositionLeftHand;
            RemoteDevice.LeftHand.rotation = InputData.RotationLeftHand;
            RemoteDevice.RightHand.position = InputData.PositionRightHand;
            RemoteDevice.RightHand.rotation = InputData.RotationRightHand;
        }

        if (Model != null)
        {
            Model.GripLeft(InputData.GripLeft);
            Model.GripRight(inputData.GripRight);
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

using System;
using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Rigidbody Rigidbody;
    public Model Model;
    public Device Device;
    public Pose Pose;
    public Transform InterpolateTarget;
    public InputActions InputActions;
    [Networked] InputDataNetwork InputData { get; set; }

    public override async void Spawned()
    {
        Model = await Runner.InstantiateOrigin<Model>("Model", InterpolateTarget);

        if (HasInputAuthority)
        {
            Device = await Runner.InstantiateOrigin<Device>("Device", InterpolateTarget);
            Model.Init(Device.Head, Device.LeftHand, Device.RightHand);
        }
        else
        {
            Pose = await Runner.InstantiateOrigin<Pose>("Pose", InterpolateTarget);
            Model.Init(Pose.Head, Pose.LeftHand, Pose.RightHand);
        }

        if (HasInputAuthority)
        {
            Runner.GetComponent<NetworkEvents>().OnInput.AddListener(OnInput);
            InputActions = new InputActions();
            InputActions.Enable();
        }
    }

    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var inputData = new InputDataNetwork
        {
            Direction = InputActions.Player.Move.ReadValue<Vector2>(),
            Rotation = InputActions.Player.Rotate.ReadValue<Vector2>(),
            PositionHead = Device.Head.position,
            RotationHead = Device.Head.rotation,
            PositionLeftHand = Device.LeftHand.position,
            RotationLeftHand = Device.LeftHand.rotation,
            PositionRightHand = Device.RightHand.position,
            RotationRightHand = Device.RightHand.rotation
        };

        input.Set(inputData);
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputDataNetwork inputData))
        {
            Rigidbody.MovePosition(transform.position + transform.forward * inputData.Direction.y * Runner.DeltaTime);
            transform.Rotate(new Vector3(0, inputData.Rotation.x, 0) * Runner.DeltaTime * 100);
        }

        if (HasStateAuthority)
        {
            InputData = inputData;
        }

        if (!HasInputAuthority && Pose != null)
        {
            Pose.Head.position = InputData.PositionHead;
            Pose.Head.rotation = InputData.RotationHead;
            Pose.LeftHand.position = InputData.PositionLeftHand;
            Pose.LeftHand.rotation = InputData.RotationLeftHand;
            Pose.RightHand.position = InputData.PositionRightHand;
            Pose.RightHand.rotation = InputData.RotationRightHand;
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
}

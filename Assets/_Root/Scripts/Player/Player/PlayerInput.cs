using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : Inputter
{
    public Player Player;

    private void Awake()
    {
        Player = GetComponent<Player>();
    }

    public override async void Spawned()
    {
        var model = await Runner.Instantiate<Model>("Model");
        var device = await Runner.Instantiate<Device>(HasInputAuthority ? "DeviceLocal" : "DeviceRemote");

        Player.Init(model, device);

        base.Spawned();
    }

    public override InputDataNetwork GetInputData()
    {
        var inputData = base.GetInputData();

        inputData.PositionHead = Player.Device.Head.position;
        inputData.RotationHead = Player.Device.Head.rotation;
        inputData.PositionLeftHand = Player.Device.LeftHand.position;
        inputData.RotationLeftHand = Player.Device.LeftHand.rotation;
        inputData.PositionRightHand = Player.Device.RightHand.position;
        inputData.RotationRightHand = Player.Device.RightHand.rotation;

        return inputData;
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (HasInputAuthority || HasStateAuthority)
        {
            Player.Rigidbody.MovePosition(transform.position + transform.forward * InputData.Direction.y * Runner.DeltaTime);
            transform.Rotate(new Vector3(0, InputData.Rotation.x, 0) * Runner.DeltaTime * 100);
        }

        if (!HasInputAuthority && Player.Device != null)
        {
            Player.Device.Head.position = InputData.PositionHead;
            Player.Device.Head.rotation = InputData.RotationHead;
            Player.Device.LeftHand.position = InputData.PositionLeftHand;
            Player.Device.LeftHand.rotation = InputData.RotationLeftHand;
            Player.Device.RightHand.position = InputData.PositionRightHand;
            Player.Device.RightHand.rotation = InputData.RotationRightHand;
        }

        if (Player.Model != null)
        {
            Player.Model.GripLeft(InputData.GripLeft);
            Player.Model.GripRight(InputData.GripRight);
        }
    }
}

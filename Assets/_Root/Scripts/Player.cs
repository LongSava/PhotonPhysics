using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Rigidbody Rigidbody;
    public RunnerInputter RunnerInputter;
    public Model Model;
    public Device Device;
    public Pose Pose;
    public Transform InterpolateTarget;

    public override async void Spawned()
    {
        Model = await Runner.InstantiateOrigin<Model>("Model", InterpolateTarget);

        if (HasInputAuthority)
        {
            Device = await Runner.InstantiateOrigin<Device>("Device", InterpolateTarget);
            Model.Init(Device.Head, Device.LeftHand, Device.RightHand);

            RunnerInputter = Runner.GetComponent<RunnerInputter>();
            RunnerInputter.InputActions.Enable();
        }
        else
        {
            Pose = await Runner.InstantiateOrigin<Pose>("Pose", InterpolateTarget);
            Model.Init(Pose.Head, Pose.LeftHand, Pose.RightHand);
        }

    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputNetwork inputNetwork))
        {
            Rigidbody.MovePosition(transform.position + transform.forward * inputNetwork.Direction.y * Runner.DeltaTime);
            transform.Rotate(new Vector3(0, inputNetwork.Rotation.x, 0) * Runner.DeltaTime * 100);
        }
    }
}

using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Rigidbody Rigidbody;
    public RunnerInputter RunnerInputter;
    public Model Model;
    public Device Device;

    public override async void Spawned()
    {
        Model = await Runner.InstantiateOrigin<Model>("Model", transform);

        if (HasInputAuthority)
        {
            RunnerInputter = Runner.GetComponent<RunnerInputter>();
            RunnerInputter.InputActions.Enable();

            Device = await Runner.InstantiateOrigin<Device>("Device", transform);

            Model.Init(Device.Head, Device.LeftHand, Device.RightHand);
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

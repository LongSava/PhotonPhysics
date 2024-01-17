using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Rigidbody Rigidbody;
    public RunnerInputter RunnerInputter;
    public Model Model;
    public IK IK;
    public Transform InterpolateTarget;

    public override async void Spawned()
    {
        Model = await Utils.InstantiateOrigin<Model>("Model", InterpolateTarget);
        IK = await Utils.InstantiateOrigin<IK>("IK", InterpolateTarget);

        if (HasInputAuthority)
        {
            await IK.InitDevice();
            RunnerInputter = Runner.GetComponent<RunnerInputter>();
            RunnerInputter.InputActions.Enable();
        }
        else
        {
            await IK.InitPose();
        }

        Model.Init(IK.Head, IK.LeftHand, IK.RightHand);
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

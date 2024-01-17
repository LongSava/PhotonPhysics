using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Rigidbody Rigidbody;
    public RunnerInputter RunnerInputter;
    public Transform Model;

    public override async void Spawned()
    {
        if (HasInputAuthority)
        {
            RunnerInputter = Runner.GetComponent<RunnerInputter>();
            RunnerInputter.InputActions.Enable();

            var camera = await Utils.GetAsset<Camera>("Camera");
            camera = Runner.InstantiateInRunnerScene(camera);
            camera.transform.SetParent(Model);
            camera.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out InputNetwork inputNetwork))
        {
            Rigidbody.MovePosition(transform.position + transform.forward * inputNetwork.Direction.y * Runner.DeltaTime);
            transform.Rotate(new Vector3(0, inputNetwork.Direction.x, 0) * Runner.DeltaTime * 100);
        }
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Model Model;
    public Device Device;
    public Transform InterpolateTarget;

    public void Init(Model model, Device device)
    {
        Model = model;
        Device = device;

        Model.transform.SetParent(InterpolateTarget);
        Model.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        Device.transform.SetParent(InterpolateTarget);
        Device.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        Model.Init(Device.Head, Device.LeftHand, Device.RightHand);
    }
}

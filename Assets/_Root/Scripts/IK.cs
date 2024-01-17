using System.Threading.Tasks;
using UnityEngine;

public class IK : MonoBehaviour
{
    public Transform Head;
    public Transform LeftHand;
    public Transform RightHand;

    public async Task InitDevice()
    {
        var device = await Utils.InstantiateOrigin<Device>("Device", transform);
        Head = device.Head;
        LeftHand = device.LeftHand;
        RightHand = device.RightHand;
    }

    public async Task InitPose()
    {
        var pose = await Utils.InstantiateOrigin<Pose>("Pose", transform);
        Head = pose.Head;
        LeftHand = pose.LeftHand;
        RightHand = pose.RightHand;
    }
}

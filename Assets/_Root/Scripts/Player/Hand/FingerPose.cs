using UnityEngine;

public class FingerPose : MonoBehaviour
{
    public Transform[] Joints;
    public Pose PoseOpen;
    public Pose PoseClose;

    public void SetPose(float value)
    {
        for (int i = 0; i < Joints.Length; i++)
        {
            Joints[i].localPosition = Vector3.Lerp(PoseOpen.Positions[i], PoseClose.Positions[i], value);
            Joints[i].localRotation = Quaternion.Lerp(PoseOpen.Rotations[i], PoseClose.Rotations[i], value);
        }
    }

    public void SavePoseOpen()
    {
        PoseOpen.SavePose(Joints);
    }

    public void SavePoseClose()
    {
        PoseClose.SavePose(Joints);
    }
}

using UnityEngine;

public class Finger : MonoBehaviour
{
    public Tip Tip;
    public float BendCollision;
    public Transform[] Joints;
    public Pose PoseOpen;
    public Pose PoseClose;

    public void SetPose(float value)
    {
        value = Mathf.Clamp(value, 0, BendCollision);
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

    public void SetBendCollision(float value)
    {
        BendCollision = value;
    }

    public float GetBendCollision(Collider collider)
    {
        var bendCollision = GetBendCollisionInRange(0, 0.1f, collider) - 0.1f;
        bendCollision = GetBendCollisionInRange(bendCollision, 0.01f, collider);
        return bendCollision;
    }

    public float GetBendCollisionInRange(float value, float offset, Collider collider)
    {
        for (int i = 0; i < 10; i++)
        {
            SetPose(value);
            if (Tip.CollisionWith(collider)) return value;
            value += offset;
        }

        return value;
    }
}

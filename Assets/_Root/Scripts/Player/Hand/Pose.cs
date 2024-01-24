using UnityEngine;

public class Pose : MonoBehaviour
{
    public Transform[] Joints;
    [SerializeField][HideInInspector] public Vector3[] PositionOpen;
    [SerializeField][HideInInspector] public Quaternion[] RotationOpen;
    [SerializeField][HideInInspector] public Vector3[] PositionClose;
    [SerializeField][HideInInspector] public Quaternion[] RotationClose;

    public void Set(float value)
    {
        for (int i = 0; i < Joints.Length; i++)
        {
            Joints[i].localPosition = Vector3.Lerp(PositionOpen[i], PositionClose[i], value);
            Joints[i].localRotation = Quaternion.Lerp(RotationOpen[i], RotationClose[i], value);
        }
    }

    public void Reset()
    {
        Joints = new Transform[3];
        Joints[0] = transform;
        Joints[1] = transform.GetChild(0);
        Joints[2] = transform.GetChild(0).GetChild(0);
    }

    public void SavePoseOpen()
    {
        PositionOpen = new Vector3[Joints.Length];
        RotationOpen = new Quaternion[Joints.Length];

        SavePose(PositionOpen, RotationOpen);
    }

    public void SavePoseClose()
    {
        PositionClose = new Vector3[Joints.Length];
        RotationClose = new Quaternion[Joints.Length];

        SavePose(PositionClose, RotationClose);
    }

    public void SavePose(Vector3[] position, Quaternion[] rotation)
    {
        for (int i = 0; i < Joints.Length; i++)
        {
            position[i] = Joints[i].localPosition;
            rotation[i] = Joints[i].localRotation;
        }
    }
}

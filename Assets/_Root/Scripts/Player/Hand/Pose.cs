using UnityEngine;

public class Pose : MonoBehaviour
{
    [SerializeField] public Vector3[] Position;
    [SerializeField] public Quaternion[] Rotation;

    public void SavePose(Transform[] joints)
    {
        Position = new Vector3[joints.Length];
        Rotation = new Quaternion[joints.Length];
        for (int i = 0; i < joints.Length; i++)
        {
            Position[i] = joints[i].localPosition;
            Rotation[i] = joints[i].localRotation;
        }
    }
}

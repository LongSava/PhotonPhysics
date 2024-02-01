using UnityEngine;

public class Pose : MonoBehaviour
{
    [SerializeField] public Vector3[] Positions;
    [SerializeField] public Quaternion[] Rotations;

    public void SavePose(Transform[] joints)
    {
        Positions = new Vector3[joints.Length];
        Rotations = new Quaternion[joints.Length];
        for (int i = 0; i < joints.Length; i++)
        {
            Positions[i] = joints[i].localPosition;
            Rotations[i] = joints[i].localRotation;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pose))]
public class Finger : MonoBehaviour
{
    public Tip Tip;
    public Pose Pose;
    public float BendCollision;

    public void SetPose(float value)
    {
        Pose.Set(Mathf.Clamp(value, 0, BendCollision));
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
            Pose.Set(value);
            if (Tip.CollisionWith(collider)) return value;
            value += offset;
        }

        return value;
    }

    public void Reset()
    {
        var childs = new List<Transform>() { transform };
        childs = Utils.GetChildDepth(transform, childs);

        Pose = GetComponent<Pose>();
        Pose.Joints = new Transform[childs.Count - 1];
        Pose.PositionOpen = new Vector3[childs.Count - 1];
        Pose.PositionClose = new Vector3[childs.Count - 1];
        Pose.RotationOpen = new Quaternion[childs.Count - 1];
        Pose.RotationClose = new Quaternion[childs.Count - 1];

        for (int i = 0; i < childs.Count; i++)
        {
            if (i < childs.Count - 1)
            {
                var joint = childs[i];
                Pose.Joints[i] = joint;
                Pose.PositionOpen[i] = Pose.PositionClose[i] = joint.localPosition;
                Pose.RotationOpen[i] = Pose.RotationClose[i] = joint.localRotation;
            }
            else
            {
                Tip = Utils.AddComponent<Tip>(childs[i]);
            }
        }

        BendCollision = 1;
    }
}

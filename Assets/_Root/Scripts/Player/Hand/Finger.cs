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
}

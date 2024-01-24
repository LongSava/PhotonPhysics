using UnityEngine;

[RequireComponent(typeof(Bend), typeof(Pose))]
public class Finger : MonoBehaviour
{
    public Tip Tip;
    public Bend Bend;
    public Pose Pose;

    public void Reset()
    {
        Bend = GetComponent<Bend>();
        Pose = GetComponent<Pose>();
        Tip = GetComponentInChildren<Tip>();
    }

    private void Update()
    {
        if (Bend.State == Bend.BendState.Open || (Bend.State == Bend.BendState.Close && !Tip.IsCollision()))
        {
            Pose.SetPose(Bend.Current);
        }
    }

    public void SetBend(float value)
    {
        Bend.Set(value);
    }
}

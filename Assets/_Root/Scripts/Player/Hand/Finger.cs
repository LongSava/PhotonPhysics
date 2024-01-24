using UnityEngine;

[RequireComponent(typeof(Bend), typeof(Pose))]
public class Finger : MonoBehaviour
{
    public Tip Tip;
    public Bend Bend;
    public Pose Pose;
    public float LastBend = -1;

    public void Reset()
    {
        Tip = GetComponentInChildren<Tip>();
        Bend = GetComponent<Bend>();
        Pose = GetComponent<Pose>();

        Bend.Reset();
        Pose.Reset();
    }

    private void Update()
    {
        if (Bend.State == Bend.BendState.Open)
        {
            if (LastBend == -1)
            {
                Pose.Set(Bend.Current);
                Pose.EnableTrigger(false);
            }
            else if (Bend.Current < LastBend)
            {
                Pose.Set(Bend.Current);
                Pose.EnableTrigger(false);
                LastBend = -1;
            }
        }

        if (Bend.State == Bend.BendState.Close)
        {
            if (LastBend == -1)
            {
                if (Tip.IsCollision())
                {
                    LastBend = Bend.Current;
                }
                else
                {
                    Pose.Set(Bend.Current);
                    Pose.EnableTrigger(true);
                }
            }
        }
    }
}

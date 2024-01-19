using UnityEngine;

public class Hand : MonoBehaviour
{
    public Finger[] Fingers;
    [Range(0, 1)] public float Bend;

    public void SetBend(float bend)
    {
        foreach (var finger in Fingers) finger.Bend(bend);
    }

    [ContextMenu("Reset Bend")]
    public void ResetBend()
    {
        SetBend(Bend);
    }

    [ContextMenu("Save Pose Open")]
    public void SavePoseOpen()
    {
        foreach (var finger in Fingers) finger.SavePoseOpen();
    }

    [ContextMenu("Save Pose Close")]
    public void SavePoseClose()
    {
        foreach (var finger in Fingers) finger.SavePoseClose();
    }
}

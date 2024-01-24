using UnityEngine;

public class Hand : MonoBehaviour
{
    public Finger[] Fingers;
    [Range(0, 1)] public float BendValue;

    public void Reset()
    {
        Fingers = GetComponentsInChildren<Finger>();
        foreach (var finger in Fingers) finger.Reset();
    }

    public void SetBend(float value)
    {
        foreach (var finger in Fingers) finger.Bend.Set(value);
    }
}

using UnityEngine;

public class Hand : MonoBehaviour
{
    public Finger[] Fingers;
    [Range(0, 1)] public float Bend;

    public void SetBend(float bend)
    {
        foreach (var finger in Fingers) finger.Bend(bend);
    }
}

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Hand))]
public class HandEditor : Editor
{
    public Hand Hand;
    public float Radius;
    public float BendValue;

    private void OnEnable()
    {
        Hand = (Hand)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            if (BendValue != Hand.BendValue)
            {
                BendValue = Hand.BendValue;
                Hand.SetBend(Hand.BendValue);
            }
        }
        else
        {
            if (BendValue != Hand.BendValue)
            {
                BendValue = Hand.BendValue;
                foreach (var finger in Hand.Fingers) finger?.Pose?.Set(Hand.BendValue);
            }

            if (Radius != Hand.Radius)
            {
                Radius = Hand.Radius;
                Debug.DrawRay(Hand.Palm.position, Hand.Palm.forward * Radius, Color.red, Time.deltaTime);
            }
        }


        GUILayout.Space(20);
        if (GUILayout.Button("Save Pose Open", GUILayout.Height(50)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Open", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger?.Pose.SavePoseOpen();
            }
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Save Pose Close", GUILayout.Height(50)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Close", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger?.Pose.SavePoseClose();
            }
        }
    }
}

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Hand))]
public class HandEditor : Editor
{
    public Hand Hand;

    private void OnEnable()
    {
        Hand = (Hand)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Hand.SetBend(Hand.Bend);

        GUILayout.Space(20);
        if (GUILayout.Button("Save Pose Open", GUILayout.Height(50)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Open", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger.SavePoseOpen();
            }
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Save Pose Close", GUILayout.Height(50)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Close", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger.SavePoseClose();
            }
        }
    }
}

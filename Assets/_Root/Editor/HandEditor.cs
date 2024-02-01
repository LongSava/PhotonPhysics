using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Hand))]
public class HandEditor : Editor
{
    public Hand Hand;
    public float BendValue;
    public float BendValueOld;

    private void OnEnable()
    {
        Hand = (Hand)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Bend Value", GUILayout.Width(70));
        BendValue = GUILayout.HorizontalSlider(BendValue, 0, 1);
        if (BendValue != BendValueOld)
        {
            BendValueOld = BendValue;
            if (Application.isPlaying) Hand.SetBend(BendValue);
            else foreach (var finger in Hand.Fingers) finger?.FingerPose?.SetPose(BendValue);
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Setup Hand", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Setup Hand", "Are you sure?", "OK", "Cancel"))
            {
                SetupHand();
            }
        }
        if (GUILayout.Button("Reset Value", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Reset Value", "Are you sure?", "OK", "Cancel"))
            {
                ResetValue();
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        if (GUILayout.Button("Save Pose Open", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Open", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger?.FingerPose.SavePoseOpen();
            }
        }

        GUILayout.Space(10);
        if (GUILayout.Button("Save Pose Close", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Close", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger?.FingerPose.SavePoseClose();
            }
        }

        EditorUtility.SetDirty(Hand);
    }

    public void SetupHand()
    {
        Hand.Bend = Hand.GetComponent<Bend>();
        Hand.Bend.State = Bend.BendState.Idle;
        Hand.Bend.Speed = 10;

        var fingers = new List<Finger>();
        for (int i = 0; i < Hand.transform.childCount; i++)
        {
            var child = Hand.transform.GetChild(i);
            if (child.GetComponent<Palm>() == null)
            {
                var finger = child.TryAddComponent<Finger>();
                SetupFinger(finger);
                fingers.Add(finger);
            }
        }
        Hand.Fingers = fingers.ToArray();

        Hand.Palm = Hand.GetComponentInChildren<Palm>();
        if (Hand.Palm == null)
        {
            Hand.Palm = new GameObject("Palm").AddComponent<Palm>();
            Hand.Palm.transform.SetParent(Hand.transform);
            Hand.Palm.transform.localPosition = Vector3.zero;
            Hand.Palm.transform.localRotation = Quaternion.identity;
            Hand.Palm.transform.localScale = Vector3.one;
            Hand.Palm.Radius = 0.05f;
        }
    }

    public void SetupFinger(Finger finger)
    {
        var childs = new List<Transform>() { finger.transform };
        childs = finger.transform.GetChildDepth(childs);

        finger.FingerPose = finger.GetComponent<FingerPose>();
        finger.FingerPose.Joints = new Transform[childs.Count];

        if (finger.FingerPose.PoseOpen == null) finger.FingerPose.PoseOpen = finger.FingerPose.gameObject.AddComponent<Pose>();

        if (finger.FingerPose.PoseClose == null) finger.FingerPose.PoseClose = finger.FingerPose.gameObject.AddComponent<Pose>();

        for (int i = 0; i < childs.Count; i++)
        {
            var joint = childs[i];
            finger.FingerPose.Joints[i] = joint;

            if (i == childs.Count - 1)
            {
                finger.Tip = new GameObject("Tip").AddComponent<Tip>();
                finger.Tip.transform.SetParent(joint);
                finger.Tip.transform.localPosition = Vector3.zero;
                finger.Tip.transform.localRotation = Quaternion.identity;
                finger.Tip.transform.localScale = Vector3.one;
            }
        }

        finger.BendCollision = 1;
    }

    public void ResetValue()
    {
        if (Hand.Bend != null) Hand.Bend.Speed = 10;
        if (Hand.Palm != null) Hand.Palm.Radius = 0.05f;
        if (Hand.Fingers != null && Hand.Fingers.Length > 0)
        {
            foreach (var finger in Hand.Fingers)
            {
                finger.BendCollision = 1;

                var length = finger.FingerPose.Joints.Length;

                finger.FingerPose.PoseOpen.Positions = new Vector3[length];
                finger.FingerPose.PoseOpen.Rotations = new Quaternion[length];
                finger.FingerPose.PoseClose.Positions = new Vector3[length];
                finger.FingerPose.PoseClose.Rotations = new Quaternion[length];

                for (int i = 0; i < length; i++)
                {
                    finger.FingerPose.PoseOpen.Positions[i] = finger.FingerPose.PoseClose.Positions[i] = finger.FingerPose.Joints[i].localPosition;
                    finger.FingerPose.PoseOpen.Rotations[i] = finger.FingerPose.Joints[i].localRotation;
                    finger.FingerPose.PoseClose.Rotations[i] = Quaternion.Euler(0, -90, 0);
                }
            }
        }
    }
}

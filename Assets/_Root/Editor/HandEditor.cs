using System.Collections.Generic;
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

        GUILayout.Space(10);
        if (GUILayout.Button("Setup", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Setup", "Are you sure?", "OK", "Cancel"))
            {
                SetupHand();
            }
        }

        GUILayout.Space(10);
        if (GUILayout.Button("Save Pose Open", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Open", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger?.Pose.SavePoseOpen();
            }
        }

        GUILayout.Space(10);
        if (GUILayout.Button("Save Pose Close", GUILayout.Height(30)))
        {
            if (EditorUtility.DisplayDialog("Save Pose Close", "Are you sure?", "OK", "Cancel"))
            {
                foreach (var finger in Hand.Fingers) finger?.Pose.SavePoseClose();
            }
        }
    }

    public void SetupHand()
    {
        Hand.Bend = Hand.GetComponent<Bend>();
        Hand.Bend.State = Bend.BendState.Idle;
        Hand.Bend.Speed = 10;

        var count = 0;
        for (int i = 0; i < Hand.transform.childCount; i++)
        {
            var child = Hand.transform.GetChild(i);
            if (child.childCount > 0)
            {
                count++;
            }
            if (child.name == "Palm")
            {
                Hand.Palm = child;
            }
        }

        Hand.Fingers = new Finger[count];
        for (int i = 0; i < Hand.transform.childCount; i++)
        {
            var child = Hand.transform.GetChild(i);
            if (child.childCount > 0)
            {
                var finger = Utils.AddComponent<Finger>(child);
                SetupFinger(finger);
                Hand.Fingers[i] = finger;
            }
        }

        if (Hand.Palm == null) Hand.Palm = new GameObject("Palm").transform;
        Hand.Palm.SetParent(Hand.transform);
        Hand.Palm.localPosition = Vector3.zero;
        Hand.Palm.localRotation = Quaternion.identity;
        Hand.Palm.localScale = Vector3.one;

        Radius = 0.01f;
    }

    public void SetupFinger(Finger finger)
    {
        var childs = new List<Transform>() { finger.transform };
        childs = Utils.GetChildDepth(finger.transform, childs);

        finger.Pose = finger.GetComponent<Pose>();
        finger.Pose.Joints = new Transform[childs.Count - 1];
        finger.Pose.PositionOpen = new Vector3[childs.Count - 1];
        finger.Pose.PositionClose = new Vector3[childs.Count - 1];
        finger.Pose.RotationOpen = new Quaternion[childs.Count - 1];
        finger.Pose.RotationClose = new Quaternion[childs.Count - 1];

        for (int i = 0; i < childs.Count; i++)
        {
            if (i < childs.Count - 1)
            {
                var joint = childs[i];
                finger.Pose.Joints[i] = joint;
                finger.Pose.PositionOpen[i] = finger.Pose.PositionClose[i] = joint.localPosition;
                finger.Pose.RotationOpen[i] = finger.Pose.RotationClose[i] = joint.localRotation;
            }
            else
            {
                finger.Tip = Utils.AddComponent<Tip>(childs[i]);
            }
        }

        finger.BendCollision = 1;
    }
}

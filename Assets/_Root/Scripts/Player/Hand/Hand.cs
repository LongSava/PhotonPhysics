using UnityEngine;

[RequireComponent(typeof(Bend))]
public class Hand : MonoBehaviour
{
    public Finger[] Fingers;
    public Transform Palm;
    public LayerMask LayerMask;
    public Bend Bend;
    public Collider[] Colliders = new Collider[1];
    [Range(0, 1)] public float BendValue;
    public float Radius;
    public Grabble Grabble;

    private void Update()
    {
        foreach (var finger in Fingers) finger.SetPose(Bend.Current);
    }

    public void SetBend(float value)
    {
        if (value != Bend.Target)
        {
            if (Bend.GetState(value) == Bend.BendState.Close) AddBendCollision();
            else if (Bend.GetState(value) == Bend.BendState.Open) RemoveBendCollision();
            Bend.SetTarget(value);
        }
    }

    public void AddBendCollision()
    {
        if (Colliders[0] == null)
        {
            Physics.OverlapSphereNonAlloc(Palm.position, Radius, Colliders, LayerMask, QueryTriggerInteraction.Ignore);

            if (Colliders[0] != null)
            {
                foreach (var finger in Fingers) finger.SetBendCollision(finger.GetBendCollision(Colliders[0]));
                Grab();
            }
            else
            {
                foreach (var finger in Fingers) finger.SetBendCollision(1);
            }
        }
    }

    public void RemoveBendCollision()
    {
        if (Colliders[0] != null)
        {
            Colliders[0] = null;
            UnGrab();
        }
    }

    public void Grab()
    {
        if (Colliders[0].TryGetComponent(out Grabble))
        {
            Grabble.SetTarget(transform);
        }
    }

    public void UnGrab()
    {
        Grabble?.RemoveTarget(transform);
    }

    public void Reset()
    {
        Bend = GetComponent<Bend>();
        Bend.Reset();

        var count = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.childCount > 0)
            {
                count++;
            }
            if (child.name == "Palm")
            {
                Palm = child;
            }
        }

        Fingers = new Finger[count];
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.childCount > 0)
            {
                var finger = Utils.AddComponent<Finger>(child);
                finger.Reset();
                Fingers[i] = finger;
            }
        }

        if (Palm == null) Palm = new GameObject("Palm").transform;
        Palm.SetParent(transform);
        Palm.localPosition = Vector3.zero;
        Palm.localRotation = Quaternion.identity;
        Palm.localScale = Vector3.one;

        Radius = 0.01f;
    }
}

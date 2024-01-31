using UnityEngine;

[RequireComponent(typeof(Bend))]
public class Hand : MonoBehaviour
{
    public Finger[] Fingers;
    public Transform Palm;
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
            Physics.OverlapSphereNonAlloc(Palm.position, Radius, Colliders, 1 << LayerMask.NameToLayer("Grabble"), QueryTriggerInteraction.Ignore);

            if (Colliders[0] != null)
            {
                foreach (var finger in Fingers) finger.SetBendCollision(finger.GetBendCollision(Colliders[0]));
                if (Colliders[0].TryGetComponent(out Grabble)) Grabble.SetTarget(transform);
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
            Grabble?.RemoveTarget(transform);
        }
    }
}

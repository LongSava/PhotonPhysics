using UnityEngine;

public class Tip : MonoBehaviour
{
    public Collider[] colliders = new Collider[1];

    public bool IsCollision()
    {
        colliders[0] = null;
        Physics.OverlapSphereNonAlloc(transform.position, 0.008f, colliders, 1 << LayerMask.NameToLayer("Grabble"), QueryTriggerInteraction.Ignore);
        return colliders[0] != null;
    }
}

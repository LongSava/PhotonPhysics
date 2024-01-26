using UnityEngine;

public class Tip : MonoBehaviour
{
    public Collider[] colliders = new Collider[1];

    public bool CollisionWith(Collider collider)
    {
        colliders[0] = null;
        Physics.OverlapSphereNonAlloc(transform.position, 0.001f, colliders, 1 << collider.gameObject.layer, QueryTriggerInteraction.Ignore);
        return colliders[0] == collider;
    }
}

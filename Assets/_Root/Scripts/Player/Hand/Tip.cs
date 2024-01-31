using UnityEngine;

public class Tip : MonoBehaviour
{
    public Collider[] colliders = new Collider[1];
    public float Radius = 0.001f;

    public bool CollisionWith(Collider collider)
    {
        colliders[0] = null;
        Physics.OverlapSphereNonAlloc(transform.position, Radius, colliders, 1 << collider.gameObject.layer, QueryTriggerInteraction.Ignore);
        return colliders[0] == collider;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

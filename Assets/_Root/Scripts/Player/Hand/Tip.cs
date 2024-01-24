using UnityEngine;

public class Tip : MonoBehaviour
{
    public Collider[] colliders = new Collider[1];

    public bool IsCollision()
    {
        Physics.OverlapSphereNonAlloc(transform.position, 1, colliders, LayerMask.NameToLayer("Grabble"), QueryTriggerInteraction.Ignore);
        return colliders[0] != null;
    }
}

using UnityEngine;

public class Grabble : MonoBehaviour
{
    public Transform Target;
    public Transform ParentOrigin;
    public Rigidbody Rigidbody;
    public bool IsKinematicOrigin;

    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Grabble");
        ParentOrigin = transform.parent;
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody != null) IsKinematicOrigin = Rigidbody.isKinematic;
    }

    public void SetTarget(Transform target)
    {
        if (Target != target)
        {
            Target = target;
            transform.parent = target;
            if (Rigidbody != null) Rigidbody.isKinematic = true;
        }
    }

    public void RemoveTarget(Transform target)
    {
        if (Target == target)
        {
            Target = null;
            transform.parent = ParentOrigin;
            if (Rigidbody != null) Rigidbody.isKinematic = IsKinematicOrigin;
        }
    }
}

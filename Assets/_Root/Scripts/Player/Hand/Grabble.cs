using UnityEngine;

public class Grabble : MonoBehaviour
{
    public Transform Target;
    public Rigidbody Rigidbody;
    public Vector3 PositionOffset;
    public Quaternion RotationOffset;

    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Grabble");
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void SetTarget(Transform target)
    {
        if (Target != target)
        {
            Target = target;
            PositionOffset = Target.InverseTransformPoint(transform.position);
            RotationOffset = Quaternion.Inverse(Target.rotation) * transform.rotation;
        }
    }

    public void RemoveTarget(Transform target)
    {
        if (Target == target)
        {
            Target = null;
        }
    }

    private void FixedUpdate()
    {
        if (Target != null)
        {
            var targetPosition = Target.TransformPoint(PositionOffset);
            var targetRotation = Target.rotation * RotationOffset;

            if (Rigidbody != null && Rigidbody.useGravity && !Rigidbody.isKinematic)
            {
                Rigidbody.velocity = (targetPosition - transform.position) / Time.fixedDeltaTime;
                Rigidbody.angularVelocity = transform.rotation.GetAngularVelocity(targetRotation, Time.fixedDeltaTime);
            }
            else
            {
                transform.position = targetPosition;
                transform.rotation = targetRotation;
            }
        }
    }
}

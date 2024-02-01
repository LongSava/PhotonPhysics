using UnityEngine;

public class Palm : MonoBehaviour
{
    public float Radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

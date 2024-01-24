using UnityEngine;

public class Bend : MonoBehaviour
{
    public enum BendState { Open, Idle, Close }
    public float Speed;
    public BendState State;
    public float Target;
    public float Current;

    private void Update()
    {
        if (Current < Target)
        {
            State = BendState.Close;
            Current += Time.deltaTime * Speed;
            if (Current > Target)
            {
                Current = Target;
            }
        }
        else if (Current > Target)
        {
            State = BendState.Open;
            Current -= Time.deltaTime * Speed;
            if (Current < Target)
            {
                Current = Target;
            }
        }
        else
        {
            State = BendState.Idle;
        }
    }

    public void Set(float target)
    {
        if (target != Target)
        {
            Target = target;
        }
    }
}

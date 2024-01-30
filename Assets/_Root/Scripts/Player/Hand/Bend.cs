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
        UpdateState();
        UpdateValue();
    }

    public void UpdateState()
    {
        State = GetState(Target);
    }

    public BendState GetState(float target)
    {
        return Current < target ? BendState.Close : Current > target ? BendState.Open : BendState.Idle;
    }

    public void UpdateValue()
    {
        switch (State)
        {
            case BendState.Close:
                Current = Mathf.Clamp(Current + Time.deltaTime * Speed, 0, Target);
                break;
            case BendState.Open:
                Current = Mathf.Clamp(Current - Time.deltaTime * Speed, Target, 1);
                break;
        }
    }

    public void SetTarget(float target)
    {
        Target = Mathf.Clamp01(target);
    }

    public void Reset()
    {
        Speed = 10;
        State = BendState.Idle;
    }
}

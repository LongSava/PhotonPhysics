using RootMotion.FinalIK;
using UnityEngine;

public class Model : MonoBehaviour
{
    public VRIK VRIK;
    public Hand LeftHand;
    public Hand RightHand;

    public void Init(Transform head, Transform leftHand, Transform rightHand)
    {
        VRIK.solver.spine.headTarget = head;
        VRIK.solver.leftArm.target = leftHand;
        VRIK.solver.rightArm.target = rightHand;
    }

    public void Calibrate(Transform head, Transform leftHand, Transform rightHand)
    {
        VRIKCalibrator.Calibrate(VRIK, head, leftHand, rightHand, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero);
    }

    public void GripLeft(float value)
    {
        LeftHand.SetBend(value);
    }

    public void GripRight(float value)
    {
        RightHand.SetBend(value);
    }
}

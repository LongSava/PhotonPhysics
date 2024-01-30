using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Model Model;
    public InputActions InputActions;

    private void Start()
    {
        InputActions = new InputActions();
        InputActions.Enable();

        InputActions.Player.GripRight.performed += context => Model.GripRight(1);
        InputActions.Player.GripRight.canceled += context => Model.GripRight(0);
    }
}

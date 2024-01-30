using UnityEngine;

[RequireComponent(typeof(Player))]
public class TestInput : MonoBehaviour
{
    public Player Player;
    public InputActions InputActions;

    private void Awake()
    {
        Player = GetComponent<Player>();
        InputActions = new InputActions();
        InputActions.Enable();
    }

    private void FixedUpdate()
    {
        Player.Model.GripRight(InputActions.Player.GripRight.ReadValue<float>());
        Player.Model.GripLeft(InputActions.Player.GripLeft.ReadValue<float>());
        Player.Rigidbody.MovePosition(transform.position + transform.forward * InputActions.Player.Move.ReadValue<Vector2>().y * Time.deltaTime);
        Player.transform.Rotate(new Vector3(0, InputActions.Player.Rotate.ReadValue<Vector2>().x, 0) * Time.deltaTime * 100);
    }
}

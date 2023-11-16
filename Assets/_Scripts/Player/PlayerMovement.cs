using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerMovement : SerializedMonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _tempMovementSpeed;
    [SerializeField] private Vector2 _movementVector = Vector2.zero;

    private void OnEnable()
    {
        PlayerInputManager.OnMovementInput += OnMovementInput;
    }
    private void OnDisable()
    {
        PlayerInputManager.OnMovementInput -= OnMovementInput;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movementVector * _tempMovementSpeed;
    }

    private void OnMovementInput(Vector2 movementVector)
    {
        _movementVector = movementVector;
    }
}

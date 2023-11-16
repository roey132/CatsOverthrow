using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance;

    private PlayerInputs _playerInputs;

    public static event Action<Vector2> OnMovementInput;
    public static event Action<bool> OnNormalShootInput;
    public static event Action<bool> OnSpecialShootInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _playerInputs = new PlayerInputs();
    }
    private void OnEnable()
    {
        _playerInputs.Enable();
        _playerInputs.Player.Movement.performed += OnMovementPerformed;
        _playerInputs.Player.Movement.canceled += OnMovementCanceled;
        _playerInputs.Player.NormalShoot.performed += OnShootPerformed;
        _playerInputs.Player.NormalShoot.canceled += OnShootCanceled;
        _playerInputs.Player.SpecialShoot.performed += OnSpeicalShootPerformed;
        _playerInputs.Player.SpecialShoot.canceled += OnSpeicalShootCanceled;
    }
    private void OnDisable()
    {
        _playerInputs.Disable();
        _playerInputs.Player.Movement.performed -= OnMovementPerformed;
        _playerInputs.Player.Movement.canceled -= OnMovementCanceled;
        _playerInputs.Player.NormalShoot.performed -= OnShootPerformed;
        _playerInputs.Player.SpecialShoot.performed -= OnShootPerformed;
        _playerInputs.Player.SpecialShoot.performed -= OnSpeicalShootPerformed;
        _playerInputs.Player.SpecialShoot.canceled -= OnSpeicalShootCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext inputValue)
    {
        OnMovementInput?.Invoke(inputValue.ReadValue<Vector2>());
    }
    private void OnMovementCanceled(InputAction.CallbackContext inputValue)
    {
        OnMovementInput?.Invoke(Vector2.zero);
    }

    private void OnShootPerformed(InputAction.CallbackContext inputValue)
    {
        OnNormalShootInput?.Invoke(true);
    }
    private void OnShootCanceled(InputAction.CallbackContext inputValue)
    {
        OnNormalShootInput?.Invoke(false);
    }

    private void OnSpeicalShootPerformed(InputAction.CallbackContext inputValue)
    {
        OnSpecialShootInput?.Invoke(true);
    }

    private void OnSpeicalShootCanceled(InputAction.CallbackContext inputValue)
    {
        OnSpecialShootInput?.Invoke(false);
    }
}
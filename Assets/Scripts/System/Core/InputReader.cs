using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviourSingleton<InputReader>, PlayerInputActions.IPlayerActions
{
    #region Variables // ���� �׷�

    private PlayerInputActions playerInputActions;

    public Vector2 moveDirection = Vector2.zero;
    public Vector2 lookDirection;

    public bool isRunning = false; // �޸��� ����
    public bool isCrouching = false; // �ޱ׸��� ����
    public bool isCrawling = false; // ���� ����

    #region Input Actions

    public Action OnPerformJump;    // ���� �׼�

    #endregion

    #endregion

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Trigger the jump action
            OnPerformJump?.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookDirection = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isRunning = true;
        }
        else if (context.canceled)
        {
            isRunning = false;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isCrouching = true;
        }
        else if (context.canceled)
        {
            isCrouching = false;
        }
    }

    public void OnCrwel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isCrawling = !isCrawling;
        }
    }

    #region Callbacks Register

    private void OnEnable()
    {
        // Enable the input actions
        playerInputActions.Enable();
        playerInputActions.Player.SetCallbacks(this);
    }

    private void OnDisable()
    {
        // Disable the input actions
        playerInputActions.Disable();
        playerInputActions.Player.SetCallbacks(null);
    }

    #endregion
}

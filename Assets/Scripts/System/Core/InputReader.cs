using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviourSingleton<InputReader>, PlayerInputActions.IPlayerActions
{
    #region Variables // ���� �׷�

    private PlayerInputActions playerInputActions;

    public Vector2 moveDirection = Vector2.zero;
    public Vector2 lookDirection;

    #region Input Actions

    public Action OnPerformJump;    // ���� �׼�
    public Action OnActivateRun;    // �޸��� �׼� Ȱ��ȭ
    public Action OnDeactivateRun;  // �޸��� �׼� ��Ȱ��ȭ

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
            OnActivateRun?.Invoke();
        }
        else if (context.canceled)
        {
            OnDeactivateRun?.Invoke();
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

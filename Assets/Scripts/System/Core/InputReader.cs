using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviourSingleton<InputReader>, PlayerInputActions.IPlayerActions
{
    #region Variables // 변수 그룹

    private PlayerInputActions playerInputActions;

    public Vector2 moveDirection = Vector2.zero;
    public Vector2 lookDirection;

    public bool isRunning = false; // 달리기 상태
    public bool isCrouching = false; // 쭈그리기 상태
    public bool isCrawling = false; // 기어가기 상태

    #region Input Actions

    public Action OnPerformJump;    // 점프 액션

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

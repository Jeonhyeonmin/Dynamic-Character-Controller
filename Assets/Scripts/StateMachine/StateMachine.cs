using UnityEngine;

public class StateMachine
{
    public State CurrentBaseState { get; private set; }
    public State CurrentSubState { get; private set; }

    #region Base State

    public void ChangeBaseState(State newState, PlayerDynamicController player)
    {
        CurrentBaseState?.Exit(player);
        CurrentBaseState = newState;
        CurrentBaseState?.Enter(player);
    }

    public void AwakeBaseState(PlayerDynamicController player)
    {
        CurrentBaseState?.Awake(player);
    }

    public void UpdateBaseState(PlayerDynamicController player)
    {
        CurrentBaseState?.Update(player);
    }

    public void FixedUpdateBaseState(PlayerDynamicController player)
    {
        CurrentBaseState?.FixedUpdate(player);
    }

    #endregion

    #region Sub State

    public void ChangeSubState(State newState, PlayerDynamicController player)
    {
        CurrentSubState?.Exit(player);
        CurrentSubState = newState;
        CurrentSubState?.Enter(player);
    }

    public void AwakeSubState(PlayerDynamicController player)
    {
        CurrentSubState?.Awake(player);
    }

    public void UpdateSubState(PlayerDynamicController player)
    {
        CurrentSubState?.Update(player);
    }

    public void FixedUpdateSubState(PlayerDynamicController player)
    {
        CurrentSubState?.FixedUpdate(player);
    }

    #endregion
}

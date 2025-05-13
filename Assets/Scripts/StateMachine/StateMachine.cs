using UnityEngine;

public class StateMachine
{
    public State CurrentBaseState { get; private set; }
    public State CurrentSubState { get; private set; }

    #region Base State

    public void ChangeBaseState(State newState, PlayerDynamicController player)
    {
        if (CurrentBaseState != null)
            CurrentBaseState.Exit(player);
        CurrentBaseState = newState;
        CurrentBaseState.Awake(player);
        CurrentBaseState.Enter(player);
    }

    public void AwakeBaseState(PlayerDynamicController player)
    {
        CurrentBaseState.Awake(player);
    }

    public void UpdateBaseState(PlayerDynamicController player)
    {
        CurrentBaseState.Update(player);
    }

    public void FixedUpdateBaseState(PlayerDynamicController player)
    {
        CurrentBaseState.FixedUpdate(player);
    }

    #endregion

    #region Sub State

    public void ChangeSubState(State newState, PlayerDynamicController player)
    {
        if (CurrentSubState != null)
            CurrentSubState.Exit(player);
        CurrentSubState = newState;
        CurrentSubState.Awake(player);
        CurrentSubState.Enter(player);
    }

    public void AwakeSubState(PlayerDynamicController player)
    {
        CurrentSubState?.Awake(player);
    }

    public void UpdateSubState(PlayerDynamicController player)
    {
        CurrentSubState.Update(player);
    }

    public void FixedUpdateSubState(PlayerDynamicController player)
    {
        CurrentSubState.FixedUpdate(player);
    }

    #endregion
}

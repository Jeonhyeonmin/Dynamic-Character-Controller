using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; }

    public void ChangeState(State newState, PlayerDynamicController player)
    {
        CurrentState?.Exit(player);
        CurrentState = newState;
        CurrentState?.Enter(player);
    }

    public void Update(PlayerDynamicController player)
    {
        CurrentState?.Update(player);
    }

    public void FixedUpdate(PlayerDynamicController player)
    {
        CurrentState?.FixedUpdate(player);
    }
}

using System;
using UnityEngine;

public abstract class State
{
    public virtual void Awake(PlayerDynamicController player) 
    {
        string EnterState = String.Empty;
        try { EnterState = $"<color=white>{(player.stateMachine.CurrentBaseState == this ? player.stateMachine.CurrentBaseState?.GetType().Name : player.stateMachine.CurrentSubState?.GetType().Name)}</color>"; }
        catch (NullReferenceException ex) { Debug.LogError($"<color=#F48884><b>상태 진입 출력 에러 :</color></b> <color=white>{ex.Message}</color>"); }
        finally
        {
            Debug.Log(player.stateMachine.CurrentBaseState == this
                ? $"<color=#98FF98>베이스 상태 진입 :</color> {EnterState}"
                : $"<color=#800080>서브 상태 진입 :</color> {EnterState}"
            );

            if (player.stateMachine.CurrentBaseState == this)
                player.playerPreviousBaseStateType = (PlayerPreviousBaseStateType)player.playerBaseStateType;
            else if (player.stateMachine.CurrentSubState == this)
                player.playerPreviousSubStateType = (PlayerPreviousSubStateType)player.playerSubStateType;
        }
    }

    public virtual void Enter(PlayerDynamicController player) 
    {
        if (player.stateMachine.CurrentBaseState == this)
            player.anim.SetInteger(AnimatorHash.Int.PLAYER_BASE_STATE_TYPE_HASH, player.playerBaseStateType.GetHashCode());
        else if (player.stateMachine.CurrentSubState == this)
        {
            player.anim.SetInteger(AnimatorHash.Int.PLAYER_PREVIOUS_STATE_TYPE_HASH, player.playerSubStateType.GetHashCode());
            player.anim.SetInteger(AnimatorHash.Int.PLAYER_STATE_TYPE_HASH, player.playerSubStateType.GetHashCode());
        }
            
    }

    public virtual void Update(PlayerDynamicController player) { }
    public virtual void FixedUpdate(PlayerDynamicController player) { }
    public virtual void Exit(PlayerDynamicController player) { }
}

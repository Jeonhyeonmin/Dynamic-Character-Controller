using System;
using UnityEngine;

public abstract class State
{
    public virtual void Enter(PlayerDynamicController player) 
    {
        try { Debug.Log($"<color=#77D9FA><b>���� ���� :</color></b> <color=white>{player.stateMachine.CurrentState?.GetType().Name}</color>"); }
        catch (NullReferenceException ex) { Debug.LogError($"<color=#F48884><b>���� ���� ��� ���� :</color></b> <color=white>{ex.Message}</color>"); }

        player.anim.SetInteger("PlayerBaseStateType", (int)player.playerBaseStateType);
    }

    public virtual void Update(PlayerDynamicController player) { }
    public virtual void FixedUpdate(PlayerDynamicController player) { }
    public virtual void Exit(PlayerDynamicController player) { }
}

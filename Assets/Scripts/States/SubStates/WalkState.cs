using UnityEngine;

public class WalkState : State
{
    public override void Awake(PlayerDynamicController player)
    {
        base.Awake(player);
        player.playerSubStateType = PlayerSubStateType.Walk;
    }

    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);
    }
}

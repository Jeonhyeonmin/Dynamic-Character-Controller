using UnityEngine;

public class StandState : State
{
    public override void Awake(PlayerDynamicController player)
    {
        base.Awake(player);
        player.playerBaseStateType = PlayerBaseStateType.Stand;
    }

    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);
    }
}

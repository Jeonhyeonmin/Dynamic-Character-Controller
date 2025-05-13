using AmplifyAnimationPack;
using UnityEngine;

public class IdleState : State
{
    public override void Awake(PlayerDynamicController player)
    {
        base.Awake(player);
        player.playerSubStateType = PlayerSubStateType.Idle;
    }

    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);
    }

    public override void Update(PlayerDynamicController player)
    {
        base.Update(player);

        if (InputReader.Instance.moveDirection != Vector2.zero)
        {
            player.stateMachine.ChangeSubState(new WalkState(), player);
        }
    }
}

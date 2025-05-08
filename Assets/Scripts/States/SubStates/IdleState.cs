using AmplifyAnimationPack;
using UnityEngine;

public class IdleState : State
{
    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);

        player.anim.SetInteger(AnimatorHash.Int.PLAYER_STATE_TYPE_HASH, player.playerSubStateType.GetHashCode());
    }

    public override void Update(PlayerDynamicController player)
    {
        base.Update(player);

        if (InputReader.Instance.moveDirection != Vector2.zero)
        {
            //player.subStateMachine.ChangeSubState(new WalkState(), player);
        }
    }
}

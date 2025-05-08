using AmplifyAnimationPack;
using UnityEngine;

public class IdleState : State
{
    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);

        player.anim.SetInteger(AnimatorHash.Int.PLAYER_BASE_STATE_TYPE_HASH, player.playerBaseStateType.GetHashCode());
        player.anim.SetInteger(AnimatorHash.Int.PLAYER_STATE_TYPE_HASH, player.playerStateType.GetHashCode());
        player.anim.SetInteger(AnimatorHash.Int.PLAYER_PREVIOUS_STATE_TYPE_HASH, player.playerPreviousStateType.GetHashCode());
    }

    public override void Update(PlayerDynamicController player)
    {
        base.Update(player);

        if (InputReader.Instance.moveDirection != Vector2.zero)
        {
            //player.stateMachine.ChangeState(new WalkState(), player);
        }
    }
}

using UnityEngine;

public class WalkState : State
{
    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);

        player.anim.SetInteger(AnimatorHash.Int.PLAYER_STATE_TYPE_HASH, player.playerSubStateType.GetHashCode());
    }
}

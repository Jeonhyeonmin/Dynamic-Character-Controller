using UnityEngine;

public class StandState : State
{
    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);

        player.anim.SetInteger(AnimatorHash.Int.PLAYER_BASE_STATE_TYPE_HASH, player.playerBaseStateType.GetHashCode());
    }
}

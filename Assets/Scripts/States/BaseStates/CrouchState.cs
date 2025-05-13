using UnityEngine;

public class CrouchState : State
{
    public override void Awake(PlayerDynamicController player)
    {
        base.Awake(player);
        player.playerBaseStateType = PlayerBaseStateType.Crouch;
    }

    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);
    }

    public override void Update(PlayerDynamicController player)
    {
        if (!InputReader.Instance.isCrouching && !InputReader.Instance.isCrawling)
        {
            player.stateMachine.ChangeBaseState(new StandState(), player);
        }
        else if (InputReader.Instance.isCrawling)
        {
            player.stateMachine.ChangeBaseState(new CrawlState(), player);
        }
    }
}

using UnityEngine;

public class CrawlState : State
{
    public override void Awake(PlayerDynamicController player)
    {
        base.Awake(player);
        player.playerBaseStateType = PlayerBaseStateType.Crawl;
    }

    public override void Enter(PlayerDynamicController player)
    {
        base.Enter(player);
    }

    public override void Update(PlayerDynamicController player)
    {
        if (!InputReader.Instance.isCrawling && !InputReader.Instance.isCrouching)
        {
            if (player.playerPreviousBaseStateType == PlayerPreviousBaseStateType.Crouch)
            {
                player.stateMachine.ChangeBaseState(new CrouchState(), player);
            }
            else
            {
                player.stateMachine.ChangeBaseState(new StandState(), player);
            }
        }
        else if (!InputReader.Instance.isCrawling && InputReader.Instance.isCrouching)
        {
            player.stateMachine.ChangeBaseState(new CrouchState(), player);
        }
    }
}

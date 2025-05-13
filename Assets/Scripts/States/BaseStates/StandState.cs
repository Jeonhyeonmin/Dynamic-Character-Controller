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

    public override void Update(PlayerDynamicController player)
    {
        if (InputReader.Instance.isCrouching)
        {
            player.stateMachine.ChangeBaseState(new CrouchState(), player);
        }
        else if (InputReader.Instance.isCrawling)
        {
            player.stateMachine.ChangeBaseState(new CrawlState(), player);
        }
    }
}

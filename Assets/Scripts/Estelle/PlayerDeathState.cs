using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager StateManager)
    {
        StateManager.PlayAnimation("Death");
    }

    public override void UpdateState(PlayerStateManager StateManager)
    {

    }

    public override void OnJumpPressed(PlayerStateManager StateManager)
    {
        // We can't jump when we are dead
        return;
    }

    public override void OnHidePressed(PlayerStateManager StateManager)
    {
        // We can't hide when we are dead
        return;
    }

}

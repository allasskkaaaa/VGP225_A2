using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager StateManager)
    {
        StateManager.PlayAnimation("Run");
    }

    public override void UpdateState(PlayerStateManager StateManager)
    {
        if (Player_InputHandler.player_InputHandler.moveInput.ReadValue<Vector2>().magnitude < 0.1f)
        {
            StateManager.SwitchState(StateManager.idleState);
        }
    }
}

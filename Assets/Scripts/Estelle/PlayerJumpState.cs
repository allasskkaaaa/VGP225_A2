using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager StateManager)
    {
        StateManager.PlayAnimation("Jump");
    }

    public override void UpdateState(PlayerStateManager StateManager)
    {
        // Only transition when coming down, and not when going up
        if(StateManager.cc.isGrounded && StateManager.velocity.y <= 0.0f)
        {
            if (Player_InputHandler.player_InputHandler.moveInput.ReadValue<Vector2>().magnitude > 0.1f)
            {
                StateManager.SwitchState(StateManager.moveState);
            } else
            {
                StateManager.SwitchState(StateManager.idleState);
            }
        }
    
    }

   
}

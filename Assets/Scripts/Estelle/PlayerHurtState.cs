using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerBaseState
{
    

    public override void EnterState(PlayerStateManager StateManager)
    { StateManager.PlayAnimation("Hit");
      StateManager.HurtTimeLeft = StateManager.HurtDuration;
    }


    public override void UpdateState(PlayerStateManager StateManager)
    {
        StateManager.HurtTimeLeft -= Time.deltaTime;

        if (StateManager.HurtTimeLeft < 0)
        {
            StateManager.IsHurt = false;
            if (Player_InputHandler.player_InputHandler.moveInput.ReadValue<Vector2>().magnitude > 0.1f)
            {
                StateManager.SwitchState(StateManager.moveState);
            }
            else
            {
                StateManager.SwitchState(StateManager.idleState);
            }
        }


    }

    public override void OnJumpPressed(PlayerStateManager StateManager)
    {
        // We can't jump when we are hurt
        return;
    }

    public override void OnHidePressed(PlayerStateManager StateManager)
    {
        // We can't hide when we are hurt
        return;
    }
}

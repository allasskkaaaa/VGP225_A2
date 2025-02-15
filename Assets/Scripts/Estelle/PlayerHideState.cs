using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHideState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager StateManager)
    {
        StateManager.PlayAnimation("Sit");
        StateManager.HideTimeLeft = StateManager.HideDuration;
    }

    public override void UpdateState(PlayerStateManager StateManager)
    {
        StateManager.HideTimeLeft -= Time.deltaTime;

        if (StateManager.HideTimeLeft < 0 )
        {
            StateManager.IsHiding = false;

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
        // We can't jump when we are hiding
        return;
    }

    public override void OnHidePressed(PlayerStateManager StateManager)
    {
        // We are already busy hiding
        return;
    }




}

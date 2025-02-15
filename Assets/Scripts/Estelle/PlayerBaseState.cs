
using UnityEngine;

public abstract class PlayerBaseState 
{
    public abstract void EnterState(PlayerStateManager StateManager);

    public abstract void UpdateState(PlayerStateManager StateManager);

    public virtual void OnJumpPressed(PlayerStateManager StateManager)
    {
        // By Default the player is allowed to jump
        if (!StateManager.cc.isGrounded)
            return;

        StateManager.SwitchState(StateManager.jumpState);

        StateManager.velocity.y = Mathf.Sqrt(StateManager.jumpForce * -2f * StateManager.gravity); // Apply jump force
    }

    public virtual void OnHidePressed(PlayerStateManager StateManager)
    {
        // By Default the player is allowed to hide

        // If it's not grounded, do nothing
        if (!StateManager.cc.isGrounded)
            return;

        StateManager.SwitchState(StateManager.hideState);
        StateManager.velocity = Vector3.zero;
        StateManager.IsHiding = true;
    }

}

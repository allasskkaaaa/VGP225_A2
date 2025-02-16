using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerAttackState : ServerBaseState
{
    public override void EnterState(ServerController StateManager)
    {
        StateManager.PlayAnimation("Hit");
    }

    public override void UpdateState(ServerController StateManager)
    {
        Vector3 directionToPlayer = PlayerStateManager.Instance.transform.position - StateManager.transform.position;
        directionToPlayer = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);

        StateManager.transform.right = Vector3.Slerp(StateManager.transform.right, -directionToPlayer.normalized, Time.deltaTime * StateManager.rotationSpeed);


    }

    public override void OnAnimationEnded(ServerController StateManager)
    {
        StateManager.SwitchState(StateManager.attackCooldownState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerAttackCooldownState : ServerBaseState
{
    float attackCooldownTimeLeft;
    public override void EnterState(ServerController StateManager)
    {
        StateManager.PlayAnimation("Idle");
        attackCooldownTimeLeft = StateManager.cooldownDuration;
    }

    public override void UpdateState(ServerController StateManager)
    {
        attackCooldownTimeLeft -= Time.deltaTime;

        if (attackCooldownTimeLeft < 0)
        {
            if (StateManager.playerInStrikeRange)
            {
                StateManager.SwitchState(StateManager.attackState);
            }
            else
            {
                StateManager.WalkToRandomTable();
                StateManager.SwitchState(StateManager.walkState);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerIdleState : ServerBaseState
{
    private float idleTimeLeft;


    public override void EnterState(ServerController StateManager)
    {
        StateManager.PlayAnimation("Idle");
        idleTimeLeft = StateManager.idleDuration;
    }

    public override void UpdateState(ServerController StateManager)
    {
        idleTimeLeft -= Time.deltaTime;

        if (idleTimeLeft < 0 )
        {
            StateManager.WalkToRandomTable();
            StateManager.SwitchState(StateManager.walkState);
        }

        if (StateManager.playerInStrikeRange == true)
        { StateManager.SwitchState(StateManager.attackState); }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class ServerWalkingState : ServerBaseState
{
    public override void EnterState(ServerController StateManager)
    {
        StateManager.serverAgent.isStopped = false;
        StateManager.PlayAnimation("Walking");
    }

    public override void UpdateState(ServerController StateManager)
    {
        if (StateManager.playerInStrikeRange == true)
        {
            StateManager.serverAgent.isStopped = true;
            StateManager.SwitchState(StateManager.attackState);
        }

        if (Vector3.Distance(StateManager.serverAgent.transform.position, StateManager.tables[StateManager.selectedTableIndex].position) < 0.5f)
        {
            StateManager.serverAgent.isStopped = true;
            StateManager.SwitchState(StateManager.idleState);
        }
    }
}

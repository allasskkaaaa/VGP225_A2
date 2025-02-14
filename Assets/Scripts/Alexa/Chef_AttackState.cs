using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef_AttackState : Chef_BaseState
{
    
    public override void EnterState(Chef_StateManager chef) 
    {
        Debug.Log("Entering Attack State");
    }

    public override void UpdateState(Chef_StateManager chef)
    {
        if (chef.target == null)
        {
            chef.SwitchState(chef.idleState);
            return;
        }
        Vector3 targetPosition = chef.target.transform.position;
        targetPosition.y = chef.transform.position.y; // Keep Y position unchanged

        chef.transform.LookAt(targetPosition);
    }


    public override void OnCollisionStay(Chef_StateManager chef, Collider collision)
    {

    }

    public override void OnCollisionExit(Chef_StateManager chef, Collider collision)
    {
        chef.SwitchState(chef.idleState);
    }
}

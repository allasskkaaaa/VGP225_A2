using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Chef_CooldownState : Chef_BaseState
{
    private float timer;
    
    public override void EnterState(Chef_StateManager chef)
    {
        Debug.Log("Entering Cooldown State");
        timer = chef.cooldownTime;
       
    }

    public override void UpdateState(Chef_StateManager chef)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            chef.SwitchState(chef.attackState);
        }
    }

    public override void OnCollisionStay(Chef_StateManager chef, Collider collision)
    {

    }

    public override void OnCollisionExit(Chef_StateManager chef, Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            chef.target = null;
    }
}

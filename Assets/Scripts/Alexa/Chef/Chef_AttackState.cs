using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chef_AttackState : Chef_BaseState
{
    private Shoot shoot;
    private float atkSpeed;
    private bool animPlayed;
    public override void EnterState(Chef_StateManager chef) 
    {
        Debug.Log("Entering Attack State");
        animPlayed = false;
        //Shooting 
        atkSpeed = chef.attackSpeed; //Sets attack speed to chef's attack speed
        shoot = chef.gameObject.GetComponent<Shoot>(); //Gets shoot script from chef
        //shoot.ThrowProjectile(); //Launches projectile
    }

    public override void UpdateState(Chef_StateManager chef)
    {
        if (chef.target == null) //If the chef target isn't set, it returns to idle
        {
            chef.SwitchState(chef.idleState);
            return;
        }

        //Look at target
        Vector3 targetPosition = chef.target.transform.position;
        targetPosition.y = chef.transform.position.y; // Keep Y position unchanged


        chef.transform.LookAt(targetPosition);
        chef.throwPoint.LookAt(targetPosition); //Always aim at the player

        if (atkSpeed > 0) //Counts down using attack speed and shoots once its reached below 0
        {
            atkSpeed -= Time.deltaTime;
        }
        else
        {
            chef.anim.SetTrigger("Throwing");
            atkSpeed = chef.attackSpeed;
        }
        

    }


    public override void OnCollisionStay(Chef_StateManager chef, Collider collision)
    {

    }

    public override void OnCollisionExit(Chef_StateManager chef, Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            chef.SwitchState(chef.idleState);
    }
}

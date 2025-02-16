using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Hide : Cat_BaseState
{
    private float timer;
    private float hideTimer;
    public override void EnterState(Cat_StateManager cat)
    {
        Debug.Log("Entering Hiding State");

        timer = cat.chargeTime;
        hideTimer = cat.changeSpotCooldown;
        cat.anim.Play("Sit");
    }

    public override void UpdateState(Cat_StateManager cat)
    {
        //If player hasn't approached cat for a set time, it searches for a new hding spot
        if (hideTimer > 0)
        {
            hideTimer -= Time.deltaTime;
        }
        else
        {
            cat.SwitchState(cat.searchState);
        }
    }

    public override void OnTriggerStay(Cat_StateManager cat, Collider collision)
    {

        if (collision.gameObject.CompareTag("Player")) //If player enters cat radius
        {
            cat.gameObject.transform.LookAt(collision.transform); //Look at player
            hideTimer = cat.changeSpotCooldown; //Resets timer for cat to search for new hiding spot

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            } else
            {
                cat.SwitchState(cat.attackState);
            }
        }
        else
        {
        }
    }

    public override void OnTriggerExit(Cat_StateManager cat, Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer = cat.chargeTime; //Reset the charge up to attack if the player leaves cat radius
        }
    }
}

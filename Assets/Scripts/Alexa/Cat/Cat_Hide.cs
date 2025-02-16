using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Hide : Cat_BaseState
{
    private float timer;
    public override void EnterState(Cat_StateManager cat)
    {
        Debug.Log("Entering Hiding State");

        timer = cat.chargeTime;
    }

    public override void UpdateState(Cat_StateManager cat)
    {

    }

    public override void OnTriggerStay(Cat_StateManager cat, Collider collision)
    {

        if (collision.gameObject.CompareTag("Player")) //If player enters cat radius
        {
            Debug.Log("Player detected");
            cat.gameObject.transform.LookAt(collision.transform); //Look at player

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
            Debug.Log(collision.gameObject.name + " detected");
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

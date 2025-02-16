using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat_Search : Cat_BaseState
{
    private float searchCooldown = 2f;
    private float timer;
    private GameObject[] hidingSpots;
    private bool spotFound = false;
    private float arriveThreshold = 1f; 

    public override void EnterState(Cat_StateManager cat)
    {
        Debug.Log("Entering Search State");
        //Search for hiding places
        hidingSpots = GameObject.FindGameObjectsWithTag("Hiding Spot");

        spotFound = false;

    }

    public override void UpdateState(Cat_StateManager cat)
    {
        if (hidingSpots.Length <= 0 && !spotFound)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                hidingSpots = GameObject.FindGameObjectsWithTag("Hiding Spot");
                timer = searchCooldown;
            }
        }
        
        if (hidingSpots.Length >= 0 && !spotFound) 
        {
            spotFound = true;
            int randomHidingSpot = Random.Range(0, hidingSpots.Length);

            cat.navMeshAgent.destination = hidingSpots[randomHidingSpot].transform.position;
            cat.anim.Play("Walk");
        }

        if (HasReachedDestination(cat))
        {
            cat.SwitchState(cat.hideState);
        }

    }

    bool HasReachedDestination(Cat_StateManager cat)
    {
        if (!cat.navMeshAgent.pathPending && cat.navMeshAgent.remainingDistance <= arriveThreshold && cat.navMeshAgent.velocity.sqrMagnitude == 0f)
        {
            return true;
        }
        return false;
    }


    public override void OnTriggerEnter(Cat_StateManager cat, Collider collision)
    {

    }

    public override void OnTriggerStay(Cat_StateManager cat, Collider collision)
    {

    }

    public override void OnTriggerExit(Cat_StateManager cat, Collider collision)
    {

    }
}

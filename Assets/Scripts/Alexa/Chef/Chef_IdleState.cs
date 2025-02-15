using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chef_IdleState : Chef_BaseState
{
    private float nextRotationTime;
    private Quaternion targetRotation;

    public override void EnterState(Chef_StateManager chef)
    {
        Debug.Log("Entering Idle State");
        nextRotationTime = Time.time + Random.Range(1f, 5f); // Set initial random delay
    }

    public override void UpdateState(Chef_StateManager chef)
    {
        if (Time.time >= nextRotationTime) // If it's time to rotate
        {
            SetRandomRotation(chef);
            nextRotationTime = Time.time + Random.Range(2f, 5f); // Pick next random interval
        }

        // Smoothly rotate towards the target rotation
        chef.transform.rotation = Quaternion.Slerp(chef.transform.rotation, targetRotation, Time.deltaTime * 2f);
    }

    public override void OnCollisionStay(Chef_StateManager chef, Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
           { 
            chef.target = collision.gameObject; //If player, set them as the chef's target
            chef.SwitchState(chef.attackState);
        }
    }

    public override void OnCollisionExit(Chef_StateManager chef, Collider collision)
    {
        chef.target = null;
    }

    private void SetRandomRotation(Chef_StateManager chef)
    {
        float randomY = Random.Range(0f, 360f); // Pick a random Y-axis angle
        targetRotation = Quaternion.Euler(0, randomY, 0); // Keep only Y rotation

    }
}

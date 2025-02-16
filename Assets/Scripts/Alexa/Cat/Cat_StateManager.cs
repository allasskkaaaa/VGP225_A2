using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class Cat_StateManager : MonoBehaviour
{

    //Player properties
    public NavMeshAgent navMeshAgent;
    public float chargeTime = 5f;
    public float pounceForce = 10f;
    public float pounceCooldown = 3f;
    public float changeSpotCooldown = 10f;

    Cat_BaseState currentState;

    public Cat_Attack attackState = new Cat_Attack();
    public Cat_Hide hideState = new Cat_Hide();
    public Cat_Search searchState = new Cat_Search();

    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

        currentState = searchState;

        currentState.EnterState(this);
    }

    
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Cat_BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerStay(Collider collision)
    {
        currentState.OnTriggerStay(this, collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        currentState.OnTriggerExit(this, collision);
    }
}

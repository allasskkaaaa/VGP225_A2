using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef_StateManager : MonoBehaviour
{
    Chef_BaseState currentState;

    public Chef_IdleState idleState = new Chef_IdleState();
    public Chef_AttackState attackState = new Chef_AttackState();
    public Chef_CooldownState cooldownState = new Chef_CooldownState();

    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Chef_BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}

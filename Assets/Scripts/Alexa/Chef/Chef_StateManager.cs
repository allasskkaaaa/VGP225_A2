using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Chef_StateManager : MonoBehaviour
{
    [SerializeField] public float cooldownTime;    
    
    Chef_BaseState currentState;

    public GameObject target;
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

    private void OnTriggerStay(Collider collision)
    {
        target = collision.gameObject;
        currentState.OnCollisionStay(this, collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        target = collision.gameObject;
        currentState.OnCollisionExit(this, collision);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Chef_StateManager : MonoBehaviour
{
    [SerializeField] public float cooldownTime;
    [SerializeField] public float attackSpeed = 2;

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
        currentState.OnCollisionStay(this, collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        target = null;
        currentState.OnCollisionExit(this, collision);
    }
}

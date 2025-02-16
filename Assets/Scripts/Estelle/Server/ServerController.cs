using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerController : MonoBehaviour
{
    ServerBaseState currentState;
    public ServerIdleState idleState = new ServerIdleState();
    public ServerWalkingState walkState = new ServerWalkingState();
    public ServerAttackState attackState = new ServerAttackState();
    public ServerAttackCooldownState attackCooldownState = new ServerAttackCooldownState();

    private Animator animator;
    [SerializeField] private float animationTransitionDuration;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void PlayAnimation(string name)
    {
        animator.CrossFade(name, animationTransitionDuration);
    }

    public void SwitchState(ServerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}

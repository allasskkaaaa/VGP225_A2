using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Cat_StateManager : MonoBehaviour
{

    Cat_BaseState currentState;

    public Cat_Attack attackState = new Cat_Attack();
    public Cat_Hide hideState = new Cat_Hide();
    public Cat_Search searchState = new Cat_Search();

    void Start()
    {
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
}

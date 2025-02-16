using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cat_BaseState
{
    public abstract void EnterState(Cat_StateManager cat);

    public abstract void UpdateState(Cat_StateManager cat);

    public abstract void OnTriggerStay(Cat_StateManager cat, Collider collision);

    public abstract void OnTriggerExit(Cat_StateManager cat, Collider collision);
}

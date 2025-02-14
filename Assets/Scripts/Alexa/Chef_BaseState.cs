using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chef_BaseState 
{
    public abstract void EnterState(Chef_StateManager chef);

    public abstract void UpdateState(Chef_StateManager chef);

    public abstract void OnCollisionEnter(Chef_StateManager chef, Collision collision);
}

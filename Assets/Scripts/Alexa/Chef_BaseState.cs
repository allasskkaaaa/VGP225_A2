using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chef_BaseState 
{
    
    public abstract void EnterState(Chef_StateManager chef);

    public abstract void UpdateState(Chef_StateManager chef);

    public abstract void OnCollisionStay(Chef_StateManager chef, Collider collision);

    public abstract void OnCollisionExit(Chef_StateManager chef, Collider collision);
}

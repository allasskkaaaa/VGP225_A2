using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ServerBaseState 
{
    public abstract void EnterState(ServerController StateManager);

    public abstract void UpdateState(ServerController StateManager);

    public virtual void OnAnimationEnded(ServerController StateManager)
    {
        return;
        //by defualt do noting
    }
}

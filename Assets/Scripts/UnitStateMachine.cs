using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitStateMachine
{
    public abstract void EnterState(BossKoBoss boss);

    public abstract void UpdateState(BossKoBoss boss);

    public abstract void ExitState(BossKoBoss boss);

   
    
}

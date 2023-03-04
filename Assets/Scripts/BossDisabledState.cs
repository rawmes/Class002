using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDisabledState : UnitStateMachine
{
    public override void EnterState(BossKoBoss boss)
    {
        Debug.Log("ILL REMAIN SILENT FOR NOW");
    }

    public override void ExitState(BossKoBoss boss)
    {
        
    }

    public override void UpdateState(BossKoBoss boss)
    {
        if (boss.activated)
        {
            boss.SwitchState(boss.chillState);
        }
    }

    
}

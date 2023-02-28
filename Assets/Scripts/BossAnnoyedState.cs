using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnnoyedState : UnitStateMachine
{
    public override void EnterState(BossKoBoss boss)
    {
        Debug.Log("Change state");
    }

    public override void ExitState(BossKoBoss boss)
    {
        boss.iterator++;
    }

    public override void UpdateState(BossKoBoss boss)
    {
        if (boss.Health < boss.checkpoints[boss.iterator])
        {
            boss.SwitchState(boss.angryState);  
        }
    }
}

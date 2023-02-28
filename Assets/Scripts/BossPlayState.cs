using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayState : UnitStateMachine
{
    public override void EnterState(BossKoBoss boss)
    {
        Debug.Log("I AM ALIVEE!!!!");

    }

    public override void ExitState(BossKoBoss boss)
    {
        boss.iterator++;
        Debug.Log("Ping");
    }

    public override void UpdateState(BossKoBoss boss)
    {
       if(boss.Health < boss.checkpoints[boss.iterator])
        {
            boss.SwitchState(boss.annoyedState);
        }
    }
}

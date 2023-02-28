using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAngryState : UnitStateMachine
{
    public override void EnterState(BossKoBoss boss)
    {
        Debug.Log("Furios but not fast");
    }

    public override void ExitState(BossKoBoss boss)
    {

    }

    public override void UpdateState(BossKoBoss boss)
    {

    }
}

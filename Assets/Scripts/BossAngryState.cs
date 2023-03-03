using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAngryState : UnitStateMachine
{
    public override void EnterState(BossKoBoss boss)
    {
        ActivateWeapons(boss);
    }

    public override void ExitState(BossKoBoss boss)
    {

    }

    public override void UpdateState(BossKoBoss boss)
    {

    }

    public void ActivateWeapons(BossKoBoss boss)
    {
        for (int i = 0; i < boss.WeaponSystems.Length; i++)
        {
            if (i == boss.iterator)
            {
                boss.WeaponSystems[i].activated = true;
            }
            else
            {
                boss.WeaponSystems[(int)i].activated = false;
            }
        }
    }
}

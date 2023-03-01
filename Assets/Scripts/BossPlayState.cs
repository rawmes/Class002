using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPlayState : UnitStateMachine
{
    public float firingSpeed = 2f;
    float timeKeeper;
    bool cinematic = true;
    public float bossSpeed=0.2f;
    float targetPos;
    Vector3 startPos;
    public override void EnterState(BossKoBoss boss)
    {
        Debug.Log("I AM ALIVEE!!!!");

        ActivateWeapons(boss);

        startPos = new Vector3(0f,Camera.main.orthographicSize,0f);
        
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

        Move(boss);

        Shoot(boss.WeaponSystems); // here 2f ~ 2s .. future me ko problem.. or sir ko
        
        

        
    }

    private void ActivateWeapons(BossKoBoss boss)
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

    private void Shoot(WeaponSystem[] weaponsystems)
    {
        foreach (WeaponSystem weapon in weaponsystems)
        {
            if (weapon.activated)
            {
                timeKeeper = timeKeeper + Time.deltaTime;
                if (timeKeeper > firingSpeed)
                {
                    Debug.Log("fired");
                    weapon.Fire();
                    timeKeeper = 0f;
                }

            }

        }
    }

    private void Move(BossKoBoss boss)
    {
        if (!cinematic)
        {
            float height = Camera.main.orthographicSize;
            float width = Camera.main.orthographicSize * Camera.main.aspect;
           if(boss.gameObject.transform.position.x >= width)
            {
                targetPos = -width;
            }
            else if(boss.gameObject.transform.position.x <= -width)
            {
                targetPos = width;
            }
            
            

            boss.gameObject.transform.position = Vector3.MoveTowards(boss.gameObject.transform.position, new Vector3(targetPos, height, 0f),bossSpeed);


        }
        else
        {
            float height = Camera.main.orthographicSize * 2;
            
            boss.gameObject.transform.position = Vector3.MoveTowards(boss.gameObject.transform.position, startPos, bossSpeed);
            if (boss.gameObject.transform.position == startPos) cinematic = false;
            targetPos = Camera.main.orthographicSize * Camera.main.aspect;
        }
    }
}

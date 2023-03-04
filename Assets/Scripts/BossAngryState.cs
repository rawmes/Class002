using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAngryState : UnitStateMachine
{
    public float firingSpeed = 0.2f;
    public float bossSpeed = 0.9f;
    float timeKeeper = 0;
    float targetPos;
    public bool cinematic = true;
    public Vector3 startPos;
    bool goAway = false;
    public override void EnterState(BossKoBoss boss)
    {
        ActivateWeapons(boss);
        startPos = boss.gameObject.transform.position;
    }

    public override void ExitState(BossKoBoss boss)
    {
        boss.iterator++;
    }

    public override void UpdateState(BossKoBoss boss)
    {

        if(boss.currentHealth< 0f) // here is a hard code... poopy timez is now
        {
            goAway = true;
            
        }
        Move(boss);

        Shoot(boss.WeaponSystems);
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
    private void Move(BossKoBoss boss)
    {
        if (!cinematic)
        {
            float height = Camera.main.orthographicSize;
            float width = Camera.main.orthographicSize * Camera.main.aspect;
            if (boss.gameObject.transform.position.x >= width)
            {
                targetPos = -width;
            }
            else if (boss.gameObject.transform.position.x <= -width)
            {
                targetPos = width;
            }
            else
            {
                
                if(Random.Range(1,100) < 20) { targetPos = -targetPos; }
            }


            if (!goAway)
            {
                boss.gameObject.transform.position = Vector3.MoveTowards(boss.gameObject.transform.position, new Vector3(targetPos, height, 0f), bossSpeed);

            }
            else
            {
                boss.gameObject.transform.position = Vector3.MoveTowards(boss.gameObject.transform.position, new Vector3(targetPos+2, height+2, 0f), bossSpeed);

            }


        }
        else
        {
            float height = Camera.main.orthographicSize * 2;

            boss.gameObject.transform.position = Vector3.MoveTowards(boss.gameObject.transform.position, startPos, bossSpeed);
            if (boss.gameObject.transform.position == startPos) cinematic = false;
            targetPos = Camera.main.orthographicSize * Camera.main.aspect;
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
}

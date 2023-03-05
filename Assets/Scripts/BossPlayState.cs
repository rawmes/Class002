using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPlayState : UnitStateMachine
{
    public float firingSpeed = 1.3f;
    float timeKeeper=0;
    public bool cinematic = true;
    public float bossSpeed=1.8f;
    float targetPos;
    public Vector3 startPos;
    
    public override void EnterState(BossKoBoss boss)
    {
        Debug.Log("I AM ALIVEE!!!!");

        ActivateWeapons(boss);

        startPos = new Vector3(0f,Camera.main.orthographicSize,0f);
        boss.iterator = 0;
        
    }

    public override void ExitState(BossKoBoss boss)
    {
        boss.iterator++;
        Debug.Log("Ping");
    }

    public override void UpdateState(BossKoBoss boss)
    {
        

       if(boss.currentHealth < boss.checkpoints[boss.iterator])
        {
            boss.SwitchState(boss.annoyedState);
        }

        Move(boss);

        Shoot(boss.WeaponSystems); 
        
        

        
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
            
            

            boss.gameObject.transform.position = Vector3.MoveTowards(boss.gameObject.transform.position, new Vector3(targetPos, height, 0f),bossSpeed*Time.deltaTime);


        }
        else
        {
            float height = Camera.main.orthographicSize * 2;
            
            boss.gameObject.transform.position = Vector3.MoveTowards(boss.gameObject.transform.position, startPos, bossSpeed*5f*Time.deltaTime);
            if (boss.gameObject.transform.position == startPos) 
            { 
                cinematic = false;
                boss.healthBar.gameObject.SetActive(true);
                GameManager.Instance.StartDialogue();
            }
            Debug.Log("MOVING");
            targetPos = Camera.main.orthographicSize * Camera.main.aspect;
        }
    }
}

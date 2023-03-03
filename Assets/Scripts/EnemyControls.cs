
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyControls : MonoBehaviour
{
    int pathIndex=0;
    float timeKeeper;
    public float firingSpeed;
    public GameObject path;
    private WeaponSystem weapon;
    private Transform[] positions;
    private Vector3 position;
    public float damp = 0.5f;

    private void OnEnable()
    {
        EnemySpawner.activeEnemies++;
        positions = path.GetComponentsInChildren<Transform>();
        GetPath();
        weapon = GetComponentInChildren<WeaponSystem>();
        gameObject.transform.position = position;
    }

    

    private void Update()
    {
        if(transform.position != position)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, damp* Time.deltaTime);
        }
        else
        {
            GetPath();  
        }

        Shoot(weapon);


    }



    void GetPath()
    {
        
        position = positions[pathIndex].position;
        pathIndex++;
        if (pathIndex >= positions.Length)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnDisable()
    {
        EnemySpawner.activeEnemies--;
    }

    private void Shoot(WeaponSystem weaponSystem)
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

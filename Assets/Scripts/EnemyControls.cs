
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;


public class EnemyControls : MonoBehaviour
{
    public Vector3 spawnPoint;
    int pathIndex=0;
    float timeKeeper;
    public float firingSpeed;
    public GameObject path;
    private WeaponSystem weapon;
    private Vector3[] positions;
    private Vector3 position;
    public float damp = 0.5f;
    public float side;
    

    private void OnEnable()
    {
        EnemySpawner.activeEnemies++;
        //positions = path.GetComponentsInChildren<Transform>();
        //GetPath();
        weapon = GetComponentInChildren<WeaponSystem>();
        
    }

    public void Initialize()
    {

        positions = GeneratePosition();
        GetPath();
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
        
        position = positions[pathIndex];
        pathIndex++;
        if (pathIndex >= positions.Length)
        {
            Destroy(gameObject);
        }
        

    }

    Vector3[] GeneratePosition()
    {
        Vector3 startingPoint, middle, endingPoint ,dummyPos;
        float height = Camera.main.orthographicSize;
        float width = Camera.main.orthographicSize * Camera.main.aspect;

        


        startingPoint = new Vector3(-side*width,height+2f,0f);
        middle= new Vector3(0f, 2f, 0f);
        endingPoint = new Vector3(side*width-2f, 2f,0f);
        dummyPos = new Vector3(side * width, 2f, 0f);

        Debug.Log("GENERATING pOS");
        

        return new Vector3[] { startingPoint,middle,endingPoint,dummyPos };
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

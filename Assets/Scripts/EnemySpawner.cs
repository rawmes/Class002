using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public static int activeEnemies;

    int enemyIndex;

    public EnemyWave[] wave;
    
    int enemyCounter = 0;
    public int currentWave = 0;
    bool spawnning=false;
    bool allSpawned=false;

    private void Awake()
    {
        enemyIndex = wave[currentWave].enemyPrefabs.Length;
    }
    private void Update()
    {
        if(spawnning == false) 
        {
            StartCoroutine(SpawnWave());
            spawnning= true;
            
        }
        MonitorWave();
    }

    IEnumerator SpawnWave()
    {
        
        yield return new WaitForSeconds(2f);
        spawnning = false;
        if (enemyCounter < enemyIndex)
        {
            var newEnemy = wave[currentWave].enemyPrefabs[enemyCounter];

            var currentEnemy = Instantiate(newEnemy);
            EnemyControls currenyEnemyControls = currentEnemy.GetComponent<EnemyControls>();
            newEnemy.GetComponent<EnemyControls>().path = wave[currentWave].pathContainer;
            currenyEnemyControls.damp = Random.Range(0.2f, 1f);
            enemyCounter++;
        }
        else
        {
            allSpawned= true;
        }

        

    }

    void MonitorWave()
    {

        if(activeEnemies <= 0 && allSpawned==true)
        { 
            
            if (wave.Length > currentWave+1)
            {
                
                currentWave++;
                enemyCounter = 0;
                allSpawned = false;
                enemyIndex = wave[currentWave].enemyPrefabs.Length;
            }
        }
    }

    
}

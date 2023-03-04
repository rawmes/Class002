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
    bool nextBossIsFriendly= false;

    [SerializeField] BossKoBoss bossMan;

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
            EnemyControls currentEnemyControls = currentEnemy.GetComponent<EnemyControls>();
            
            currentEnemyControls.damp = Random.Range(1f, 2f);
            currentEnemyControls.side = wave[currentWave].side;
            currentEnemyControls.Initialize();
            enemyCounter++;
        }
        else
        {
            allSpawned= true;
        }

        

    }

    void MonitorWave()
    {
        switch (currentWave)
        {
            case 0:
                SpawnEnemy();
                break;
            case 1:
                SpawnEnemy();
                break;
            case 2:
                bossMan.activated = true;
                
                break;
        }

        
    }
    private void SpawnEnemy()
    {
        if (activeEnemies <= 0 && allSpawned == true)
        {
            currentWave++;
            if (wave.Length >= currentWave + 1)
            {
                enemyCounter = 0;
                allSpawned = false;
                enemyIndex = wave[currentWave].enemyPrefabs.Length;
            }
        }
    }    
}

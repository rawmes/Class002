using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "EnemyWave")]
public class EnemyWave : ScriptableObject
{
    public GameObject[] enemyPrefabs;
    public float side;

}

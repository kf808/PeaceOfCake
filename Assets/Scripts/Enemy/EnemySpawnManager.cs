using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    [SerializeField]
    private List<EnemySpawner> enemySpawners;

    public EnemySpawner GetEnemySpawner(int spawnerNumber)
    {
        return enemySpawners[spawnerNumber];
    }
}

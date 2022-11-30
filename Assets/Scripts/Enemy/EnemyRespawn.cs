using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies;

    private void OnEnable()
    {
        EventHandler.OnRespawnEnemies += RespawnEnemies;
    }

    private void OnDisable()
    {
        EventHandler.OnRespawnEnemies -= RespawnEnemies;
    }

    private void RespawnEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }
}

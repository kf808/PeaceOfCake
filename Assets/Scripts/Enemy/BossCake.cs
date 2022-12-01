using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCake : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D gate;
    [SerializeField]
    private EnemyTower defense1;
    [SerializeField]
    private EnemyTower defense2;
    [SerializeField]
    private EnemyTower defense3;
    [SerializeField]
    private EnemyTower defense4;

    private EnemyTower enemyTower;

    private void Awake()
    {
        enemyTower = GetComponent<EnemyTower>();
    }

    private void Update()
    {
        if ((defense1 != null) || (defense2 != null) || (defense3 != null) || (defense4 != null))
            enemyTower.Health = 500;
    }

    private void OnDestroy()
    {
        if (enemyTower.Health <= 0)
        {
            gate.enabled = false;
            gate.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

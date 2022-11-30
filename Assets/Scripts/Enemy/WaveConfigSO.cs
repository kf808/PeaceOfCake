using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private Transform pathPrefab;
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float timeBetweenEnemySpawns = 1f;
    [SerializeField]
    private float spawnTimeVariance = 0f;
    [SerializeField]
    private float minimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemies.Count;
    }

    public GameObject GetEnemy(int index)
    {
        return enemies[index];
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();
        foreach(Transform waypoint in pathPrefab)
        {
            waypoints.Add(waypoint);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}

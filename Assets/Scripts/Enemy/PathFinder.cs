using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField]
    private bool showDetectorCircle;
    [SerializeField]
    private float detectionRadius;
    [SerializeField]
    private int EnemyWaveNumber;
    // For Testing
    [SerializeField]
    private bool detectPlayer;

    private Transform targetTransform;
    private EnemySpawner enemySpawner;
    private WaveConfigSO waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;
    private AIDetector aIDetector;

    private void Awake()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        enemySpawner = EnemySpawnManager.Instance.GetEnemySpawner(EnemyWaveNumber);
        aIDetector = new AIDetector(detectionRadius);
    }

    private void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        aIDetector.TargetDetectionCircle(transform.position);
        float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;

        if (waypointIndex < waypoints.Count)
        {
            Vector3 waypointPosition = waypoints[waypointIndex].position;

            if (aIDetector.targetDetected && detectPlayer)
                transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, delta);
            else
                transform.position = Vector2.MoveTowards(transform.position, waypointPosition, delta);

            if (transform.position == waypointPosition)
                waypointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (showDetectorCircle)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}

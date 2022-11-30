using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<WaveConfigSO> waveConfigs;
    [SerializeField]
    private float timeBetweenWaves = 0f;
    [SerializeField]
    private bool keepLooping;

    private WaveConfigSO currentWave;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentWave = waveConfig;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemy(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (keepLooping);
    }
}

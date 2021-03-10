using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //This "Do While" loop is what gives the game the never ending play
        //I'll probably create a second optional game play style that is by level with a set number of waves where score is based on accuracy
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    //Remember that these 'Ienumerator' methods are coroutines and must be started with the method "StartCoroutine()"
    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.getEnemyPrefab(), (Vector2)waveConfig.getWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns());
        }
    }
}

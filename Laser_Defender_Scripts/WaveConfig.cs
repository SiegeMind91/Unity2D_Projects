using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class WaveConfig : ScriptableObject
{
    //Configuration Parameters
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 1.2f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] int numberofEnemies = 5;
    
    public GameObject getEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> getWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float getTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float getSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public int getNumberOfEnemies()
    {
        return numberofEnemies;
    }







}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 5f;
    [SerializeField] private int numberOfSpawns;
    [SerializeField] private List<Transform> spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            if (spawnPoints.Count > 0)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
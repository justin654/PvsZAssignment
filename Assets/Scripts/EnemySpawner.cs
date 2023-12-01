using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private float minSpawnTime = 2f;
    [SerializeField] private float maxSpawnTime = 5f;
    [SerializeField] private int numberOfSpawns;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            if (LevelManager.rowYPositions.Count > 0)
            {
                int randomRow = Random.Range(0, LevelManager.rowYPositions.Count);
                Vector3 spawnPosition = new Vector3(transform.position.x, LevelManager.rowYPositions[randomRow], 0);

                Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float minTimeBetweenProjectiles = 1f;
    [SerializeField] private float maxTimeBetweenProjectiles = 3f;
    [SerializeField] private Vector3 projectileOffset = Vector3.zero;
    
    private void Start()
    {
        StartCoroutine(SpawnProjectiles());
    }

    private IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenProjectiles, maxTimeBetweenProjectiles));

            Vector3 spawnPosition = transform.position + projectileOffset;
            Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private Vector3 spawnOffset = Vector3.zero; // offset spawn position to get them lined up

    public void SpawnPlayer(Vector3 positionToSpawn)
    {
        Vector3 finalPosition = positionToSpawn + spawnOffset; // apply offset
        Instantiate(plantPrefab, finalPosition, Quaternion.identity);
    }
}

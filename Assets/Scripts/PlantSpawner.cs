using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private Vector3 spawnOffset = Vector3.zero;

    private Dictionary<Vector3, GameObject> spawnLocations = new Dictionary<Vector3, GameObject>();

    public void SpawnPlayer(Vector3 positionToSpawn)
    {
        Vector3 finalPosition = positionToSpawn + spawnOffset; // apply offset

        // Check if a spawn already exists at this position
        if (spawnLocations.ContainsKey(finalPosition) && spawnLocations[finalPosition] != null)
        {
            Debug.Log("A object already exists at this location!");
            return;
        }

        GameObject newSpawn = Instantiate(plantPrefab, finalPosition, Quaternion.identity);
        spawnLocations[finalPosition] = newSpawn;
    }
}
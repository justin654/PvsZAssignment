using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;

    public void SpawnPlayer(Vector3 position_To_Spawn)
    {
        Instantiate(plantPrefab, position_To_Spawn, Quaternion.identity);
    }
}
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private const string LogMessageFormat = "Grid cell clicked: {0}";

    private PlantSpawner plantSpawnerInstance;
 
    private void Start()
    {
        plantSpawnerInstance = FindObjectOfType<PlantSpawner>();
    }
 
    private void OnMouseDown()
{
    if (plantSpawnerInstance != null)
    {
        LogGridCellClickMessage();
        Vector3 spawnPosition = transform.position;
        plantSpawnerInstance.SpawnPlayer(spawnPosition);
    }
}

private void LogGridCellClickMessage()
{
    string cellClickMessage = string.Format(LogMessageFormat, gameObject.name);
    Debug.Log(cellClickMessage);
}
}
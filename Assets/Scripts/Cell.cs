using UnityEngine;

public class Cell : MonoBehaviour
{
    private PlantSpawner plantSpawner;

    private void Start()
    {
        plantSpawner = FindObjectOfType<PlantSpawner>();
    }

    private void OnMouseDown()
    {
        if (plantSpawner != null)
        {
            Debug.Log("Cell clicked: " + gameObject.name);
            plantSpawner.SpawnPlayer(transform.position);
        }
    }
}
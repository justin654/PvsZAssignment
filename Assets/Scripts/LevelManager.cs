using UnityEngine;
using System.Collections.Generic;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject cellParent;
    [SerializeField] private GameObject cellPrefab;
    
    [Header("Grid Settings")]
    [SerializeField] private int gridWidth = 5;
    [SerializeField] private int gridHeight = 9;

    public static List<float> rowYPositions = new List<float>(); // store row Y position for use in our spawner script
    
    void Start()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject newCell = Instantiate(cellPrefab, new Vector3(x * 2, y * 2, 0), Quaternion.identity);
                newCell.transform.SetParent(cellParent.transform, false);

                if (x == 0)
                {
                    rowYPositions.Add(newCell.transform.position.y);
                }
            }
        }
    }
    
    void OnDrawGizmos()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 cellPosition = new Vector3(x * 2, y * 2, 0);
                
                // Draw a box so I can see where the cells would spawn
                Gizmos.DrawWireCube(cellPosition, new Vector3(2, 2, 0));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    // Prefabs for each tile type
    public GameObject[] tilePrefabs;

    // JSON data structure
    public TerrainData terrainData;
    public static GridGenerator instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
      //  GenerateGrid();
    }

    public void GenerateGrid()
    {
        if (terrainData == null || terrainData.TerrainGrid == null)
        {
            Debug.LogError("Terrain data is not set or invalid.");
            return;
        }

        // Loop through each row and column of the grid
        for (int row = 0; row < terrainData.TerrainGrid.Length; row++)
        {
            for (int col = 0; col < terrainData.TerrainGrid[row].Length; col++)
            {
                // Get the tile type for the current position
                int tileTypeIndex = terrainData.TerrainGrid[row][col].TileType;

                // Instantiate the corresponding prefab at the current position
                if (tileTypeIndex >= 0 && tileTypeIndex < tilePrefabs.Length)
                {
                    Instantiate(tilePrefabs[tileTypeIndex], new Vector3(col, 0, row), Quaternion.identity, transform);
                }
                else
                {
                    Debug.LogWarning("Invalid tile type index at row " + row + " col " + col);
                }
            }
        }
    }
}

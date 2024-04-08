using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class TerrainLoader : MonoBehaviour
{
    // Adjust the path according to your file location
    private string filePath = "Assets/datacOLLECT/data.json";

    void Start()
    {
        LoadTerrainData();
    }

    void LoadTerrainData()
    {
        // Read the JSON file
        string jsonString = File.ReadAllText(filePath);
        Debug.Log("FIND PATH " + jsonString);
        // Deserialize JSON into custom class
        TerrainData terrainData = JsonConvert.DeserializeObject<TerrainData>(jsonString);
        GridGenerator.instance.terrainData = terrainData;
        GridGenerator.instance.GenerateGrid();
        // Use terrainData in your game
        Debug.Log("Terrain data loaded: " + terrainData.TerrainGrid.Length);
    }
}

[System.Serializable]
public class TerrainData
{
    public Tile[][] TerrainGrid;
}

[System.Serializable]
public class Tile
{
    public int TileType;
}
public enum TileType
{
    Dirt,
    Grass,
    Stone,
    Wood
}
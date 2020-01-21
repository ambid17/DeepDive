using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [Header("Assign in editor")]
    public int mapWidth = 5;
    public int mapHeight = 5;
    public List<CustomTile> tiles;

    Tilemap tilemap;
    int[,] mapIDs;

    void Start()
    {
        GenerateMap();
    }

    // Add a context menu named "Generate Map" in the inspector
    [ContextMenu("Generate Map")]
    void GenerateMap()
    {
        x();
    }
    
    void x()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMapIDs();
        RenderMap();
    }

    void GenerateMapIDs()
    {
        mapIDs = new int[mapWidth, mapHeight];
        for(int x = 0; x < mapIDs.GetUpperBound(0); x++)
        {
            for (int y = 0; y < mapIDs.GetUpperBound(1); y++)
            {
                mapIDs[x,y] = GenerateTileID(x, y);
            }
        }
    }

    public void RenderMap()
    {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();

        for (int x = 0; x < mapIDs.GetUpperBound(0); x++)
        {
            for (int y = 0; y < mapIDs.GetUpperBound(1); y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), GetTileByID(mapIDs[x,y]));
            }
        }
    }


    //Utility methods for refactor

    //Currently just adds tile based on depth
    private int GenerateTileID(int x, int y)
    {
        foreach (CustomTile tile in tiles)
        {
            if (y >= tile.findableDepth)
            {
                return tile.tileId;
            }
        }

        Debug.Log("No tile of depth");
        return tiles.Count - 1;
    }

    private TileBase GetTileByID(int id)
    {
        foreach(CustomTile tile in tiles)
        {
            if(tile.tileId == id)
            {
                return tile;
            }
        }

        Debug.LogError("Tile not found for id: " + id);
        return tiles[0];
    }
}

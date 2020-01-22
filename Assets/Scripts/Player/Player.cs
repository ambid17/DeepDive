using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [Header("Assign in editor")]
    public Tilemap tilemap; 
    public PlayerData playerData;

    private const int cellPositionOffset = 1;

    void Start()
    {
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.2f, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Dig();
        }
    }

    
    void Dig()
    {
        Vector3Int currentCellPosition = GetCellPosition(transform.position);
        TileBase tileBelowPlayer = tilemap.GetTile(currentCellPosition);

        if(tileBelowPlayer != null)
        {
            // Before we delete the tile, get the correct money reward
            GetMoney(currentCellPosition);
            tilemap.SetTile(currentCellPosition, null);
        }
    }

    // The tilemap is rotated 180 degrees to make math easy
    // So we have to adjust tile position
    Vector3Int GetCellPosition(Vector3 position)
    {
        Vector3Int cellPos = tilemap.WorldToCell(transform.position);
        cellPos.y += 1;
        return cellPos;
    }

    void GetMoney(Vector3Int cellPos)
    {
        CustomTile tile = tilemap.GetTile(cellPos) as CustomTile;
        playerData.money += tile.value;
    }
}

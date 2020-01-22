using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Assign in editor")]
    public Tilemap tilemap; 
    public PlayerData playerData;
    public float moveSpeed = 0.2f;
    public float jumpSpeed = 10f;
    public LayerMask groundLayerMask;

    private const int cellPositionOffset = 1;

    private bool isGrounded;
    public float groundCheckDistance = 5f;
    
    BoxCollider2D myCollider;
    Rigidbody2D myRigidBody;

    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGrounded();
        CheckInput();
    }

    void CheckGrounded()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask))
        {
            Debug.Log("grounded");
            isGrounded = true;
        }
        else
        {
            Debug.Log("noop");
            isGrounded = false;
        }
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.MovePosition(transform.position + new Vector3(-moveSpeed, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.MovePosition(transform.position + new Vector3(moveSpeed, 0));
        }

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            myRigidBody.velocity = new Vector2(0, jumpSpeed);
        }

        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            // Add dig timer
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

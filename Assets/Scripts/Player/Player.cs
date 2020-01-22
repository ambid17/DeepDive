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
    public float groundCheckDistance = 6f;
    
    BoxCollider2D myCollider;
    Rigidbody2D myRigidBody;

    enum DigDirection
    {
        Left, Right, Down
    }

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
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.MovePosition(transform.position + new Vector3(-moveSpeed, 0));
            if (CanDig(DigDirection.Left))
            {
                Dig(DigDirection.Left);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.MovePosition(transform.position + new Vector3(moveSpeed, 0));
            if (CanDig(DigDirection.Right))
            {
                Dig(DigDirection.Right);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (CanDig(DigDirection.Down))
            {
                Dig(DigDirection.Down);
            }
        }

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            myRigidBody.velocity = new Vector2(0, jumpSpeed);
        }

        
    }

    private bool CanDig(DigDirection direction)
    {
        if (!isGrounded)
        {
            return false;
        }

        //Check Timer
        Vector2 raycastDirection = Vector2.zero;
        switch (direction)
        {
            case DigDirection.Left:
                raycastDirection = Vector2.left;
                break;
            case DigDirection.Right:
                raycastDirection = Vector2.right;
                break;
            case DigDirection.Down:
                raycastDirection = Vector2.down;
                break;
        }

        bool canDig = Physics2D.Raycast(transform.position, raycastDirection, groundCheckDistance, groundLayerMask);

        return canDig;
    }

    
    void Dig(DigDirection direction)
    {
        Vector3 positionForCell = transform.position;
        if(direction == DigDirection.Left)
        {
            positionForCell += Vector3.left * 10;
        }

        if (direction == DigDirection.Right)
        {
            positionForCell += Vector3.right * 10;
        }

        Vector3Int currentCellPosition = GetCellPosition(positionForCell, direction);

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
    Vector3Int GetCellPosition(Vector3 position, DigDirection direction)
    {
        Vector3Int cellPos = tilemap.WorldToCell(position);
        if(direction == DigDirection.Down)
        {
            cellPos.y += 1;
        }
        return cellPos;
    }

    void GetMoney(Vector3Int cellPos)
    {
        CustomTile tile = tilemap.GetTile(cellPos) as CustomTile;
        playerData.money += tile.value;
    }
}

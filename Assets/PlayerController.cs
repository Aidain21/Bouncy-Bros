using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpSpeed = 6f;
    [HideInInspector] public BoxCollider2D playerCol;
    [HideInInspector] public Rigidbody2D playerRB;
    public float GroundTestHeight = 0.1f;
    public LayerMask platformLayerMask;
    public bool canJump;
    public bool letGO;

    private void Awake()
    {
        playerCol = GetComponent<BoxCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        canJump = true;

    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //float dirY = GetComponent<Rigidbody2D>().velocity.y;
            letGO = false;
            playerRB.velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        }
        if (Input.GetKeyUp(KeyCode.Space) && !letGO)
        {
            //float dirY = GetComponent<Rigidbody2D>().velocity.y;

            playerRB.velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * 0.25f);
            letGO = true;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCol.bounds.center, playerCol.bounds.size, 0f, Vector2.down, GroundTestHeight, platformLayerMask);

        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}

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
    public float slamTimer;
    public bool fromSpace;

    private void Awake()
    {
        playerCol = GetComponent<BoxCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        slamTimer = 0;
    }

    private void Update()
    {
        if (IsGrounded())
        {
            GetComponent<SpriteRenderer>().color = new Color32(121, 255, 212, 255);
        }
        else if (fromSpace)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
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
            playerRB.velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
            fromSpace = true;
        }
        
        if (Input.GetKey(KeyCode.S) && !IsGrounded() && fromSpace)
        {
            slamTimer += Time.deltaTime;
            playerRB.gravityScale = 3;
        }
        else if (slamTimer > 0 && IsGrounded()) 
        {
            playerRB.velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed + (slamTimer * 4.7f) * slamTimer*4.7f);
            fromSpace = false;


            slamTimer = 0;
            playerRB.gravityScale = 1;

        }
        else
        {
            slamTimer = 0;
            playerRB.gravityScale = 1;
        }

        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, -3);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCol.bounds.center, playerCol.bounds.size, 0f, Vector2.down, GroundTestHeight, platformLayerMask);

        return raycastHit.collider != null;
    }
}

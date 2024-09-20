using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpSpeed = 6f;
    [HideInInspector] public BoxCollider2D playerCol;
    [HideInInspector] public Rigidbody2D playerRB;

    private void Awake()
    {
        playerCol = GetComponent<BoxCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //float dirY = GetComponent<Rigidbody2D>().velocity.y;
            playerRB.velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        }
    }
}

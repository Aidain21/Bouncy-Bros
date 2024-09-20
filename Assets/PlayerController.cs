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

    private void Awake()
    {
        playerCol = GetComponent<BoxCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCol.bounds.center, playerCol.bounds.size, 0f, Vector2.down, GroundTestHeight, platformLayerMask);

        return raycastHit.collider != null;
    }
}

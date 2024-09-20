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
        
    }
}

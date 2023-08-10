using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [SerializeField] private float jumpForce = 8.0f;
    private Rigidbody2D rigidBody;
    private float deltaX;
    private Vector2 movement;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.LogError($"Failed to start. {rigidBody.GetType()} not found!");
        }
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround= false;
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    { 
        deltaX = Input.GetAxis("Horizontal");
        movement = new Vector2(deltaX * speed * Time.deltaTime, rigidBody.velocity.y);
        rigidBody.velocity = movement;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
}

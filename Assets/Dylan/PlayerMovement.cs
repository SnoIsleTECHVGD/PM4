using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left, right, up, down;
    public float maxSpeed;


    private Rigidbody2D rb2D;
    bool onGround;

    void Start()
    {
        rb2D = GetComponent <Rigidbody2D>();
        onGround = true;
    }
    void Update()
    {
        if (Input.GetKey(left))
        {
            rb2D.AddForce(Vector2.left);
        }
        if (Input.GetKey(right))
        {
            rb2D.AddForce(Vector2.right);
        }


        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed), rb2D.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }
}

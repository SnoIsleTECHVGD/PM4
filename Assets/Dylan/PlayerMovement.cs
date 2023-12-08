using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left, right;
    public float buildUp;
    public float maxSpeed;

    public KeyCode jump;
    public float jumpForce;

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
            rb2D.AddForce(Vector2.left * buildUp);
        }
        if (Input.GetKey(right))
        {
            rb2D.AddForce(Vector2.right * buildUp);
        }

        if (Input.GetKeyDown(jump))
        {
            if (onGround == true)
            {
                onGround = false;
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
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

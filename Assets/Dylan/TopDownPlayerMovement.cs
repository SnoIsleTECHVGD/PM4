using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{

    public KeyCode left, right, up, down;

    public float moveSpeed;
    public Rigidbody2D rb2D;

    Vector2 movement;

    void Update()
    {
        //GameObject player = GameObject.FindObjectWithTag("Player");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(left))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 2);
        }

        if (Input.GetKey(right))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 1);
        }

        if (Input.GetKey(up))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 0);
        }

        if (Input.GetKey(down))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 3);
        }
    }

   void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{

    public KeyCode left, right, up, down;

    public float moveSpeed;
    public Rigidbody2D rb2D;
    private Vector2 moveInput;

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(left))
        {
            GetComponent<Animator>().SetInteger("WalkDiretion", 2);
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
        rb2D.MovePosition(rb2D.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}

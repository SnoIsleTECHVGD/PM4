using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSurprise : MonoBehaviour
{
    public GameObject target;

    public float distance;
    public int speed = 10; //subject to change

    public float health = 1; //also subject to change

    public bool activate = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position); //constantly get the distance
        if (distance < 5) //will start chasing if you get too close
        {
            activate = true;
        }

        if (health > 0 && activate && distance < 15) //move closer
        {
            if (transform.position.x < target.transform.position.x) //if enemy is left of target, move right
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (transform.position.x > target.transform.position.x) //if enemy is right of target, move left
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (transform.position.y > target.transform.position.y) //if enemy is above target, move down
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (transform.position.y < target.transform.position.y) //if enemy is below target, move up
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        if (health <= 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (transform.localEulerAngles.z != 0)
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        }
        if (target.GetComponent<characterHealth>().health <= 0)
        {
            health = 0;
        }
        if (distance < 1.5)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}

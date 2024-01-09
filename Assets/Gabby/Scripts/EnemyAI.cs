using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject target;
    public GameObject bullet;

    public float distance;
    public int speed = 5; //subject to change

    public float health = 1; //also subject to change

    public bool hasBullet = true;

    public float vertMove;
    public float horMove;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position); //constantly get the distance
        vertMove = System.Math.Abs(transform.position.y - target.transform.position.y);
        horMove = System.Math.Abs(transform.position.x - target.transform.position.x);

        if (distance > 10 && hasBullet && health > 0 && distance < 20) //move closer, won't chase if you're too far away
        {
            if (transform.position.x < target.transform.position.x) //if enemy is left of target, move right
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (horMove > vertMove)  //if enemy is further from target horizontally than vertically, face right
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 3);
                }
            }
            if (transform.position.x > target.transform.position.x) //if enemy is right of target, move left
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (horMove > vertMove) //if enemy is further from target horizontally than vertically, face left
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 1);
                }
            }
            if (transform.position.y > target.transform.position.y) //if enemy is above target, move down
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (horMove < vertMove) //if enemy is further from target vertically than horizontaly, face down
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 0);
                }
            }
            if (transform.position.y < target.transform.position.y) //if enemy is below target, move up
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (horMove < vertMove) //if enemy is further from target vertically than horizontaly, face up
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 2);
                }
            }
        }

        if (distance < 7 || (!hasBullet && distance < 20) && health > 0) //move away if player gets too close or if the enemy is out of ammo
        {
            if (transform.position.x < target.transform.position.x) //if enemy is left of target, move left
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (horMove > vertMove) //face left
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 1);
                }
            }
            if (transform.position.x > target.transform.position.x) //if enemy is right of target, move right
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (horMove > vertMove) //face right
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 3);
                }
            }
            if (transform.position.y > target.transform.position.y) //if enemy is above target, move up
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (horMove < vertMove) //face up
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 2);
                }
            }
            if (transform.position.y < target.transform.position.y) //if enemy is below target, move down
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (horMove < vertMove) //face down
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 0);
                }
            }
        }

        if (distance <= 10 && hasBullet && health > 0) //shoot
        {
            if (transform.position.x < target.transform.position.x) //if enemy is left of target, look right
            {
                if (horMove > vertMove)  //if enemy is further from target horizontally than vertically, face right
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 7);
                }
            }
            if (transform.position.x > target.transform.position.x) //if enemy is right of target, look left
            {
                if (horMove > vertMove) //if enemy is further from target horizontally than vertically, face left
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 5);
                }
            }
            if (transform.position.y > target.transform.position.y) //if enemy is above target, look down
            {
                if (horMove < vertMove) //if enemy is further from target vertically than horizontaly, face down
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 4);
                }
            }
            if (transform.position.y < target.transform.position.y) //if enemy is below target, look up
            {
                if (horMove < vertMove) //if enemy is further from target vertically than horizontaly, face up
                {
                    GetComponent<Animator>().SetInteger("WalkDirection", 6);
                }
            }
            bullet.GetComponent<CircleCollider2D>().enabled = false;
            bullet.GetComponent<SpriteRenderer>().enabled = false;
            bullet.GetComponent<CircleCollider2D>().isTrigger = false;
            bullet.GetComponent<TrailRenderer>().enabled = false;
            bullet.GetComponent<ShootScript>().shootWithCoroutine(target.transform.position.x, target.transform.position.y, transform.position.x, transform.position.y);
            hasBullet = false;
        }
        if (distance > 13 && !hasBullet && health > 0) // reload if far enough away
        {
            StartCoroutine(reload());
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
    }

    public IEnumerator reload() //reload when safe
    {
        yield return new WaitForSeconds(0.5f);
        hasBullet = true;
    }

    public IEnumerator shootThenWait()
    {
        yield return new WaitForSeconds(0.25f);
        hasBullet = false;
    }
}

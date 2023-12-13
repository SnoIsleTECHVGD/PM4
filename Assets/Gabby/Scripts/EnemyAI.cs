using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject target;
    public GameObject bullet;

    public float distance;
    public int speed = 5; //subject to change

    public float health = 3; //also subject to change

    public bool hasBullet = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position); //constantly get the distance


        if (distance > 10 && hasBullet && health > 0) //move closer
        {
            if (transform.position.x < target.transform.position.x) //if enemy is left of target, move right
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 3);
            }
            if (transform.position.x > target.transform.position.x) //if enemy is right of target, move left
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 1);
            }
            if (transform.position.y > target.transform.position.y) //if enemy is above target, move down
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 0);
            }
            if (transform.position.y < target.transform.position.y) //if enemy is below target, move up
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 2);
            }
        }

        if (distance < 7 || (!hasBullet && distance < 20) && health > 0) //move away if player gets too close or if the enemy is out of ammo
        {
            if (transform.position.x < target.transform.position.x) //if enemy is left of target, move left
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 1);
            }
            if (transform.position.x > target.transform.position.x) //if enemy is right of target, move right
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 3);
            }
            if (transform.position.y > target.transform.position.y) //if enemy is above target, move up
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 2);
            }
            if (transform.position.y < target.transform.position.y) //if enemy is below target, move down
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                GetComponent<Animator>().SetInteger("WalkDirection", 0);
            }
        }

        if (distance <= 10 && hasBullet && health > 0) //shoot
        {
            bullet.GetComponent<ShootScript>().shootWithCoroutine(target.transform.position.x, target.transform.position.y, transform.position.x, transform.position.y);
            hasBullet = false;
        }
        if (distance > 19 && !hasBullet && health > 0)
        {
            StartCoroutine(reload());
            //hasBullet = true;
        }
        if (health <= 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public IEnumerator reload() //reload when safe
    {
        yield return new WaitForSeconds(0.5f);
        hasBullet = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public float waitTime;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<BoxCollider2D>().isTrigger = false;
        
    }

    void Update()
    {
        if (GetComponent<BoxCollider2D>().isTrigger)
        {
            StartCoroutine(waitToDestroy());
        }
    }

    public IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<characterHealth>().health -= 3;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().health -= 3;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<characterHealth>().health -= 3;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().health -= 3;
        }
    }
}

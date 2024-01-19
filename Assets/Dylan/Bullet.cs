using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public GameObject RotatePoint;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyAI>().health -= 1;
            Destroy(RotatePoint.GetComponent<Shooting>().newBullet);

        }

        if (collision.gameObject.CompareTag("Explosive"))
        {
            collision.GetComponent<Animator>().SetInteger("aniRun", 2);
            collision.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if (collision.gameObject.CompareTag("Blocker"))
        {
            Destroy(RotatePoint.GetComponent<Shooting>().newBullet);
        }
    }
    

        // Update is called once per frame
    void Update()
    {
        
    }
}

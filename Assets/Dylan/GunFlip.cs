using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlip : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private SpriteRenderer spriteRender;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (rotZ < 90 && rotZ > -90)
        {
            spriteRender.flipY = false;
        }
        else
        {
            spriteRender.flipY = true;
        }
    }
}

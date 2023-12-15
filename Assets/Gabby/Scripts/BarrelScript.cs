using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{

    private void OnTrigerEnter2D(Collider2D collision)
    {
        Debug.Log("Barrel trigger test");
        GetComponent<Animator>().SetInteger("aniRun", 2);
    }
}

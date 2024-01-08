using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterHealth : MonoBehaviour
{

    public float health = 3;
    public GameObject healthThree;
    public GameObject healthTwo;
    public GameObject healthOne;
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        healthThree.SetActive(true);
        healthTwo.SetActive(false);
        healthOne.SetActive(false);
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 2) //this assumes health was previously 3
        {
            healthThree.SetActive(false);
            healthTwo.SetActive(true);
        }
        else if (health == 1)
        {
            healthThree.SetActive(false);
            healthTwo.SetActive(false);
            healthOne.SetActive(true);
        }
        else if (health <= 0)
        {
            healthThree.SetActive(false);
            healthTwo.SetActive(false);
            healthOne.SetActive(false);
            loseScreen.SetActive(true);
        }
    }
}

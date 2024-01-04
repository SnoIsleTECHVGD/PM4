using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class freeztime : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode Esc;
    public GameObject pause;
    // Update is called once per frame


    public void Start()
    {
        pause.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(Esc))
        {

            if (Time.timeScale == 1)
                freez();
            else
                unfreez();
        }
    }

    public void freez()
    {
        pause.SetActive(true);
        Time.timeScale = 0;

    }

    public void unfreez()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

}

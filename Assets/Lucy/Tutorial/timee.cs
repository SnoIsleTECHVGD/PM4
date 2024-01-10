using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Pausee();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pausee()
    {
        Time.timeScale = 0f;
    }
    public void UnPausee()
    {
        Time.timeScale = 1f;
    }
}

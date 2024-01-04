using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeztime : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
  public  void freez(float scale)
    {
        Time.timeScale = scale;
    }
}

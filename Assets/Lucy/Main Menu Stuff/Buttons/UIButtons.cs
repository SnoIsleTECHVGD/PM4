using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MasterScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

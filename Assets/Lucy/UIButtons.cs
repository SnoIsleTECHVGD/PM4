using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void PlayTutorial()
    {
        SceneManager.LoadScene("YorN");
    }
    public void Play()
    {
        SceneManager.LoadScene("MasterScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void PlayRealTutorial()
    {
        SceneManager.LoadScene("RealTutorial");
    }
}

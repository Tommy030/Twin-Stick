using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenuManager : MonoBehaviour
{
    public void GameEndButton()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial_level");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Start");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public static Pause StaticPause;
    [SerializeField]public bool Paused;

    [SerializeField] GameObject Menu;
    private void Awake()
    {
        StaticPause = this;
        if (Menu != null)
        {
            Menu.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseKnop();
        }
    }
    public void PauseKnop()
    {
        Paused = Checkpause();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("SelectMenu");
    }
    public bool Checkpause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;

            Menu.SetActive(false);

            return false;
        }
        else
        {
            Time.timeScale = 0f;
            Menu.SetActive(true);
            return true;
        }
    }
}

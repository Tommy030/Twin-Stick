using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    
    private bool Paused;

    Button[] ButtonArray;
    private void Awake()
    {
        foreach (Button item in ButtonArray)
        {
            item.gameObject.SetActive(false);    
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = Checkpause();
        }
    }
    public void PauseKnop()
    {
        Paused = Checkpause();
    }
    
    public bool Checkpause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            
            foreach (Button item in ButtonArray)
            {
                item.gameObject.SetActive(false);
            }
            return false;
        }
        else
        {
            Time.timeScale = 0f;
            foreach (Button item in ButtonArray)
            {
                item.gameObject.SetActive(true);
            }
            return true;
        }
    }
}

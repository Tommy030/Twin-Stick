using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private float KeyCooldown;
    private float KeyCooldownTimer;
    private void Update()
    {
        if (KeyCooldownTimer >= KeyCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if (Input.anyKey)
            {
                SceneManager.LoadScene("SelectMenu");
            }

        }
        else
        {
            KeyCooldownTimer += Time.deltaTime;
        }
        //ii
    }
}

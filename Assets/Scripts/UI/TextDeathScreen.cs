using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TextDeathScreen : MonoBehaviour
{

  public  Text Killedby;
  public  Text AmountRetries;
  public  Text Accuracy;
    private void Awake()
    {
        Killedby.text = StaticStats.Stats.KilledBy;
        AmountRetries.text = ("Amount of Retries: " + StaticStats.Stats.Retries.ToString() );

        
        Accuracy.text = ("Accuracy: " + StaticStats.Stats.Accuracy.ToString() + "%");

    }

    private void Update()
    {
        if (Input.anyKey)
        {

            StaticStats.Stats.Retries += 1; 
            SceneManager.LoadScene("Tutorial_level");
        }
    }
}

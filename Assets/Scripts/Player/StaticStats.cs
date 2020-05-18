using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticStats : MonoBehaviour
{
    public static int Retries;
    public static float GameTime;
    public static int Score;

    //Accuracy

    public static float Hit;
    public static float Shot;
    public static float Accuracy;
    
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GameTime += Time.deltaTime;
            string minutes = Mathf.Floor(GameTime / 60).ToString("00");
            string seconds = (GameTime % 60).ToString("00");
            //Debug.Log(string.Format("{0}:{1}", minutes, seconds));
        }
        
    }
}

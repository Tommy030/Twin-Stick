using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticStats : MonoBehaviour
{
    public int Retries;
    public float GameTime;
    public int Score;

    //Accuracy

    public float Hit;
    public float Shot;
    public float Accuracy;

    public static StaticStats Stats; 
        
    public string KilledBy;

    public string SceneName;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Stats == null)
        {
            Stats = this;
        }
      
    }
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GameTime += Time.deltaTime;
            string minutes = Mathf.Floor(GameTime / 60).ToString("00");
            string seconds = (GameTime % 60).ToString("00");
            //Debug.Log(string.Format("{0}:{1}", minutes, seconds));
        }
        Accuracy = (Hit / Shot) * 100;
    }
}

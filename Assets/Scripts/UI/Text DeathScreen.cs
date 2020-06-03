using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDeathScreen : MonoBehaviour
{

    Text Killedby;


    private void Awake()
    {
        Killedby.text = StaticStats.Stats.KilledBy;    
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public static PlayerManager Instance;

    public GameObject Player;
    
  
    private void Start()
    {
        Player = FindObjectOfType<PlayerStats>().gameObject;
        Instance = this;


    }


}

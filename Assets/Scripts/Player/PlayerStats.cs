using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Adjustables")]

    [SerializeField] public float PlayerHP;
    [SerializeField] public float PlayerArmour;
    [SerializeField] public float MovementSpeed;

    [SerializeField] public float MaxHP;
    [SerializeField] public float MaxArmour;
    
    [Header("Ammo")]
    [SerializeField] public int AmmoInUsedClip;


    [SerializeField] public int Clips;
    [SerializeField] public int MaxAmountClips;
    [SerializeField] public int AmmoPerClip;

    [SerializeField] public Ammo[] AmmoTypes;
    //0 AR; 
    //1 Pistol; 
    //2 Sniper; 
    //3 Shotgun; 
    //4  Minigun; 

  


    [Header("Weapon")]
    [SerializeField] public float WeaponDamage;
    [SerializeField] public float FireRate;
    [SerializeField] public string WeaponName;

    [SerializeField] public Gun[] GunStats; 

    [Header("Keycard")]
    public List<string> Keycard = new List<string>();

   
    private void Update()
    {

        if (PlayerHP > MaxHP)
            PlayerHP = MaxHP;

        else if (PlayerArmour > MaxArmour)
            PlayerArmour = MaxArmour;
        else if (Clips > MaxAmountClips)
            Clips = MaxAmountClips;
    }
}

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

    //Cheat
    public float OldPlayerHP;
    public float OldPlayerArmour;
    public float OldMaxHP;
    public float OldMaxArmour;

    [SerializeField] public int Clips;
    [SerializeField] public int MaxAmountClips;
    [SerializeField] public int AmmoPerClip;

    [SerializeField] public int AmmoType;
    [SerializeField] public Ammo[] AmmoTypes;
    //0 AR; 
    //1 Pistol; 
    //2 Sniper; 
    //3 Shotgun; 
    //4  Minigun; 

  




    [SerializeField] public Gun[] GunStats; 

    [Header("Keycard")]
    public List<KeyCardScriptable> Keycard = new List<KeyCardScriptable>();

   
    private void Update()
    {

        if (PlayerHP > MaxHP)
            PlayerHP = MaxHP;

        else if (PlayerArmour > MaxArmour)
            PlayerArmour = MaxArmour;
        else if (Clips > MaxAmountClips)
            Clips = MaxAmountClips;


        ClipsChecker();
        if (PlayerHP <= 0)
        {

        }
    }
    void ClipsChecker()
    {
        Clips = AmmoTypes[AmmoType].ClipsCurrent;
        MaxAmountClips = AmmoTypes[AmmoType].MaxClips;
        AmmoPerClip = AmmoTypes[AmmoType].AmmoPerClip;
    }

    
}

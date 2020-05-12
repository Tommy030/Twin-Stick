using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{

    public int HoldingWeapon;
    public bool NewWeapon;
    
    
    private PlayerStats Stats;
    [SerializeField]private Gun GunStats;

    public Gun NewGun;

    private void Awake()
    {
        Stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (NewWeapon)
        {
              Stats.AmmoPerClip = Stats.AmmoTypes[HoldingWeapon].AmmoPerClip;
              Stats.MaxAmountClips = Stats.AmmoTypes[HoldingWeapon].MaxClips;
              Stats.Clips = Stats.AmmoTypes[HoldingWeapon].ClipsCurrent;
              NewWeapon = !NewWeapon;
        }
        else
        {
            HoldingWeapon =  GunStats.WeaponType; 
            Stats.AmmoTypes[HoldingWeapon].ClipsCurrent = Stats.Clips;
        }
    }
    public void SwapGuns()
    {
       

        //Reset gun
        GunStats.Weaponspray = GunStats.StartingSpray;
        GunStats.FireRate = GunStats.StartingFireRate;


        HoldingWeapon = NewGun.WeaponType;
        GunStats = NewGun;
        
        NewWeapon = true;
    }
}

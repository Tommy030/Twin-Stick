using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour
{
    PlayerStats Stats;

    public int HoldingWeapon;
    public bool NewWeapon;
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
        }
        else
        {
            Stats.AmmoTypes[HoldingWeapon].ClipsCurrent = Stats.Clips;
        }
    }
}

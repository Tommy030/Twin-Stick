using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunstats : MonoBehaviour
{
    [Header("Adjustable")]
  
    [SerializeField] Gun CurrentStats;


   [SerializeField] PlayerStats Stats;
    public GunShoot Shoot;

    [Header("READOUTS")]
    [SerializeField] private int Ammo;
    [SerializeField] private float FireRate;
    private void Awake()
    {
        Shoot = FindObjectOfType<GunShoot>();
        Stats = GetComponent<PlayerStats>();
    }
    private void Update()
    {
        if (CurrentStats != null)
        {
        Shoot.Shoot(CurrentStats);
        LoadPrint(CurrentStats);

        }
    }

    public void LoadPrint(Gun A)
    {
        Ammo = A.AmmoInClip;
        FireRate = A.FireRate;
    }
    public void Swap(Gun gun)
    {
        //swap old weapon stats
        CurrentStats = gun;

        Stats.AmmoType = gun.WeaponType;
        //put in new weapon stats
    }
}

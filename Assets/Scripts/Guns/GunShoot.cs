using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("Adjustable")]
    [SerializeField] public float BulletSpeed;


    [Header("NonAdjustable")]
    [SerializeField] Transform FirePos;
    public Bullet Bull;
    public PlayerStats Stats;


    private bool Cooldown;
    private bool Reloading;

    [SerializeField] private float Timer;
    [SerializeField] private float TimerReload;

    private void Awake()
    {

        Stats = FindObjectOfType<PlayerStats>();
     
    }
    private void Update()
    {

    }

    void Time ( float FireRate)
    {

        if (Timer > 0)
        {
            Cooldown = true;

            Timer -= 0.5f * FireRate;
        }
        else if (Timer <= 0)
        {
            Cooldown = !Cooldown;
        }
    }
    public void Shoot(Gun WeaponHold)
    {
        Time(WeaponHold.FireRate);

        if (Input.GetMouseButton(0) && !Cooldown && WeaponHold.AmmoInClip > 0)
        {
            WeaponHold.AmmoInClip -= 1;
            Timer = 100;
            Bullet Bul = Instantiate(Bull, FirePos.position, FirePos.rotation) as Bullet;
            Bul.Bulletspeed = WeaponHold.BulletSpeed;
            Bul.Damage = WeaponHold.WeaponDamage;

        }
        Reload(WeaponHold);
    }
    void Reload(Gun WeaponHold)
    {
          if (Input.GetKey(KeyCode.R))
        {
            if (WeaponHold.AmmoInClip < WeaponHold.MaxAmmo && Stats.Clips > 0)
            {
                Stats.Clips -= 1;
                WeaponHold.AmmoInClip = WeaponHold.MaxAmmo;
            }
        }
    }
}

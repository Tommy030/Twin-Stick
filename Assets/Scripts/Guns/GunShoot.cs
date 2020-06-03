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
    public AmmoPooling Pool;

    private bool Cooldown;
    private bool Reloading;

    [SerializeField] private float Timer;
    [SerializeField] private float TimerReload;

    private void Awake()
    {
        Pool = FindObjectOfType<AmmoPooling>();
        Stats = FindObjectOfType<PlayerStats>();
     
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

        if (Input.GetMouseButton(0) && !Cooldown && WeaponHold.AmmoInClip > 0 && !Pause.StaticPause.Paused)
        {
           
            WeaponHold.AmmoInClip -= 1;
            Timer = 100;
            

            GameObject Bullets = ObjectPooling.ObjectPooler.GetPooledObject("Bullet");
            if (Bullets!= null)
            {
                Bullets.transform.position = FirePos.position;
                Bullets.transform.rotation = transform.rotation;
                Bullets.SetActive(true);
                Bullet Bul = Bullets.GetComponent<Bullet>();
                Bul.BulletInfo(WeaponHold.BulletSpeed, WeaponHold.WeaponDamage, true, "Player");

            }
            StaticStats.Stats.Shot += 1;
            
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

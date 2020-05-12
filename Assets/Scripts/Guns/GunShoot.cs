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
    

    public float FireRate;
    private bool Cooldown;
    private bool Reload;
    [SerializeField] private float Timer;
    [SerializeField] private float TimerReload;
    private void Awake()
    {

        Stats = FindObjectOfType<PlayerStats>();
        FireRate = Stats.FireRate;
    }
    private void Update()
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
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetMouseButton(0) && Cooldown == false && Stats.AmmoInUsedClip > 0) // voeg hierbij toe dat als reload true is het nie gebeurd.
        {
            Stats.AmmoInUsedClip -= 1;
            Timer = 100;
            Bullet Bul = Instantiate(Bull, FirePos.position, FirePos.rotation) as Bullet;
            Bul.Bulletspeed = BulletSpeed;
        }
        else if (Stats.AmmoInUsedClip == 0 )
        {

            TimerReload += Time.deltaTime;
            if (Input.GetKey(KeyCode.R))
            {
                if (Stats.Clips > 0)
                {
                    //reload...
                    Stats.Clips -= 1;
                    Stats.AmmoInUsedClip += Stats.AmmoPerClip;
                    if (Stats.AmmoInUsedClip > Stats.AmmoPerClip)
                        Stats.AmmoInUsedClip = Stats.AmmoPerClip;

                }
                //Reload = true;
            }
        }
    }
}

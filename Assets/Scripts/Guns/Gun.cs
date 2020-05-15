using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [Header("Adjustables")]

    public Sprite GunImage;
    
    public float StartingSpray;
    public float Weaponspray;
    public float MaxSpray;
    
    public int WeaponDamage;

    public float StartingFireRate;
    public float FireRate;
    public float MaxFireRate;

    public string WeaponName;
    [Tooltip("0 = AR, 1 = PISTOL, 2 = SNIPER, 3 = SHOTGUN, 4 = MINIGUN")]
    public int WeaponType;

    public int BulletSpeed;
    //0 AR; 
    //1 Pistol; 
    //2 Sniper; 
    //3 Shotgun; 
    //4  Minigun; 

    public int MinAmmo;
    public int AmmoInClip;
    public int MaxAmmo;

}

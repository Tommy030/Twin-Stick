using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class ScriptEnemy : ScriptableObject
{
    
    public float HP;
    public float MovementSpeed;

    public float Damage;
    public float KniveDamage;

    public float FireRate;
    public float BulletSpeed;

    //De Enemy Reload. 
    public float AmmoMax;
    public float AmmoInClip;

    
}

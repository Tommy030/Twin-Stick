using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class ScriptableEnemy : ScriptableObject
{

    
    public float HP;
    public float MovementSpeed; 
    
    public float Damage;
    public float KniveDamage;

    public float FireRate;

    //De Enemy Reload. 
    public float AmmoMax;
    public float AmmoInClip; 
}

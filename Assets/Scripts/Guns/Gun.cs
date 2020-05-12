using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public float StartingSpray;

    public float Weaponspray;

    public float MaxSpray;
    
    public int WeaponDamage;
    public int FireRate;
    public string WeaponName;
    
}

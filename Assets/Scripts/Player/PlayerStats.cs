using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Adjustables")]

    [SerializeField] public float PlayerHP;
    [SerializeField] public float PlayerArmour;
    [SerializeField] public float MovementSpeed;

    [SerializeField] public float MaxHP;
    [SerializeField] public float MaxArmour;
    [Header("Weapon")]
    [SerializeField] public int Ammocount;
    [SerializeField] public float WeaponDamage;
    [SerializeField] public float FireRate;
    [SerializeField] public string WeaponName;

    [Header("Keycard")]
    public List<string> Keycard = new List<string>();

    private void Update()
    {
        if (PlayerHP > MaxHP)
            PlayerHP = MaxHP;

        else if (PlayerArmour > MaxArmour)
            PlayerArmour = MaxArmour; 
    }
}

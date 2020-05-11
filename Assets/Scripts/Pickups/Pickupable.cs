using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    [Header("Adjustables")]
    [SerializeField] private float AmountAddedArmour;
    [SerializeField] private bool Armor;
    [SerializeField] private float AmountAddedHP;
    [SerializeField] private bool HP;

    [SerializeField] private bool Delete;

    [Header("Non-Adjustables")]
    PlayerStats Stats;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stats = collision.gameObject.GetComponent<PlayerStats>();
            if (Armor && Stats.PlayerArmour < Stats.MaxArmour)
            {
                Stats.PlayerArmour += AmountAddedArmour;
                Delete = true;
            }
            else if (HP && Stats.PlayerHP < Stats.MaxHP)
            {
                Stats.PlayerHP += AmountAddedHP;
                Delete = true;
            }
            if (Delete)
                Destroy(gameObject);

        } 

    }
}

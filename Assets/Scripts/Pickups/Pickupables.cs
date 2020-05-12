using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupables : MonoBehaviour
{
    [Header("Adjustables")]
    [SerializeField] private float AmountAddedArmour;
    [SerializeField] private bool Armor;

    [SerializeField] private float AmountAddedHP;
    [SerializeField] private bool HP;

    [SerializeField] private int AmountAddedClips;
    [SerializeField] private bool Clips;

    [Header("Non-Adjustables")]
    
    PlayerStats Stats;
    
    private bool Delete;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Stats = collision.gameObject.GetComponent<PlayerStats>();
            if (Armor && Stats.PlayerArmour < Stats.MaxArmour)
            {
                Stats.PlayerArmour += AmountAddedArmour;
                Delete = true;
            }
            if (HP && Stats.PlayerHP < Stats.MaxHP)
            {
                Stats.PlayerHP += AmountAddedHP;
                Delete = true;
            }
            if (Clips && Stats.Clips < Stats.MaxAmountClips)
            {
                Stats.Clips += AmountAddedClips;
                Delete = true;
            }
            if (Delete)
                Destroy(gameObject);
        } 

    }
}

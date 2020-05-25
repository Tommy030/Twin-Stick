using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gunstats : MonoBehaviour
{
    [Header("Adjustable")]
  
    [SerializeField] Gun CurrentStats;


   [SerializeField] PlayerStats Stats;
    public GunShoot Shoot;

    [Header("READOUTS")]
    [SerializeField] private int Ammo;
    [SerializeField] private float FireRate;


    [SerializeField]private bool Cheat;
  [SerializeField]  private Gun CheatStats;
    private Gun OldStats;
    private void Awake()
    {
        Shoot = FindObjectOfType<GunShoot>();
        Stats = GetComponent<PlayerStats>();
    }
    private void Update()
    {
        if (CurrentStats != null)
        {
        Shoot.Shoot(CurrentStats);
        LoadPrint(CurrentStats);

        }
        Cheating();
    }
    void Cheating()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
           
            if (!Cheat)
            {
                Cheat = true;
                if (CurrentStats != null)
                {
                OldStats = CurrentStats;
                }
                
                CurrentStats = CheatStats;
                CurrentStats.AmmoInClip += 1000;
                //StatsPlayer

                Stats.OldPlayerArmour = Stats.PlayerArmour;
                Stats.OldPlayerHP = Stats.PlayerHP;
                Stats.OldMaxHP = Stats.MaxHP;
                Stats.OldMaxArmour = Stats.MaxArmour;

                Stats.MaxHP += 1000000;
                Stats.MaxArmour += 1000000;
                Stats.PlayerHP += 1000000;
                Stats.PlayerArmour += 1000000;
            }
           else if (Cheat)
            {
                Cheat = false;
                CurrentStats = OldStats;


                Stats.MaxHP = Stats.OldMaxHP;
                Stats.MaxArmour = Stats.OldMaxArmour;
                Stats.PlayerHP = Stats.OldPlayerHP;
                Stats.PlayerArmour = Stats.OldPlayerArmour;
            }

        }
        
    }
    
    public void LoadPrint(Gun A)
    {
        Ammo = A.AmmoInClip;
        FireRate = A.FireRate;
    }
    public void Swap(Gun gun,GameObject GunPickedup)
    {
        if (!Cheat)
        {

        //swap old weapon stats
        CurrentStats = gun;

        Stats.AmmoType = gun.WeaponType;
            //ut in new weapon stats

            GunPickedup.SetActive(false);
        }
        
    }
    public void SentUI(Text Ammo,Text WeaponName, Text HP, Text Armour)
    {
   
        if (CurrentStats!= null)
        {
        Ammo.text = (CurrentStats.AmmoInClip.ToString() + "/" + CurrentStats.MaxAmmo.ToString());
        WeaponName.text = (CurrentStats.WeaponName);

        }
        HP.text = ("Health: " + Stats.PlayerHP.ToString() + "/" + Stats.MaxHP.ToString());
        Armour.text = ("Armour: "+Stats.PlayerArmour.ToString() + "/" + Stats.MaxArmour.ToString());
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsIntoUI : MonoBehaviour
{
   [SerializeField] Text Ammo;
   [SerializeField] Text CurrentWeapon;
    [SerializeField] Text Armour;
    [SerializeField] Text HP;
    Gunstats Stats;
    private void Awake()
    {
        Stats = FindObjectOfType<Gunstats>();
    }
    private void Update()
    {
        
        Stats.SentUI(Ammo, CurrentWeapon,HP,Armour);
    }
}

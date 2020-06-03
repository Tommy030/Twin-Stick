using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBAR : MonoBehaviour
{

    [SerializeField] Slider Armor;
    [SerializeField]Slider HP;


    private void Awake()
    {
      
    }
    private void Update()
    {
        Debug.Log("Hey");
        SetMax(PlayerManager.Instance.Player.GetComponent<PlayerStats>().MaxHP, HP, PlayerManager.Instance.Player.GetComponent<PlayerStats>().PlayerHP);
        SetMax(PlayerManager.Instance.Player.GetComponent<PlayerStats>().MaxArmour, Armor, PlayerManager.Instance.Player.GetComponent<PlayerStats>().PlayerArmour);
        SetBar(HP, PlayerManager.Instance.Player.GetComponent<PlayerStats>().PlayerHP);
        SetBar(Armor, PlayerManager.Instance.Player.GetComponent<PlayerStats>().PlayerArmour);
    }
    public void SetMax(float MaxAmount, Slider Slide, float currenthealth )
    {

        Slide.maxValue = MaxAmount;
        Slide.value = currenthealth;
    }
    public void SetBar(Slider Slde, float Current)
    {
        Slde.value = Current;
    }
}

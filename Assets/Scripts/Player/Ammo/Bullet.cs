﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    [Header("Adjustbales")]
    [SerializeField] public float Bulletspeed;
    [SerializeField] public float Damage;
    [SerializeField] public bool ShotByPlayer;
    [SerializeField] public string Shotby;

    TextMeshProUGUI meshText;

    private void Update()
    {
        transform.Translate(Vector3.forward * Bulletspeed * Time.deltaTime);
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (!ShotByPlayer)
        {
            if (collision.gameObject.tag == "Player")
            {

                PlayerStats HP = collision.gameObject.GetComponent<PlayerStats>();
                PopUp();
                HP.ShotAt(Damage, Shotby);
            }
         
            gameObject.SetActive(false);

        }
        if (ShotByPlayer)
        {
            if (collision.collider.tag == "Enemy")
            {
          
                EnemyFollow Enemy = collision.gameObject.GetComponent<EnemyFollow>();
                Enemy.Stats.HP -= Damage;

                PopUp();
                StaticStats.Stats.Hit += 1;
                StaticStats.Stats.Score += 100;

            
               
                gameObject.SetActive(false);
            }
            else if (collision.collider.gameObject.layer != 9)
            {
       
                gameObject.SetActive(false);
                
            }
            
        }
    }
    public void PopUp()
    {
        GameObject TextPop = ObjectPooling.ObjectPooler.GetPooledObject("Popup");
        meshText    = TextPop.GetComponent<TextMeshProUGUI>();
        
        if (TextPop != null)
        {

            TextPop.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            meshText.SetText(Damage.ToString());
            TextPop.SetActive(true);
            
        }
    }
    public void BulletInfo(float Speed, float BDamage, bool ShootByPlayer,string ShotByName)
    {
        Bulletspeed = Speed;
        Damage = BDamage;
        ShotByPlayer = ShootByPlayer;
        Shotby = ShotByName; 
    }
    
    

}

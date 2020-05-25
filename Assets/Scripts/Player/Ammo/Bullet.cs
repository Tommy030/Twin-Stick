using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [Header("Adjustbales")]
    [SerializeField] public float Bulletspeed;
    [SerializeField] public float Damage;
    [SerializeField] public bool ShotByPlayer;

    //note to self make enemy /play enum; 
    private void Update()
    {
        transform.Translate(Vector3.forward * Bulletspeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
  if (!ShotByPlayer)
        {
        gameObject.SetActive(false);
            
        }
        if (ShotByPlayer)
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.SetActive(false);
            }
        }
    }
   public void BulletInfo(float Speed, float BDamage, bool ShootByPlayer)
    {
        Bulletspeed = Speed;
        Damage = BDamage;
        ShotByPlayer = ShootByPlayer;
    }

}

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
            if (collision.gameObject.tag == "Player")
            {

                PlayerStats HP = collision.gameObject.GetComponent<PlayerStats>();
                if (HP.PlayerArmour > 0)
                {

                    HP.PlayerArmour -= Damage;
                    if (HP.PlayerArmour < 0)
                        HP.PlayerArmour = 0;
                }
                HP.PlayerHP -= Damage;
            }
            gameObject.SetActive(false);

        }
        if (ShotByPlayer)
        {
            if (collision.collider.tag == "Enemy")
            {
                Debug.Log("hit");
                EnemyFollow Enemy = collision.gameObject.GetComponent<EnemyFollow>();
                Enemy.Stats.HP -= Damage;
                gameObject.SetActive(false);

            }
            else if (collision.collider.gameObject.layer != 9)
            {
                Debug.Log("Hit");
       
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

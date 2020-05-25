using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField]private bool InHit;
    [SerializeField] Gun GunOnGround;

    Gunstats StatsGun;
    private void Awake()
    {
        GunOnGround = Instantiate(GunOnGround);
    }
    private void OnTriggerEnter(Collider other)
    {
        StatsGun =FindObjectOfType<Gunstats>();

        InHit = true;
    }
    private void OnTriggerExit(Collider other) { InHit = false; }
    private void Update()
    {
        if (InHit && Input.GetKey(KeyCode.E))
        {

            StatsGun.Swap(GunOnGround,gameObject);
        
        }
    }

}

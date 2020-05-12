using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
   [SerializeField] private Gun Stats;

    private CurrentWeapon Current;
    [SerializeField]private bool InHit;
    private void Start()
    {
      Current =   FindObjectOfType<CurrentWeapon>();
    }
    private void OnTriggerEnter(Collider other)
    {
        InHit = true;
    }
    private void OnTriggerExit(Collider other)
    {
        InHit = false;

    }

    private void Update()
    {
        if (InHit)
        {
            Current.NewGun = Stats;
            Current.NewWeapon = true;
            Current.SwapGuns();
            Destroy(gameObject);
        }
    }

}

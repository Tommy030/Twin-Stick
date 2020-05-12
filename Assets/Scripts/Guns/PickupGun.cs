using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
   [SerializeField] private Gun Stats;

    private CurrentWeapon Current;

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.GetComponent<CurrentWeapon>();
            other.gameObject.GetComponent<PlayerStats>();

            Current.NewGun = Stats;
            Current.SwapGuns();

        }
    }
}

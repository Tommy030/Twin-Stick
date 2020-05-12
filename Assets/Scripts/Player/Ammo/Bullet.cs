using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Adjustbales")]
    [SerializeField] public float Bulletspeed;

    private void Update()
    {
        transform.Translate(Vector3.forward * Bulletspeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [Tooltip("Als de deur een Keyard nodig heeft klik op dit vakje en gooi die key erin. ")]
    [SerializeField] private bool KeyCard ; 
    [SerializeField]KeyCardScriptable ThisDoorsKeyID;

    [SerializeField]  PlayerStats Stats;
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Stats = other.gameObject.GetComponent<PlayerStats>();


            if (Input.GetKey(KeyCode.E))
            {
                foreach (KeyCardScriptable Card in Stats.Keycard)
                {
                    if (Card == ThisDoorsKeyID)
                    {
                        
                        //een code om whatever deur nu te doen weetj. idk... geen zin in. als t goed is werkt dit idk. we zien wel
                    }
                        

                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpening = false;
    private bool isClosing = false;
    private bool isOpen = false;
    private float DoorTime = 0f;
    [SerializeField] private bool isVertical;
    [SerializeField] private BoxCollider Box;
    [SerializeField] private float OpenSpeed = 1f;
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
                if (KeyCard)
                {
                    foreach (KeyCardScriptable Card in Stats.Keycard)
                    {
                        if (Card == ThisDoorsKeyID)
                        {
                            if (!isOpen)
                            {
                              Opendeur();

                            }
                            //een code om whatever deur nu te doen weetj. idk... geen zin in. als t goed is werkt dit idk. we zien wel
                        }


                    }
                }
            if (!KeyCard)
                {
                    if (!isOpen)
                    {
                        Opendeur();

                    }
                }
            }
        }
    }
    void Opendeur()
    {
        isOpening = true;
    }
    private void Update()
    {
        if (isOpening)
        {
            Box.enabled = false;
            DoorTime += Time.deltaTime;
            if (DoorTime >= 3f)
            {
                isOpening = false;
                DoorTime = 0f;
                isOpen = true;
            }
            if (isVertical)
            {
                transform.position += (Vector3.forward * OpenSpeed) * Time.deltaTime;
            }
            else
            {
               transform.position += (Vector3.right * OpenSpeed) * Time.deltaTime;
            }
      
        }
        else
        {
            Box.enabled = true;
        }
        if (isOpen)
        {
            DoorTime += Time.deltaTime;
            if (DoorTime >= 6f)
            {
                DoorTime = 0f;
                isClosing = true;
                isOpen = false;
            }
        }
        if (isClosing)
        {
            Box.enabled = false;
            DoorTime += Time.deltaTime;
            if (DoorTime >= 3f)
            {
                isClosing = false;
                DoorTime = 0f;
            }
            if (isVertical)
            {
                transform.position -= (Vector3.forward * OpenSpeed) * Time.deltaTime;
            }
            else
            {
                transform.position -= (Vector3.right * OpenSpeed) * Time.deltaTime;
            }
        }
    }
    
}

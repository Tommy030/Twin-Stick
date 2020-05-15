using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New KeyCard", menuName = "Card")]
public class KeyCardScriptable : ScriptableObject
{
    Sprite KeyCardSprite;
    public int KeyCardNumber;  
}

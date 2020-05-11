using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Ammo",menuName = "Ammo")]
public class Ammo : ScriptableObject
{
    public string AmmoType;
    public int ClipsCurrent;
    public int MaxClips;
    public int AmmoPerClip;
}

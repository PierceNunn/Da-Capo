/*****************************************************************************
// File Name : RandomizedAudio.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : A simple ScriptableObject for storing a specific set
of AudioClips for repeated use.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomizedAudio : ScriptableObject
{
    public AudioClip[] clips;
}

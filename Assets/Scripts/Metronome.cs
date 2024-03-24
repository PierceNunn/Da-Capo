/*****************************************************************************
// File Name : Metronome.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This simple script plays a specified metronome sound
// whenever it has its function called, ideally at a constant rate.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] private AudioSource _metronomeSound;

    /// <summary>
    /// Plays the metronome sound.
    /// </summary>
    /// <param name="delay">time to wait before playing sound.</param>
    public void MetronomeTick(double delay)
    {
        _metronomeSound.PlayScheduled(delay);
    }
}

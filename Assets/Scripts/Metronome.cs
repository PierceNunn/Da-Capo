using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] private AudioSource _metronomeSound;
    public void MetronomeTick(double delay)
    {
        _metronomeSound.PlayScheduled(delay);
    }
}

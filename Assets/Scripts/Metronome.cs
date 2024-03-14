using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] private AudioSource _metronomeSound;
    public void MetronomeTick()
    {
        _metronomeSound.Play();
    }
}

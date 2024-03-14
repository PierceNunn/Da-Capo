using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _missSound;
    public void OnNoteA()
    {
        print(IsButtonTimed());
    }

    public bool IsButtonTimed()
    {
        float targetTime = Mathf.Round(RhythmController.instance.LoopPositionInBeats);
        float actualTime = RhythmController.instance.LoopPositionInBeats;
        if (actualTime <= RhythmController.instance.CurrentDifficulty.TimingWindow + targetTime &&
            actualTime >= RhythmController.instance.CurrentDifficulty.TimingWindow - targetTime)
        {
            _hitSound.Play();
            return true;
        }
        _missSound.Play();
        return false;
    }
}

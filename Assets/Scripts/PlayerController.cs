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
        float[] surroundingNoteTimes = RhythmController.instance.GetSurroundingNotesTime();

        if(CheckButtonTiming(surroundingNoteTimes[0]) || CheckButtonTiming(surroundingNoteTimes[1]))
        {
            _hitSound.Play();
            return true;
        }

        _missSound.Play();
        return false;
    }

    public bool CheckButtonTiming(float timeToCheck)
    {
        float actualTime = RhythmController.instance.SongPosInBeats;
        if (actualTime < timeToCheck + RhythmController.instance.CurrentDifficulty.TimingWindow &&
            actualTime > timeToCheck - RhythmController.instance.CurrentDifficulty.TimingWindow)
        {
            return true;
        }
        return false;
    }
}

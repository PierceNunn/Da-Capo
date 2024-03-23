using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _missSound;
    public void OnNoteA()
    {
        print(IsButtonTimed(IndividualNoteChart.possiblePitches.A));
    }
    public void OnNoteB()
    {
        print(IsButtonTimed(IndividualNoteChart.possiblePitches.B));
    }
    public void OnNoteC()
    {
        print(IsButtonTimed(IndividualNoteChart.possiblePitches.C));
    }
    public void OnNoteD()
    {
        print(IsButtonTimed(IndividualNoteChart.possiblePitches.D));
    }
    public void OnNoteE()
    {
        print(IsButtonTimed(IndividualNoteChart.possiblePitches.E));
    }
    public void OnNoteF()
    {
        print(IsButtonTimed(IndividualNoteChart.possiblePitches.F));
    }
    public void OnNoteG()
    {
        print(IsButtonTimed(IndividualNoteChart.possiblePitches.G));
    }

    public bool IsButtonTimed(IndividualNoteChart.possiblePitches pitch)
    {
        float[] surroundingNoteTimes = RhythmController.instance.GetSurroundingNotesTime();

        if(CheckButtonTiming(surroundingNoteTimes[0], pitch) || CheckButtonTiming(surroundingNoteTimes[1], pitch))
        {
            _hitSound.Play();
            return true;
        }

        _missSound.Play();
        return false;
    }

    public bool CheckButtonTiming(float timeToCheck, IndividualNoteChart.possiblePitches pitch)
    {
        float actualTime = RhythmController.instance.SongPosInBeats;
        IndividualNoteChart targetNote = RhythmController.instance.CurrentSong.GetNoteAtTime(timeToCheck, 0);

        if (actualTime < timeToCheck + RhythmController.instance.CurrentDifficulty.TimingWindow &&
            actualTime > timeToCheck - RhythmController.instance.CurrentDifficulty.TimingWindow &&
            pitch == targetNote.Pitch)
        {
            return true;
        }
        return false;
    }
}

/*****************************************************************************
// File Name : PlayerController.cs
// Author : Pierce Nunnelley
// Creation Date : March 24, 2024
//
// Brief Description : This script tracks and handles player input commands.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _missSound;

    /// <summary>
    /// Calls IsButtonTimed with the pitch of A.
    /// </summary>
    public void OnNoteA()
    {
        IsButtonTimed(IndividualNoteChart.possiblePitches.A);
    }
    /// <summary>
    /// Calls IsButtonTimed with the pitch of B.
    /// </summary>
    public void OnNoteB()
    {
        IsButtonTimed(IndividualNoteChart.possiblePitches.B);
    }
    /// <summary>
    /// Calls IsButtonTimed with the pitch of C.
    /// </summary>
    public void OnNoteC()
    {
        IsButtonTimed(IndividualNoteChart.possiblePitches.C);
    }
    /// <summary>
    /// Calls IsButtonTimed with the pitch of D.
    /// </summary>
    public void OnNoteD()
    {
        IsButtonTimed(IndividualNoteChart.possiblePitches.D);
    }
    /// <summary>
    /// Calls IsButtonTimed with the pitch of E.
    /// </summary>
    public void OnNoteE()
    {
        IsButtonTimed(IndividualNoteChart.possiblePitches.E);
    }
    /// <summary>
    /// Calls IsButtonTimed with the pitch of F.
    /// </summary>
    public void OnNoteF()
    {
        IsButtonTimed(IndividualNoteChart.possiblePitches.F);
    }
    /// <summary>
    /// Calls IsButtonTimed with the pitch of G.
    /// </summary>
    public void OnNoteG()
    {
        IsButtonTimed(IndividualNoteChart.possiblePitches.G);
    }

    /// <summary>
    /// Checks if a button press counts as a successful hit or not.
    /// </summary>
    /// <param name="pitch">the pitch to check.</param>
    /// <returns>whether or not a button press was successful.</returns>
    public bool IsButtonTimed(IndividualNoteChart.possiblePitches pitch)
    {
        float[] surroundingNoteTimes = RhythmController.instance.GetSurroundingNotesTime();

        if(CheckButtonTiming(surroundingNoteTimes[0], pitch) || CheckButtonTiming(surroundingNoteTimes[1], pitch))
        {
            _hitSound.Play();
            FindObjectOfType<PointsHandler>().NoteHitPoints();
            return true;
        }

        _missSound.Play();
        FindObjectOfType<PointsHandler>().NoteMissPoints();
        return false;
    }

    /// <summary>
    /// Checks if a given time is close enough to the current time to be hittable.
    /// </summary>
    /// <param name="timeToCheck">the time to compare to the current time.</param>
    /// <param name="pitch">the note's pitch.</param>
    /// <returns></returns>
    public bool CheckButtonTiming(float timeToCheck, IndividualNoteChart.possiblePitches pitch)
    {
        float actualTime = RhythmController.instance.SongPosInBeats;
        IndividualNoteChart targetNote = RhythmController.instance.CurrentSong.GetNoteAtTime(timeToCheck, 0);

        if (actualTime < timeToCheck + RhythmController.instance.CurrentDifficulty.TimingWindow &&
            actualTime > timeToCheck - RhythmController.instance.CurrentDifficulty.TimingWindow &&
            (pitch == targetNote.Pitch || RhythmController.instance.CurrentDifficulty.OneButtonMode))
        {
            return true;
        }
        return false;
    }
}

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
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _missSound;
    [SerializeField] private GameObject _hitParticle;

    /// <summary>
    /// Sets volume of SFX according to PlayerPrefs.
    /// </summary>
    public void Start()
    {
        _hitSound.volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        _missSound.volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

    /// <summary>
    /// Calls IsButtonTimed with the pitch of A.
    /// </summary>
    public void OnNoteA()
    {
        if (PlayerPrefs.GetInt("fourButtonMode", 0) != 1)
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
        if(PlayerPrefs.GetInt("fourButtonMode", 0) != 1)
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
    /// Calls IsButtonTimed with preset values for the sake of Four Button Mode.
    /// </summary>
    /// <param name="iValue">value recieved from input</param>
    public void OnSimpleNotes(InputValue iValue)
    {
        Vector2 inputMovement = iValue.Get<Vector2>();
        if(PlayerPrefs.GetInt("fourButtonMode", 0) == 1)
        {
            if (inputMovement.x == 1)
                IsButtonTimed(IndividualNoteChart.possiblePitches.A);
            if (inputMovement.x == -1)
                IsButtonTimed(IndividualNoteChart.possiblePitches.C);
            if (inputMovement.y == 1)
                IsButtonTimed(IndividualNoteChart.possiblePitches.E);
            if (inputMovement.y == -1)
                IsButtonTimed(IndividualNoteChart.possiblePitches.G);
        }
        
        
    }

    /// <summary>
    /// Checks if a button press counts as a successful hit or not.
    /// </summary>
    /// <param name="pitch">the pitch to check.</param>
    /// <returns>whether or not a button press was successful.</returns>
    public bool IsButtonTimed(IndividualNoteChart.possiblePitches pitch)
    {
        float[] surroundingNoteTimes = RhythmController.instance.GetSurroundingNotesTime();

        if(PlayerPrefs.GetInt("fourButtonMode", 0) == 1 && pitch != 
            IndividualNoteChart.possiblePitches.G)
        {

            IndividualNoteChart.possiblePitches checkingPitch = pitch + 1;
            if (CheckButtonTiming(surroundingNoteTimes[0], checkingPitch) ||
                CheckButtonTiming(surroundingNoteTimes[1], checkingPitch))
            {
                NoteHitBehavior();
                return true;
            }
        }

        if(CheckButtonTiming(surroundingNoteTimes[0], pitch) || CheckButtonTiming(surroundingNoteTimes[1], pitch))
        {
            NoteHitBehavior();
            return true;
        }

        NoteMissBehavior();
        return false;
    }

    /// <summary>
    /// Applied effects of hitting a note and plays a sound effect.
    /// </summary>
    public void NoteHitBehavior()
    {
        
        _hitSound.Play();
        FindObjectOfType<PointsHandler>().NoteHitPoints();
        FindObjectOfType<PlayerHealthManager>().gainHealth
        (RhythmController.instance.CurrentDifficulty.HealthRegen);
    }

    /// <summary>
    /// Applied effects of missing a note and plays a sound effect.
    /// </summary>
    public void NoteMissBehavior()
    {
        _missSound.Play();
        FindObjectOfType<PointsHandler>().NoteMissPoints();
        FindObjectOfType<PlayerHealthManager>().loseHealth(1);
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
            (pitch == targetNote.Pitch || RhythmController.instance.CurrentDifficulty.OneButtonMode ||
            PlayerPrefs.GetInt("oneButtonMode", 0) == 1))
        {
            Vector3 particlePos = new Vector3(timeToCheck - actualTime, transform.position.y, transform.position.z);
            Instantiate(_hitParticle, particlePos, Quaternion.identity);
            return true;
        }
        return false;
    }
}

/*****************************************************************************
// File Name : IndividualNoteChart.cs
// Author : Pierce Nunnelley
// Creation Date : March 24, 2024
//
// Brief Description : This serializable script represents a note on a note
// chart, holding both a NoteTemplate and a pitch.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class IndividualNoteChart
{
    public enum possiblePitches
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G
    }
    [SerializeField] private NoteTemplate _note;
    [SerializeField] private possiblePitches _pitch;

    public NoteTemplate Note { get => _note; set => _note = value; }
    public possiblePitches Pitch { get => _pitch; set => _pitch = value; }

    /// <summary>
    /// Find the height offset for the given pitch.
    /// </summary>
    /// <returns>int representing height modifier</returns>
    public int PitchHeightModifier()
    {
        switch (_pitch)
        {
            case (possiblePitches.A):
                return 3;
            case (possiblePitches.B):
                return 4;
            case (possiblePitches.C):
                return 5;
            case (possiblePitches.D):
                return 6;
            case (possiblePitches.E):
                return 7;
            case (possiblePitches.F):
                return 8;
            case (possiblePitches.G):
                return 2;
            default:
                return 0;
        }
    }
}

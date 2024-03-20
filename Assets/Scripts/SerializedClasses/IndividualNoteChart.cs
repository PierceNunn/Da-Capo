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

    public int PitchHeightModifier()
    {
        switch (_pitch)
        {
            case (possiblePitches.A):
                return 0;
            case (possiblePitches.B):
                return 1;
            case (possiblePitches.C):
                return 2;
            case (possiblePitches.D):
                return 3;
            case (possiblePitches.E):
                return 4;
            case (possiblePitches.F):
                return 5;
            case (possiblePitches.G):
                return 6;
            default:
                return 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class IndividualNoteChart
{
    public enum possiblePitches
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6
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
                return 9;
            default:
                return 0;
        }
    }
}

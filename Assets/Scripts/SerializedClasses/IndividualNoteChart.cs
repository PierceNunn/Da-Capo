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
}

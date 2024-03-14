using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MeasureChart
{
    [SerializeField] private IndividualNoteChart[] _measureNotes;

    public IndividualNoteChart[] MeasureNotes { get => _measureNotes; set => _measureNotes = value; }
}

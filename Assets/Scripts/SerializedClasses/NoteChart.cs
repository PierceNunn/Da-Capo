using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteChart
{
    [SerializeField] private MeasureChart[] _measures;

    public MeasureChart[] Measures { get => _measures; set => _measures = value; }
}

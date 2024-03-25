/*****************************************************************************
// File Name : MeasureChart.cs
// Author : Pierce Nunnelley
// Creation Date : March 24, 2024
//
// Brief Description : This serializable script holds an array of 
// IndividualNoteCharts, primarily for the sake of organization.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MeasureChart
{
    [SerializeField] private IndividualNoteChart[] _measureNotes;

    public IndividualNoteChart[] MeasureNotes { get => _measureNotes; set => _measureNotes = value; }
}

/*****************************************************************************
// File Name : NoteChart.cs
// Author : Pierce Nunnelley
// Creation Date : March 24, 2024
//
// Brief Description : This serializable script holds an array of MeasureCharts,
// primarily for the sake of organization.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteChart
{
    [SerializeField] private MeasureChart[] _measures;

    public MeasureChart[] Measures { get => _measures; set => _measures = value; }
}

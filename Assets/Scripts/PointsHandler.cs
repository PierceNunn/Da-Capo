/*****************************************************************************
// File Name : PointsHandler.cs
// Author : Pierce Nunnelley
// Creation Date : March 24, 2024
//
// Brief Description : This script stores/manages points while playing a level.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    private int totalPoints = 0;
    private int combo = 0;

    public int TotalPoints { get => totalPoints; set => totalPoints = value; }
    public int Combo { get => combo; set => combo = value; }

    /// <summary>
    /// increment combo, and add to TotalPoints based on difficulty and combo.
    /// </summary>
    public void NoteHitPoints()
    {
        Combo++;
        TotalPoints += (int)(1 * Combo * RhythmController.instance.CurrentDifficulty.ScoreMultiplier);
    }

    /// <summary>
    /// Reset combo to 0.
    /// </summary>
    public void NoteMissPoints()
    {
        Combo = 0;
    }
}

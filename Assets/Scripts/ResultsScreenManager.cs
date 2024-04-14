/*****************************************************************************
// File Name : ResultsScreenManager.cs
// Author : Pierce Nunnelley
// Creation Date : April 14, 2024
//
// Brief Description : This script updates the display of stats on the Results
// screen.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _topScoreDisplay;

    /// <summary>
    /// Updates the results' display.
    /// </summary>
    public void displayResults()
    {
        _scoreDisplay.text = "Score: " + FindObjectOfType<PointsHandler>().TotalPoints;
        _topScoreDisplay.text = "High Score: " + RhythmController.instance.CurrentSong.BestScores[
                (int)RhythmController.instance.CurrentDifficulty.Category];
    }
}

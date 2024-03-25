/*****************************************************************************
// File Name : ScoreUIHandler.cs
// Author : Pierce Nunnelley
// Creation Date : March 24, 2024
//
// Brief Description : This script manages the UI which displays the current
score and combo in the scene.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _comboDisplay;
    [SerializeField] private PointsHandler _currentPointsHandler;
    /// <summary>
    /// Change the given text to display the current points and combo.
    /// </summary>
    void Update()
    {
        _scoreDisplay.text = "Points: " + _currentPointsHandler.TotalPoints;
        _comboDisplay.text = "Combo: " + _currentPointsHandler.Combo;
    }
}

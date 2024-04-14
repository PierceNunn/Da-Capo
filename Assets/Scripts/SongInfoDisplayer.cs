/*****************************************************************************
// File Name : SongInfoDisplayer.cs
// Author : Pierce Nunnelley
// Creation Date : April 13, 2024
//
// Brief Description : This script displays select information about a song
// via text.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongInfoDisplayer : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _topScoreDisplay;
    [SerializeField] private MusicChartTemplate _displayedSong;
    [SerializeField] private DifficultyTemplate.scoreCategories _scoreCategoryToDisplay;

    /// <summary>
    /// displays the high score for the input song.
    /// </summary>
    void Start()
    {
        print((int)_scoreCategoryToDisplay);
        _topScoreDisplay.text = "Best Score: " + _displayedSong.BestScores[((int)_scoreCategoryToDisplay)];
    }

}

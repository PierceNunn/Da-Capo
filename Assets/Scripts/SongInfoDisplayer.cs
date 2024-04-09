using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongInfoDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topScoreDisplay;
    [SerializeField] private MusicChartTemplate _displayedSong; 
    void Start()
    {
        _topScoreDisplay.text = "Best Score: " + _displayedSong.BestScores[0];
    }

}

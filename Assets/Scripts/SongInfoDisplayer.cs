using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongInfoDisplayer : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _topScoreDisplay;
    [SerializeField] private MusicChartTemplate _displayedSong;
    [SerializeField] private DifficultyTemplate.scoreCategories _scoreCategoryToDisplay;
    void Start()
    {
        print((int)_scoreCategoryToDisplay);
        _topScoreDisplay.text = "Best Score: " + _displayedSong.BestScores[((int)_scoreCategoryToDisplay)];
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongInfoDisplayer : MonoBehaviour
{
    private enum scoreCategories
    {
        easy = 0,
        normal = 1,
        hard = 2
    }
    [SerializeField] private TextMeshProUGUI _topScoreDisplay;
    [SerializeField] private MusicChartTemplate _displayedSong;
    [SerializeField] private scoreCategories _scoreCategoryToDisplay;
    void Start()
    {
        print((int)_scoreCategoryToDisplay);
        _topScoreDisplay.text = "Best Score: " + _displayedSong.BestScores[((int)_scoreCategoryToDisplay)];
    }

}

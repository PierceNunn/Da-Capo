using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _topScoreDisplay;
    public void displayResults()
    {
        _scoreDisplay.text = "Score: " + FindObjectOfType<PointsHandler>().TotalPoints;
        _topScoreDisplay.text = "High Score: " + RhythmController.instance.CurrentSong.BestScores[
                (int)RhythmController.instance.CurrentDifficulty.Category];
    }
}

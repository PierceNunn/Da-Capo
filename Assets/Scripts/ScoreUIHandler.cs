using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private TextMeshProUGUI _comboDisplay;
    [SerializeField] private PointsHandler _currentPointsHandler;
    private void Start()
    {
        //currentPointsHandler = FindObjectOfType<PointsHandler>();
    }
    void Update()
    {
        _scoreDisplay.text = "Points: " + _currentPointsHandler.TotalPoints;
        _comboDisplay.text = "Combo: " + _currentPointsHandler.Combo;
    }
}

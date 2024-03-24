using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    private int totalPoints = 0;
    private int combo = 0;

    public int TotalPoints { get => totalPoints; set => totalPoints = value; }
    public int Combo { get => combo; set => combo = value; }

    public void NoteHitPoints()
    {
        Combo++;
        TotalPoints += (int)(1 * Combo * RhythmController.instance.CurrentDifficulty.ScoreMultiplier);
    }

    public void NoteMissPoints()
    {
        Combo = 0;
    }
}

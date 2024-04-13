/*****************************************************************************
// File Name : TimingWindowVisualizer.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This script creates a highlighted zone on the music
chart, indicating the area in which hitting a button for a note counts.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingWindowVisualizer : MonoBehaviour
{
    /// <summary>
    /// Calls SetTimingWindow on start.
    /// </summary>
    private void Start()
    {
        SetTimingWindow();
    }

    /// <summary>
    /// Sets the gameObject's width to roughly encapsulate the area that button presses are accepted per note.
    /// </summary>
    void SetTimingWindow()
    {
        float timingWindow = RhythmController.instance.CurrentDifficulty.TimingWindow;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, timingWindow * 1.75f 
            * RhythmController.instance.CurrentDifficulty.ScrollSpeed, gameObject.transform.localScale.z);
    }
}

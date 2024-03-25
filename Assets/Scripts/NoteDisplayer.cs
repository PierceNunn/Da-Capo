/*****************************************************************************
// File Name : NoteDisplayer.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This script spawns visual representations of the current
// song, to appear in-game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _lastNoteDisplay;
    [SerializeField] private float _baseHeight;
    [SerializeField] private float _noteSpacingY;

    /// <summary>
    /// Calls LoadNotes for each measure on startup, loading all of the notes visually.
    /// </summary>
    void Start()
    {
        for (int i = 0; i < RhythmController.instance.CurrentSong.SongChart.Measures.Length; i++)
        {
            LoadNotes(i); //load notes for each measure
        }
    }

    /// <summary>
    /// Creates sprites with NoteControllers for each note in a measure.
    /// </summary>
    /// <param name="measure">the measure to perform the function on.</param>
    void LoadNotes(int measure)
    {
        MeasureChart toLoad = RhythmController.instance.CurrentSong.SongChart.Measures[measure];
        for(int i = 0; i < toLoad.MeasureNotes.Length; i++)
        {
            float noteTime = RhythmController.instance.CurrentSong.GetGivenNoteTime(measure, i);

            GameObject newNote = Instantiate(_lastNoteDisplay);
            newNote.GetComponent<NoteController>().SetIndividualNote(toLoad.MeasureNotes[i],
                _noteSpacingY, _baseHeight, noteTime);
        }
    }
}

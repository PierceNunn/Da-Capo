/*****************************************************************************
// File Name : MusicChartTemplate.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This script acts as the template for Music Charts,
// holding important information about a song as well as a NoteChart which
// dictates the notes needed to hit
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MusicChartTemplate : ScriptableObject
{
    [SerializeField] private AudioClip _song;
    [SerializeField] private int _BPM;
    [SerializeField] private NoteChart _songChart;
    [SerializeField] private int[] _bestScores = { 0, 0, 0 };

    public NoteChart SongChart { get => _songChart; set => _songChart = value; }
    public int BPM { get => _BPM; set => _BPM = value; }
    public AudioClip Song { get => _song; set => _song = value; }
    public int[] BestScores { get => _bestScores; set => _bestScores = value; }

    /// <summary>
    /// Finds the time that the next note is played.
    /// </summary>
    /// <param name="loopPositionInBeats">The progress through the current measure.</param>
    /// <param name="completedLoops">the current measure in _songChart.</param>
    /// <returns></returns>
    public float GetNextNoteTime(int completedLoops)
    {
        MeasureChart currentMeasure = SongChart.Measures[completedLoops]; //get current measure
        float result = RhythmController.instance.BeatsPerLoop * completedLoops; //value to return as next note's hit time
        for (int i = 0; i < currentMeasure.MeasureNotes.Length; i++)
        {
            if (result >= RhythmController.instance.SongPosInBeats && !currentMeasure.MeasureNotes[i].Note.IsRest)
            {
                return result;
            }
            result += currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        if(SongChart.Measures.Length > completedLoops)
        {
            return GetNextNoteTime(completedLoops + 1);
        }
        return 0f;
    }

    /// <summary>
    /// Finds the time that the previous note was played.
    /// </summary>
    /// <param name="loopPositionInBeats">The progress through the current measure.</param>
    /// <param name="completedLoops">the current measure in _songChart.</param>
    /// <returns></returns>
    public float GetLastNoteTime(float loopPositionInBeats, int completedLoops, float measureTimeInBeats)
    {
        MeasureChart currentMeasure = SongChart.Measures[completedLoops]; //get current measure
        float result = measureTimeInBeats; //value to return as next note's hit time
        for (int i = currentMeasure.MeasureNotes.Length - 1; i >= 0 ; i--)
        {
            if (result <= loopPositionInBeats && !currentMeasure.MeasureNotes[i].Note.IsRest)
            {
                return result;

            }
            result -= currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        return measureTimeInBeats;
    }

    /// <summary>
    /// Gets the note playing at a given time
    /// </summary>
    /// <param name="noteTime">the time at which to check</param>
    /// <param name="targetMeasure">the index of the measure to start at.</param>
    /// <returns></returns>
    public IndividualNoteChart GetNoteAtTime(float noteTime, int targetMeasure)
    {
        //call self for a different measure if time is outside of bounds of measure
        if(noteTime < 0f && targetMeasure > 0)
        {
            return GetNoteAtTime(noteTime + RhythmController.instance.BeatsPerLoop, targetMeasure - 1);
        }
        if(noteTime > RhythmController.instance.BeatsPerLoop && targetMeasure < SongChart.Measures.Length)
        {
            return GetNoteAtTime(noteTime - RhythmController.instance.BeatsPerLoop, targetMeasure + 1);
        }

        MeasureChart currentMeasure = SongChart.Measures[targetMeasure];
        float elapsedTestTime = 0;
        for (int i = 0; i < currentMeasure.MeasureNotes.Length; i++)
        { 
            if ((elapsedTestTime + currentMeasure.MeasureNotes[i].Note.NoteLength) > noteTime)
            {
                
                return currentMeasure.MeasureNotes[i];
            }
            elapsedTestTime += currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        Debug.Log("GetNoteAtTime default case");
        return SongChart.Measures[targetMeasure + 1].MeasureNotes[0];
    }

    /// <summary>
    /// Gets the time of a given note.
    /// </summary>
    /// <param name="measure">index of the measure to check.</param>
    /// <param name="noteToGetTime">index of the note to check.</param>
    /// <returns></returns>
    public float GetGivenNoteTime(int measure, int noteToGetTime)
    {
        MeasureChart currentMeasure = SongChart.Measures[measure];
        //start with elapsed beats prior to note's measure
        float returnValue = RhythmController.instance.BeatsPerLoop * measure;
        for(int i = 0; i < noteToGetTime; i++)
        {
            returnValue += currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        return returnValue;
    }

    /// <summary>
    /// Gets the next note to play.
    /// </summary>
    /// <param name="loopPositionInBeats">time through the current measure, in beats.</param>
    /// <param name="completedLoops">index of measure to check.</param>
    /// <returns>the next note to play.</returns>
    public IndividualNoteChart GetNextNote(float loopPositionInBeats, int completedLoops)
    {
        return GetNoteAtTime(GetNextNoteTime(completedLoops), completedLoops);
    }
    /// <summary>
    /// Gets the Last note to play.
    /// </summary>
    /// <param name="loopPositionInBeats">time through the current loop, in beats.</param>
    /// <param name="completedLoops">index of measure to check.</param>
    /// <param name="measureTimeInBeats">measure time in beats.</param>
    /// <returns>the last note to play.</returns>
    public IndividualNoteChart GetLastNote(float loopPositionInBeats, int completedLoops, float measureTimeInBeats)
    {
        return GetNoteAtTime(GetLastNoteTime(loopPositionInBeats, completedLoops, measureTimeInBeats), completedLoops);
    }

}

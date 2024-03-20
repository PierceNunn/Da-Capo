using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MusicChartTemplate : ScriptableObject
{
    [SerializeField] private AudioClip _song;
    [SerializeField] private int _BPM;
    [SerializeField] private NoteChart _songChart;

    /// <summary>
    /// Finds the time that the next note is played.
    /// </summary>
    /// <param name="loopPositionInBeats">The progress through the current measure.</param>
    /// <param name="completedLoops">the current measure in _songChart.</param>
    /// <returns></returns>
    public float GetNextNoteTime(float loopPositionInBeats, int completedLoops)
    {
        MeasureChart currentMeasure = _songChart.Measures[completedLoops]; //get current measure
        float result = 0f; //value to return as next note's hit time
        for(int i = 0; i < currentMeasure.MeasureNotes.Length; i++)
        {
            if (result >= loopPositionInBeats)
            {
                return result;

            }
            result += currentMeasure.MeasureNotes[i].Note.NoteLength;
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
        MeasureChart currentMeasure = _songChart.Measures[completedLoops]; //get current measure
        float result = measureTimeInBeats; //value to return as next note's hit time
        for (int i = currentMeasure.MeasureNotes.Length - 1; i >= 0 ; i--)
        {
            if (result < loopPositionInBeats)
            {
                return result;

            }
            result -= currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        return measureTimeInBeats;
    }

    public IndividualNoteChart GetNoteAtTime(float noteTime, int targetMeasure)
    {
        MeasureChart currentMeasure = _songChart.Measures[targetMeasure];
        float elapsedTestTime = 0;
        for (int i = 0; i <= currentMeasure.MeasureNotes.Length; i++)
        {
            Debug.Log(i);
            if ((elapsedTestTime + currentMeasure.MeasureNotes[i].Note.NoteLength) > noteTime)
            {
                
                return currentMeasure.MeasureNotes[i];
            }
            elapsedTestTime += currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        Debug.Log("GetNoteAtTime default case");
        return currentMeasure.MeasureNotes[currentMeasure.MeasureNotes.Length];
    }

    public IndividualNoteChart GetNextNote(float loopPositionInBeats, int completedLoops)
    {
        return GetNoteAtTime(GetNextNoteTime(loopPositionInBeats, completedLoops), completedLoops);
    }
    public IndividualNoteChart GetLastNote(float loopPositionInBeats, int completedLoops, float measureTimeInBeats)
    {
        return GetNoteAtTime(GetLastNoteTime(loopPositionInBeats, completedLoops, measureTimeInBeats), completedLoops);
    }

}

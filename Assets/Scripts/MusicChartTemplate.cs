using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MusicChartTemplate : ScriptableObject
{
    [SerializeField] private AudioClip _song;
    [SerializeField] private int _BPM;
    [SerializeField] private NoteChart _songChart;

    public float GetNextNoteTime(float loopPositionInBeats, int completedLoops)
    {
        MeasureChart currentMeasure = _songChart.Measures[completedLoops]; //get current measure
        float result = 0f; //value to return as next note's hit time
        for(int i = 0; i < currentMeasure.MeasureNotes.Length; i++)
        {
            if (!currentMeasure.MeasureNotes[i].Note.IsRest && result >= loopPositionInBeats)
            {
                return result;

            }
            result += currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        return 0f;
    }

    public float GetLastNoteTime(float loopPositionInBeats, int completedLoops, float measureTimeInBeats)
    {
        MeasureChart currentMeasure = _songChart.Measures[completedLoops]; //get current measure
        float result = measureTimeInBeats; //value to return as next note's hit time
        for (int i = currentMeasure.MeasureNotes.Length; i >= 0 ; i++)
        {
            if (!currentMeasure.MeasureNotes[i].Note.IsRest && result < loopPositionInBeats)
            {
                return result;

            }
            result -= currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        return measureTimeInBeats;
    }

    public NoteTemplate GetNoteAtTime(float noteTime, int targetMeasure)
    {
        MeasureChart currentMeasure = _songChart.Measures[targetMeasure];
        float elapsedTestTime = 0;
        for (int i = 0; i < currentMeasure.MeasureNotes.Length - 1; i++)
        {
            if((elapsedTestTime + currentMeasure.MeasureNotes[i].Note.NoteLength) >= noteTime)
            {
                return currentMeasure.MeasureNotes[i].Note;
            }
            elapsedTestTime += currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        return null;
    }

    public NoteTemplate GetNextNote(float loopPositionInBeats, int completedLoops)
    {
        MeasureChart currentMeasure = _songChart.Measures[completedLoops]; //get current measure
        float result = 0f; //value to return as next note's hit time
        for (int i = 0; i < currentMeasure.MeasureNotes.Length; i++)
        {
            if (result >= loopPositionInBeats)
            {
                return currentMeasure.MeasureNotes[i].Note;

            }
            result += currentMeasure.MeasureNotes[i].Note.NoteLength;
        }
        return currentMeasure.MeasureNotes[0].Note;
    }

}

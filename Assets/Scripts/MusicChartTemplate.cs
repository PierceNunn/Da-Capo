using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MusicChartTemplate : ScriptableObject
{
    [SerializeField] private AudioClip _song;
    [SerializeField] private int _BPM;
    [SerializeField] private NoteChart _songChart;

    public NoteChart SongChart { get => _songChart; set => _songChart = value; }

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

    public IndividualNoteChart GetNoteAtTime(float noteTime, int targetMeasure)
    {
        if(noteTime < 0f)
        {
            return GetNoteAtTime(noteTime + RhythmController.instance.BeatsPerLoop, targetMeasure - 1);
        }
        MeasureChart currentMeasure = SongChart.Measures[targetMeasure];
        float elapsedTestTime = 0;
        for (int i = 0; i <= currentMeasure.MeasureNotes.Length; i++)
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

    public IndividualNoteChart GetNextNote(float loopPositionInBeats, int completedLoops)
    {
        return GetNoteAtTime(GetNextNoteTime(completedLoops), completedLoops);
    }
    public IndividualNoteChart GetLastNote(float loopPositionInBeats, int completedLoops, float measureTimeInBeats)
    {
        return GetNoteAtTime(GetLastNoteTime(loopPositionInBeats, completedLoops, measureTimeInBeats), completedLoops);
    }

}

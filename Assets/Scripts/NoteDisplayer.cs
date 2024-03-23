using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _lastNoteDisplay;
    [SerializeField] private float _baseHeight;
    [SerializeField] private float _noteSpacingY;
    //private IndividualNoteChart[] surroundingNotes = { null, null };

    void Update()
    {
        /*IndividualNoteChart[] temp = RhythmController.instance.GetSurroundingNotes();
        if (surroundingNotes[0] != temp[0])
        {
            print("change in notes detected");
            surroundingNotes = RhythmController.instance.GetSurroundingNotes();
            float[] surroundingNotesTime = RhythmController.instance.GetSurroundingNotesTime();
            if (surroundingNotes[1] != temp[0])
            {
                GameObject newNoteBonus = Instantiate(_lastNoteDisplay);
                newNoteBonus.GetComponent<NoteController>().SetIndividualNote(surroundingNotes[1],
                    _noteSpacingY, _baseHeight, surroundingNotesTime[1]);
            }
            GameObject newNote = Instantiate(_lastNoteDisplay);
            newNote.GetComponent<NoteController>().SetIndividualNote(surroundingNotes[0],
                _noteSpacingY, _baseHeight, surroundingNotesTime[0]);
        }*/

        
    }
    void Start()
    {
        for (int i = 0; i < RhythmController.instance.CurrentSong.SongChart.Measures.Length; i++)
        {
            LoadNotes(i);
        }
    }

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

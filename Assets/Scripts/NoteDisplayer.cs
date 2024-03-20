using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _lastNoteDisplay;
    void Update()
    {
        IndividualNoteChart[] surroundingNotes = RhythmController.instance.GetSurroundingNotes();
        gameObject.GetComponent<SpriteRenderer>().sprite = surroundingNotes[1].Note.NoteSprite;
        _lastNoteDisplay.GetComponent<SpriteRenderer>().sprite = surroundingNotes[0].Note.NoteSprite;
    }
}

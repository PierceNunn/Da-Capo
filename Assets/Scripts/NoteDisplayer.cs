using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _lastNoteDisplay;
    void Update()
    {
        NoteTemplate[] surroundingNotes = RhythmController.instance.GetSurroundingNotes();
        gameObject.GetComponent<SpriteRenderer>().sprite = surroundingNotes[1].NoteSprite;
        _lastNoteDisplay.GetComponent<SpriteRenderer>().sprite = surroundingNotes[0].NoteSprite;
    }
}

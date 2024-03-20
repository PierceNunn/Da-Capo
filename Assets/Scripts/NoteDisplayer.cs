using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject _lastNoteDisplay;
    [SerializeField] private float _baseHeight;
    [SerializeField] private float _noteSpacingY;
    void Update()
    {
        IndividualNoteChart[] surroundingNotes = RhythmController.instance.GetSurroundingNotes();
        gameObject.GetComponent<SpriteRenderer>().sprite = surroundingNotes[1].Note.NoteSprite;
        _lastNoteDisplay.GetComponent<SpriteRenderer>().sprite = surroundingNotes[0].Note.NoteSprite;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
            _baseHeight + (surroundingNotes[1].PitchHeightModifier() * _noteSpacingY), gameObject.transform.position.z);
        _lastNoteDisplay.transform.position = new Vector3(_lastNoteDisplay.transform.position.x,
            _baseHeight + (surroundingNotes[0].PitchHeightModifier() * _noteSpacingY),
            _lastNoteDisplay.transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private IndividualNoteChart note;
    private float noteTime;
    private float _noteSpacingY;
    private float noteDestroyDistance = -25f;
    private float noteXPos;


    public void SetIndividualNote(IndividualNoteChart n, float noteSpacingY, float baseHeight, float _noteTime)
    {
        note = n;
        gameObject.GetComponent<SpriteRenderer>().sprite = note.Note.NoteSprite;
        noteTime = _noteTime + (RhythmController.instance.BeatsPerLoop * RhythmController.instance.CompletedLoops);
        _noteSpacingY = noteSpacingY;
        noteXPos = noteTime - RhythmController.instance.LoopPositionInBeats;
        gameObject.transform.position = new Vector3(noteXPos,
            baseHeight + (note.PitchHeightModifier() * _noteSpacingY), gameObject.transform.position.z);
    }

    void Update()
    {
        noteXPos = noteTime - RhythmController.instance.SongPosInBeats;
        if (noteXPos < noteDestroyDistance)
            Destroy(gameObject);
        gameObject.transform.position = new Vector3(noteXPos, gameObject.transform.position.y,
            gameObject.transform.position.z);
    }
}

/*****************************************************************************
// File Name : NoteController.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This script controls the note sprites which appear in
// the level, including their position and movement
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField] private Sprite[] _letterSprites;
    [SerializeField] private Sprite _arrowSprite;
    [SerializeField] private SpriteRenderer _letterDisplay;
    private IndividualNoteChart note;
    private float noteTime;
    private float _noteSpacingY;
    private float noteDestroyDistance = -25f;
    private float noteXPos;

    /// <summary>
    /// Sets the required values for the NoteController and sets its position.
    /// </summary>
    /// <param name="n">The IndividualNoteChart to use as reference.</param>
    /// <param name="noteSpacingY">The space between each note on the scale.</param>
    /// <param name="baseHeight">The starting height of the scale.</param>
    /// <param name="_noteTime">the time at which the note plays.</param>
    public void SetIndividualNote(IndividualNoteChart n, float noteSpacingY, float baseHeight, float _noteTime)
    {
        note = n;
        gameObject.GetComponent<SpriteRenderer>().sprite = note.Note.NoteSprite;
        noteTime = _noteTime + (RhythmController.instance.BeatsPerLoop * RhythmController.instance.CompletedLoops);
        _noteSpacingY = noteSpacingY;
        noteXPos = noteTime - RhythmController.instance.LoopPositionInBeats;
        gameObject.transform.position = new Vector3(noteXPos,
            baseHeight + (note.PitchHeightModifier() * _noteSpacingY), gameObject.transform.position.z);

        if (RhythmController.instance.CurrentDifficulty.OneButtonMode)
        {
            //hide letter display if in One Button Mode
            _letterDisplay.color = new Color(0, 0, 0, 0);
        }
        else if (RhythmController.instance.CurrentDifficulty.FourButtonMode)
        {
            //sets letter display to arrow if in Four Button Mode
            _letterDisplay.sprite = _arrowSprite;
            switch (((int)note.Pitch))
            {
                case (0):
                case (1):
                    _letterDisplay.transform.localRotation = Quaternion.Euler(0, 0, -90);
                    break;
                case (2):
                case (3):
                    _letterDisplay.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    break;
                case (6):
                    _letterDisplay.flipY = true;
                    break;
            }
        }
        else
        {
            //sets letter display to letter sprite
            _letterDisplay.sprite = _letterSprites[((int)note.Pitch)];
        }
            
    }

    /// <summary>
    /// moves the object based on its time relative to current time,
    /// and destroys it after reaching a certain distance.
    /// </summary>
    void Update()
    {
        noteXPos = (noteTime - RhythmController.instance.SongPosInBeats) 
            * RhythmController.instance.CurrentDifficulty.ScrollSpeed;
        if (noteXPos < noteDestroyDistance)
            Destroy(gameObject);
        gameObject.transform.position = new Vector3(noteXPos, gameObject.transform.position.y,
            gameObject.transform.position.z);
    }
}

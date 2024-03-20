using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDisplayer : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = RhythmController.instance.GetNextNote().NoteSprite;
    }
}

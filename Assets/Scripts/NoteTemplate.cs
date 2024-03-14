using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class NoteTemplate : ScriptableObject
{
    [SerializeField] private float _noteLength;
    [SerializeField] private bool _isRest;
    [SerializeField] private Image _noteSprite;

    public float NoteLength { get => _noteLength; set => _noteLength = value; }
    public bool IsRest { get => _isRest; set => _isRest = value; }
    public Image NoteSprite { get => _noteSprite; set => _noteSprite = value; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class NoteTemplate : ScriptableObject
{
    [SerializeField] private float _noteLength;
    [SerializeField] private bool _isRest;
    [SerializeField] private bool _isSharp;
    [SerializeField] private bool _isFlat;
    [SerializeField] private Sprite _noteSprite;

    public float NoteLength { get => _noteLength; set => _noteLength = value; }
    public bool IsRest { get => _isRest; set => _isRest = value; }
    public Sprite NoteSprite { get => _noteSprite; set => _noteSprite = value; }
    public bool IsSharp { get => _isSharp; set => _isSharp = value; }
    public bool IsFlat { get => _isFlat; set => _isFlat = value; }
}

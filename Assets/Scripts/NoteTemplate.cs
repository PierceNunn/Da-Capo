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
}

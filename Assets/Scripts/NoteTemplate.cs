/*****************************************************************************
// File Name : NoteTemplate.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This ScriptableObject script acts as the template for
// the types of notes, which can be created from the project tab and dragged
// into music charts.
*****************************************************************************/
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
    [SerializeField] private Sprite _noteSprite; //how note appears on-screen

    public float NoteLength { get => _noteLength; set => _noteLength = value; }
    public bool IsRest { get => _isRest; set => _isRest = value; }
    public Sprite NoteSprite { get => _noteSprite; set => _noteSprite = value; }
    public bool IsSharp { get => _isSharp; set => _isSharp = value; }
    public bool IsFlat { get => _isFlat; set => _isFlat = value; }
}

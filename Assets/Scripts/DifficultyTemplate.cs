/*****************************************************************************
// File Name : DifficultyTemplate.cs
// Author : Pierce Nunnelley
// Creation Date : March 14, 2024
//
// Brief Description : This is a ScriptableObject that essentially acts as a
template for different difficulties, with stats and modifiers meant to be 
applied when the difficulty is selected and change the overall difficulty
of the game.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DifficultyTemplate : ScriptableObject
{
    [SerializeField] private float timingWindow; //permittable time before or after note where button press counts
    [SerializeField] private float perfectTimingWindow; //permittable time before or after note for perfect hit

    public float PerfectTimingWindow { get => perfectTimingWindow; set => perfectTimingWindow = value; }
    public float TimingWindow { get => timingWindow; set => timingWindow = value; }
}

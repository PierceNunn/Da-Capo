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
    public enum scoreCategories
    {
        easy = 0,
        normal = 1,
        hard = 2
    }

    [SerializeField] private float _timingWindow; //permittable time before or after note where button press counts
    [SerializeField] private float _perfectTimingWindow; //permittable time before or after note for perfect hit
    [SerializeField] private bool _oneButtonMode = false; //whether or not any button can be used
    [SerializeField] private bool _fourButtonMode = false; //whether or not WASD/Arrow Keys are used
    [SerializeField] private float _scoreMultiplier = 1; // magnifies the score gained from playing a level
    [SerializeField] private uint _maxHealth = 5; //Max health player can have in a song
    [SerializeField] private float _healthRegen = 1; //Health regenerated for every hit node
    [SerializeField] private float _scrollSpeed = 1; //speed at which notes move across screen
    [SerializeField] private scoreCategories _category; //which "type" of difficulty this is

    public float PerfectTimingWindow { get => _perfectTimingWindow; set => _perfectTimingWindow = value; }
    public float TimingWindow { get => _timingWindow; set => _timingWindow = value; }
    public bool OneButtonMode { get => _oneButtonMode; set => _oneButtonMode = value; }
    public float ScoreMultiplier { get => _scoreMultiplier; set => _scoreMultiplier = value; }
    public uint MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float HealthRegen { get => _healthRegen; set => _healthRegen = value; }
    public scoreCategories Category { get => _category; set => _category = value; }
    public float ScrollSpeed { get => _scrollSpeed; set => _scrollSpeed = value; }
    public bool FourButtonMode { get => _fourButtonMode; set => _fourButtonMode = value; }
}

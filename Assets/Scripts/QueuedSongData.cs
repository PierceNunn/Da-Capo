/*****************************************************************************
// File Name : QueuedSongData.cs
// Author : Pierce Nunnelley
// Creation Date : April 13, 2024
//
// Brief Description : This ScriptableObject script acts as storage for the
next song to be played, which is accessed by RhythmController.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedSongData: ScriptableObject
{
    [SerializeField] private static MusicChartTemplate _nextSong;
    [SerializeField] private static DifficultyTemplate _nextDifficulty;
    [SerializeField] private static string _nextScene;

    public static MusicChartTemplate NextSong { get => _nextSong; set => _nextSong = value; }
    public static DifficultyTemplate NextDifficulty { get => _nextDifficulty; set => _nextDifficulty = value; }
    public static string NextScene { get => _nextScene; set => _nextScene = value; }
}

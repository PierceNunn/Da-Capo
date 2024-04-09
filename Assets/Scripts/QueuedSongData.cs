using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedSongData: ScriptableObject
{
    [SerializeField] private static MusicChartTemplate _nextSong;
    [SerializeField] private static DifficultyTemplate _nextDifficulty;

    public static MusicChartTemplate NextSong { get => _nextSong; set => _nextSong = value; }
    public static DifficultyTemplate NextDifficulty { get => _nextDifficulty; set => _nextDifficulty = value; }

}

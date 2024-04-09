/*****************************************************************************
// File Name : SceneLoader.cs
// Author : Pierce Nunnelley
// Creation Date : March 24, 2024
//
// Brief Description : This simple script allows for simple loading of any
// wanted scene by evoking an event from another object/script.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private MusicChartTemplate _nextSong;
    [SerializeField] private DifficultyTemplate _nextDifficulty;
    /// <summary>
    /// Loads a scene.
    /// </summary>
    /// <param name="sceneToLoad">The scene to load.</param>
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadSong(string sceneToLoad)
    {
        QueuedSongData.NextSong = _nextSong;
        QueuedSongData.NextDifficulty = _nextDifficulty;
        LoadScene(sceneToLoad);
    }

}

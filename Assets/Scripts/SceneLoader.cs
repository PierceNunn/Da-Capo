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
    /// <summary>
    /// Loads a scene.
    /// </summary>
    /// <param name="sceneToLoad">The scene to load.</param>
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

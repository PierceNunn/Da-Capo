/*****************************************************************************
// File Name : MiscInputHander.cs
// Author : Pierce Nunnelley
// Creation Date : May 5, 2024
//
// Brief Description : This script handles button inputs for things that can
be pressed outside of gameplay segments.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscInputHandler : MonoBehaviour
{
    /// <summary>
    /// Causes the current scene to be reloaded.
    /// </summary>
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Causes the game to close.
    /// </summary>
    public void OnQuit()
    {
        Application.Quit();
    }
}

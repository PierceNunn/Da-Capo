/*****************************************************************************
// File Name : SettingsMenuManager.cs
// Author : Pierce Nunnelley
// Creation Date : May 5, 2024
//
// Brief Description : This script manages the settings menu; primarily it
// sets and gets PlayerPrefs data based on the settings UI.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private Toggle _fourButtonToggle;
    [SerializeField] private Toggle _oneButtonToggle;

    /// <summary>
    /// Sets the status of the menu toggles to match the saved preferences.
    /// </summary>
    private void Start()
    {
        _fourButtonToggle.isOn = PlayerPrefs.GetInt("fourButtonMode", 0) == 1;
        _oneButtonToggle.isOn = PlayerPrefs.GetInt("oneButtonMode", 0) == 1;
    }

    /// <summary>
    /// Switches on/off Four Button Mode when the toggle is pressed.
    /// </summary>
    public void ToggleFourButtonMode()
    {
        print(_fourButtonToggle.isOn);
        PlayerPrefs.SetInt("fourButtonMode", _fourButtonToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Switches on/off One Button Mode when the toggle is pressed.
    /// </summary>
    public void ToggleOneButtonMode()
    {
        PlayerPrefs.SetInt("oneButtonMode", _oneButtonToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}

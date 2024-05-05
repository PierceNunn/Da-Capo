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
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private AudioSource _exampleMusic;
    [SerializeField] private AudioSource _exampleSFX;

    /// <summary>
    /// Sets the status of the menu options to match the saved preferences.
    /// </summary>
    private void Start()
    {
        _fourButtonToggle.isOn = PlayerPrefs.GetInt("fourButtonMode", 0) == 1;
        _oneButtonToggle.isOn = PlayerPrefs.GetInt("oneButtonMode", 0) == 1;
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
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

    /// <summary>
    /// Sets the value of musicVolume in PlayerPrefs to value of slider.
    /// </summary>
    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
        PlayerPrefs.Save();
        _exampleMusic.volume = _musicSlider.value;
    }

    /// <summary>
    /// Sets the value of SFXVolume in PlayerPrefs to value of slider.
    /// </summary>
    public void SetSFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", _sfxSlider.value);
        PlayerPrefs.Save();
        _exampleSFX.volume = _sfxSlider.value;
        _exampleSFX.Play();
    }
}

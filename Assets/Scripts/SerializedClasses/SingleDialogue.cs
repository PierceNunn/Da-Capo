using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[System.Serializable]
public class SingleDialogue
{
    [SerializeField] private Sprite _portraitImage;
    [SerializeField] private string _characterName;
    [SerializeField] private RandomizedAudio _characterVoice;
    [SerializeField] private bool jitterText = false;

    [TextArea(3, 10)]
    public string sentences;

    public bool JitterText { get => jitterText; set => jitterText = value; }
    public string CharacterName { get => _characterName; set => _characterName = value; }
    public Sprite PortraitImage { get => _portraitImage; set => _portraitImage = value; }
    public RandomizedAudio CharacterVoice { get => _characterVoice; set => _characterVoice = value; }
}

[System.Serializable]
public class MultiDialogue // for easy storage of repeat interacts
{
    public SingleDialogue[] dialogue;
}

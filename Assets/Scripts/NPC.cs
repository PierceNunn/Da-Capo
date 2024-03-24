/*****************************************************************************
// File Name : NPC.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This script holds dialogue to be used for the 
DialogueManager script.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private SingleDialogue[] _characterDialogue;

    public SingleDialogue[] CharacterDialogue { get => _characterDialogue; set => _characterDialogue = value; }

    /// <summary>
    /// Starts dialogue after a short delay.
    /// </summary>
    void Start()
    {
        Invoke("StartDialogue", 0.1f);
    }

    /// <summary>
    /// finds a DialogueManager and starts dialogue in it using the NPC's stored SingleDialogue array. 
    /// </summary>
    void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(_characterDialogue, this.gameObject, false);
    }

}

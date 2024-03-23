using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private SingleDialogue[] _characterDialogue;

    public SingleDialogue[] CharacterDialogue { get => _characterDialogue; set => _characterDialogue = value; }

    void Start()
    {
        Invoke("StartDialogue", 1f);
    }

    void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(_characterDialogue, this.gameObject, false);
    }

}

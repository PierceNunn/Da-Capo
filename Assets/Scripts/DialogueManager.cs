/*****************************************************************************
// File Name : DialogueManager.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This script controls the Dialogue UI and displays
dialogue.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// controls the text box and displays dialogue and profile images for conversations.
/// </summary>
public class DialogueManager : MonoBehaviour
{

    private Queue<SingleDialogue> dialogues;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Image _portrait;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _voicer;
    [SerializeField] private float _chatSpeed = 0f;
    [SerializeField] private bool _autoAdvance = false;
    [SerializeField] private GameObject _buttonSound;
    [SerializeField] private Image _buttonPrompt;
    private GameObject currentRef;
    private bool isOpen = false;
    private int convoLen = 0;

    public bool IsOpen { get => isOpen; set => isOpen = value; }

    /// <summary>
    /// sets each queue as a new empty queue.
    /// </summary>
    void Start()
    {
        dialogues = new Queue<SingleDialogue>();
    }

    /// <summary>
    /// Displays the next sentence when the assigned Interact key is pressed.
    /// </summary>
    public void OnInteract()
    {
        if(IsOpen && !_autoAdvance)
            DisplayNextSentence();
    }

    /// <summary>
    /// initializes a conversation from an outside source.
    /// </summary>
    /// <param name="dialogue">A SingleDialogue array containing information for the initialized conversation.</param>
    /// <param name="NPC">The GameObject which initiates the conversation.</param>
    /// <param name="willAutoAdvance">Determines if dialogue will advance automatically.</param>
    public void StartDialogue(SingleDialogue[] dialogue, GameObject NPC, bool willAutoAdvance)
    {
        IsOpen = true;
        _autoAdvance = willAutoAdvance;
        currentRef = NPC;
        //clear queue
        dialogues.Clear();
        //set queue to new queue
        dialogues = new Queue<SingleDialogue>();

        //set ui components to what they should be for the first dialogue
        _nameText.text = dialogue[0].CharacterName;
        _portrait.sprite = dialogue[0].PortraitImage;
        _portrait.SetNativeSize(); //just in case any portraits have different dimensions
        convoLen = dialogue.Length + 1;

        //enqueue all elements in order
        foreach (SingleDialogue line in dialogue)
        {
            dialogues.Enqueue(line);
        }

        //display the first sentence
        DisplayNextSentence();

    }

    /// <summary>
    /// Displays the next sentence in the queue.
    /// </summary>
    public void DisplayNextSentence()
    {
        convoLen--; //lower remaining length by 1
        if (convoLen == 0) //end dialogue if remaining length is 0
        {
            EndDialogue();
            return; //if ending don't run rest of the function
        }

        //dequeue element from each queue
        SingleDialogue dialogue = dialogues.Dequeue();
        string sentence = dialogue.sentences;
        string nameTag = dialogue.CharacterName;
        Sprite talkIMG = dialogue.PortraitImage;
        AudioClip[] voice = dialogue.CharacterVoice.clips;
        bool isJitter = dialogue.JitterText;
        UnityEvent[] actions = dialogue.EventsToInvoke;


        print(sentence);

        //coroutine for sentence so it can appear letter by letter
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, voice));
        //update ui elements
        _nameText.text = nameTag;
        _portrait.sprite = talkIMG;
        _portrait.SetNativeSize(); //just in case any portraits have different dimensions
        //play button sound
        _buttonSound.GetComponent<AudioSource>().Play();

        if (isJitter)
        {
            //dialogueText.gameObject.GetComponent<TextEffects>().StartJitter();
        }
        else
        {
            //dialogueText.gameObject.GetComponent<TextEffects>().StopJitter();
        }

        _buttonPrompt.enabled = false;

        foreach(UnityEvent e in actions)
        {
            e.Invoke();
        }
    }

    /// <summary>
    /// Makes a sentence in dialogue appear one letter at a time, as well as play the associated voice clip(s).
    /// </summary>
    /// <param name="sentence">The string to be displayed as a sentence.</param>
    /// <param name="voice">An array of AudioClips to be used as the voice.</param>
    /// <returns></returns>
    IEnumerator TypeSentence(string sentence, AudioClip[] voice)
    {
        _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter; //add letters of sentence individually
            //clip isn't played for specific characters or when no voice is available
            if (voice != null && letter != " "[0] && letter != ","[0] && letter != "'"[0])
            {
                int randomVChoice = Random.Range(0, voice.Length);
                _voicer.clip = voice[randomVChoice];
                _voicer.Play();
            }

            yield return new WaitForSeconds(_chatSpeed); //wait until the next letter
        }
        if (_autoAdvance) //go straight to next sentence if autoAdvance is on
        {
            DisplayNextSentence();
        }
        _buttonPrompt.enabled = true;
    }


    /// <summary>
    /// ends the dialogue mode, and sets the text box to go off-screen.
    /// </summary>
    public void EndDialogue()
    {
        StopAllCoroutines();
        if (IsOpen)
        {
            IsOpen = false;
            //animator.SetBool("isOpen", false);
            Debug.Log("End of convo");
        }



    }

}



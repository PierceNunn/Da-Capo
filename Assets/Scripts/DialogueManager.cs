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
using UnityEngine.InputSystem;
using TMPro;

/// <summary>
/// controls the text box and displays dialogue and profile images for conversations.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> nameTags;
    private Queue<Sprite> talkIMGs;
    private Queue<AudioClip[]> voices;
    private Queue<bool> jitterStatuses;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image portrait;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource voicer;
    [SerializeField] private float chatSpeed = 0f;
    [SerializeField] private bool autoAdvance = false;
    [SerializeField] private GameObject buttonSound;
    private GameObject currentRef;
    private bool isOpen = false;
    private int convoLen = 0;

    public bool IsOpen { get => isOpen; set => isOpen = value; }

    /// <summary>
    /// sets each queue as a new empty queue.
    /// </summary>
    void Start()
    {
        sentences = new Queue<string>();
        nameTags = new Queue<string>();
        talkIMGs = new Queue<Sprite>();
        voices = new Queue<AudioClip[]>();
        jitterStatuses = new Queue<bool>();
    }

    /// <summary>
    /// Displays the next sentence when the assigned Interact key is pressed.
    /// </summary>
    public void OnInteract()
    {
        if(IsOpen && !autoAdvance)
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
        autoAdvance = willAutoAdvance;
        currentRef = NPC;
        //clear all queues
        sentences.Clear();
        nameTags.Clear();
        talkIMGs.Clear();
        voices.Clear();
        jitterStatuses.Clear();
        //set all queues to new queues
        sentences = new Queue<string>();
        nameTags = new Queue<string>();
        talkIMGs = new Queue<Sprite>();
        voices = new Queue<AudioClip[]>();
        jitterStatuses = new Queue<bool>();

        //set ui components to what they should be for the first dialogue
        nameText.text = dialogue[0].CharacterName;
        portrait.sprite = dialogue[0].PortraitImage;
        portrait.SetNativeSize(); //just in case any portraits have different dimensions
        convoLen = dialogue.Length + 1;

        //enqueue all elements in order
        foreach (SingleDialogue line in dialogue)
        {
            sentences.Enqueue(line.sentences);
            nameTags.Enqueue(line.CharacterName);
            talkIMGs.Enqueue(line.PortraitImage);
            voices.Enqueue(line.CharacterVoice.clips);
            jitterStatuses.Enqueue(line.JitterText);
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
        string sentence = sentences.Dequeue();
        string nameTag = nameTags.Dequeue();
        Sprite talkIMG = talkIMGs.Dequeue();
        AudioClip[] voice = voices.Dequeue();
        bool isJitter = jitterStatuses.Dequeue();

        print(sentence);

        //coroutine for sentence so it can appear letter by letter
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, voice));
        //update ui elements
        nameText.text = nameTag;
        portrait.sprite = talkIMG;
        portrait.SetNativeSize(); //just in case any portraits have different dimensions
        //play button sound
        buttonSound.GetComponent<AudioSource>().Play();

        if (isJitter)
        {
            //dialogueText.gameObject.GetComponent<TextEffects>().StartJitter();
        }
        else
        {
            //dialogueText.gameObject.GetComponent<TextEffects>().StopJitter();
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
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter; //add letters of sentence individually
            //clip isn't played for specific characters or when no voice is available
            if (voice != null && letter != " "[0] && letter != ","[0] && letter != "'"[0])
            {
                int randomVChoice = Random.Range(0, voice.Length);
                voicer.clip = voice[randomVChoice];
                voicer.Play();
            }

            yield return new WaitForSeconds(chatSpeed); //wait until the next letter
        }
        if (autoAdvance) //go straight to next sentence if autoAdvance is on
        {
            DisplayNextSentence();
        }
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



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
    private Queue<AnimatorOverrideController> talkAnims;
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
    PlayerInput pi;

    public bool IsOpen { get => isOpen; set => isOpen = value; }

    void Start()
    {
        sentences = new Queue<string>();
        nameTags = new Queue<string>();
        talkIMGs = new Queue<Sprite>();
        talkAnims = new Queue<AnimatorOverrideController>();
        voices = new Queue<AudioClip[]>();
        jitterStatuses = new Queue<bool>();
        pi = GetComponent<PlayerInput>();
    }

    /*void Update()
    {
        if (pi.actions["Interact"].WasPressedThisFrame() && isOpen && !autoAdvance)
        {
            DisplayNextSentence();
        }
    }*/

    public void OnInteract()
    {
        if(IsOpen && !autoAdvance)
            DisplayNextSentence();
    }

    /// <summary>
    /// initializes a conversation from an outside source.
    /// </summary>
    /// <param name="dialogue">An array of SingleDialogue classes containing information for the initialized conversation.</param>
    public void StartDialogue(SingleDialogue[] dialogue, GameObject NPC, bool willAutoAdvance)
    {
        IsOpen = true;
        if (willAutoAdvance)
        {
            autoAdvance = true;
        }
        else
        {
            autoAdvance = false;
        }
        currentRef = NPC;
        //animator.SetBool("isOpen", true);
        //sentences.Clear();
        //nameTags.Clear();
        talkIMGs.Clear();
        talkAnims.Clear();
        voices.Clear();
        jitterStatuses.Clear();
        sentences = new Queue<string>();
        nameTags = new Queue<string>();
        talkIMGs = new Queue<Sprite>();
        talkAnims = new Queue<AnimatorOverrideController>();
        voices = new Queue<AudioClip[]>();
        jitterStatuses = new Queue<bool>();

        nameText.text = dialogue[0].CharacterName;
        portrait.sprite = dialogue[0].PortraitImage;
        portrait.SetNativeSize();
        convoLen = dialogue.Length + 1;

        foreach (SingleDialogue line in dialogue)
        {
            sentences.Enqueue(line.sentences);
            nameTags.Enqueue(line.CharacterName);
            talkIMGs.Enqueue(line.PortraitImage);
            voices.Enqueue(line.CharacterVoice.clips);
            jitterStatuses.Enqueue(line.JitterText);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        print("Diastartloge");
        convoLen -= 1;
        if (convoLen == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string nameTag = nameTags.Dequeue();
        Sprite talkIMG = talkIMGs.Dequeue();
        AudioClip[] voice = voices.Dequeue();
        bool isJitter = jitterStatuses.Dequeue();

        print(sentence);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, voice));
        nameText.text = nameTag;
        portrait.sprite = talkIMG;
        portrait.SetNativeSize();
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
            dialogueText.text += letter;
            if (voice != null && letter != " "[0] && letter != ","[0] && letter != "'"[0])
            {
                int randomVChoice = Random.Range(0, voice.Length);
                voicer.clip = voice[randomVChoice];
                voicer.Play();
            }

            yield return new WaitForSeconds(chatSpeed);
        }
        if (autoAdvance)
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
            GameObject player = GameObject.Find("player");
            //currentRef.GetComponent<NPC>().EndDialogueBehavior();
        }



    }

}



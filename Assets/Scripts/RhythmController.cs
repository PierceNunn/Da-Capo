using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    
    [SerializeField] private float songBPM;
    private float secsPerBeat;
    private float songPos;
    private float songPosInBeats;
    private float dspSongTime;

    public float beatsPerLoop;
    public int completedLoops = 0;
    public float loopPositionInBeats;

    //The current relative position of the song within the loop measured between 0 and 1.
    public float loopPositionInAnalog;

    //RhythmController instance
    public static RhythmController instance;

    public AudioSource musicSource;

    public float SongBPM { get => songBPM; set => songBPM = value; }
    public float SecsPerBeat { get => secsPerBeat; set => secsPerBeat = value; }
    public float SongPos { get => songPos; set => songPos = value; }
    public float SongPosInBeats { get => songPosInBeats; set => songPosInBeats = value; }
    public float DspSongTime { get => dspSongTime; set => dspSongTime = value; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secsPerBeat = 60f / songBPM;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    void Update()
    {
        if (songPosInBeats >= (completedLoops + 1) * beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = songPosInBeats - completedLoops * beatsPerLoop;

        songPos = (float)(AudioSettings.dspTime - dspSongTime);

        songPosInBeats = songPos / secsPerBeat;

        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;
    }
}

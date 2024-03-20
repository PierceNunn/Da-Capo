using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    
    [SerializeField] private float songBPM;
    [SerializeField] private float beatsPerLoop;
    [SerializeField] private int completedLoops = 0;
    [SerializeField] private float loopPositionInBeats;
    [SerializeField] private DifficultyTemplate _currentDifficulty;
    [SerializeField] private MusicChartTemplate _currentSong;

    private float secsPerBeat;
    private float songPos;
    private float songPosInBeats;
    private float measureTimeInBeats;
    private float dspSongTime;
    private int wholeBeats = 1;

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
    public DifficultyTemplate CurrentDifficulty { get => _currentDifficulty; set => _currentDifficulty = value; }
    public float LoopPositionInBeats { get => loopPositionInBeats; set => loopPositionInBeats = value; }
    public MusicChartTemplate CurrentSong { get => _currentSong; set => _currentSong = value; }
    public float MeasureTimeInBeats { get => measureTimeInBeats; set => measureTimeInBeats = value; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secsPerBeat = 60f / songBPM;
        measureTimeInBeats = beatsPerLoop * secsPerBeat;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    void Update()
    {
        if (songPosInBeats >= (completedLoops + 1) * beatsPerLoop)
        {
            completedLoops++;
            wholeBeats = -1;
            FindObjectOfType<Metronome>().MetronomeTick();
        }
        if(Mathf.Floor(LoopPositionInBeats) > wholeBeats)
        {
            wholeBeats++;
            FindObjectOfType<Metronome>().MetronomeTick();
        }
            
        LoopPositionInBeats = songPosInBeats - completedLoops * beatsPerLoop;

        songPos = (float)(AudioSettings.dspTime - dspSongTime);

        songPosInBeats = songPos / secsPerBeat;

        loopPositionInAnalog = LoopPositionInBeats / beatsPerLoop;
    }


    public IndividualNoteChart[] GetSurroundingNotes()
    {
        IndividualNoteChart next = _currentSong.GetNextNote(loopPositionInBeats, completedLoops);
        IndividualNoteChart last = _currentSong.GetLastNote(loopPositionInBeats, completedLoops, measureTimeInBeats);
        IndividualNoteChart[] output = { last, next };
        return output;
    }
}

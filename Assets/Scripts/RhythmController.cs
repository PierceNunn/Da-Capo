/*****************************************************************************
// File Name : RhythmController.cs
// Author : Pierce Nunnelley
// Creation Date : March 23, 2024
//
// Brief Description : This script primarily manages the moment-to-moment 
// rhythm, extensively tracking time and position throughout the playing track
// in several different ways for outside reference.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private float beatsPerLoop;
    [SerializeField] private DifficultyTemplate _currentDifficulty;
    [SerializeField] private MusicChartTemplate _currentSong;
    [SerializeField] private NoteDisplayer _noteDisplayer;
    [SerializeField] private string _sceneToLoad;

    private float songBPM;
    private int completedLoops = 0;
    private float loopPositionInBeats;
    private float secsPerBeat;
    private float songPos;
    private float songPosInBeats;
    private float measureTimeInBeats;
    private double dspSongTime;
    private int wholeBeats = 1;
    private bool songBegun = false;

    //The current relative position of the song within the loop measured between 0 and 1.
    public float loopPositionInAnalog;

    //RhythmController instance
    public static RhythmController instance;

    public AudioSource musicSource;

    public float SongBPM { get => songBPM; set => songBPM = value; }
    public float SecsPerBeat { get => secsPerBeat; set => secsPerBeat = value; }
    public float SongPos { get => songPos; set => songPos = value; }
    public float SongPosInBeats { get => songPosInBeats; set => songPosInBeats = value; }
    public double DspSongTime { get => dspSongTime; set => dspSongTime = value; }
    public DifficultyTemplate CurrentDifficulty { get => _currentDifficulty; set => _currentDifficulty = value; }
    public float LoopPositionInBeats { get => loopPositionInBeats; set => loopPositionInBeats = value; }
    public MusicChartTemplate CurrentSong { get => _currentSong; set => _currentSong = value; }
    public float MeasureTimeInBeats { get => measureTimeInBeats; set => measureTimeInBeats = value; }
    public float BeatsPerLoop { get => beatsPerLoop; set => beatsPerLoop = value; }
    public int CompletedLoops { get => completedLoops; set => completedLoops = value; }

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Set various values based on other information and begins the song.
    /// </summary>
    void Start()
    {
        Invoke("BeginSong", 1f);
    }

    void BeginSong()
    {
        songBPM = _currentSong.BPM;
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = _currentSong.Song;
        secsPerBeat = 60f / songBPM;
        measureTimeInBeats = BeatsPerLoop * secsPerBeat;
        dspSongTime = AudioSettings.dspTime + 0.5;
        musicSource.PlayScheduled(dspSongTime);
        _noteDisplayer.InstantiateNotes();
        songBegun = true;
    }

    /// <summary>
    /// Updates a variety of variables which need constant updating.
    /// </summary>
    void Update()
    {
        if (songBegun)
        {

            if (songPosInBeats >= (CompletedLoops + 1) * BeatsPerLoop)
            {
                CompletedLoops++;
                wholeBeats = -1;
                FindObjectOfType<Metronome>().MetronomeTick(secsPerBeat * beatsPerLoop);

                if (completedLoops >= _currentSong.SongChart.Measures.Length)
                {
                    EndSongBehavior();
                }
            }
            if (Mathf.Floor(LoopPositionInBeats) > wholeBeats)
            {
                wholeBeats++;
                FindObjectOfType<Metronome>().MetronomeTick(secsPerBeat * beatsPerLoop);
            }

            LoopPositionInBeats = songPosInBeats - CompletedLoops * BeatsPerLoop;

            songPos = (float)(AudioSettings.dspTime - dspSongTime);

            songPosInBeats = songPos / secsPerBeat;

            loopPositionInAnalog = LoopPositionInBeats / BeatsPerLoop;
        }
    }

    /// <summary>
    /// Gets the notes immediately before and immediately after the current time, ignoring rests.
    /// </summary>
    /// <returns>An array holding the previous and next notes.</returns>
    public IndividualNoteChart[] GetSurroundingNotes()
    {
        IndividualNoteChart next = _currentSong.GetNextNote(loopPositionInBeats, CompletedLoops);
        IndividualNoteChart last = _currentSong.GetLastNote(loopPositionInBeats, CompletedLoops, measureTimeInBeats);
        IndividualNoteChart[] output = { last, next };
        return output;
    }

    /// <summary>
    /// Gets the time of notes immediately before and immediately after the current time, ignoring rests.
    /// </summary>
    /// <returns>An array holding the previous and next notes' times.</returns>
    public float[] GetSurroundingNotesTime()
    {
        float next = _currentSong.GetNextNoteTime(CompletedLoops);
        float last = _currentSong.GetLastNoteTime(loopPositionInBeats, CompletedLoops, measureTimeInBeats);
        float[] output = { last, next };
        return output;
    }

    void EndSongBehavior()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}

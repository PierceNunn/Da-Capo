using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void OnNoteA()
    {
        print(IsButtonTimed());
    }

    public bool IsButtonTimed()
    {
        float targetTime = Mathf.Round(RhythmController.instance.LoopPositionInBeats);
        float actualTime = RhythmController.instance.LoopPositionInBeats;
        if (actualTime <= RhythmController.instance.CurrentDifficulty.TimingWindow + targetTime &&
            actualTime >= RhythmController.instance.CurrentDifficulty.TimingWindow - targetTime)
        {
            return true;
        }
        return false;
    }
}

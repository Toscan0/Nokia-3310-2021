using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreCalculator : MonoBehaviour
{

    public float CalculateHighScore(float timer)
    {
        return (GetMinutes(timer) * 100000)
        + (GetSecondsToDisplay(timer) * 1000)
        + (GetMilliseconds(timer) * 1);
    }

    public float CalculateHighScore(string timerAsString)
    {
        float timerAsfloat = ParseTimerAsString(timerAsString);

        return CalculateHighScore(timerAsfloat); 
    }

    private float ParseTimerAsString(string timer)
    {
        string[] timePlayed = timer.Split(':');

        string minutes = timePlayed[0];
        string seconds = timePlayed[1];
        string milliseconds = timePlayed[2];

        return 3;
    }

    ////
    private float GetMinutes(float seconds)
    {
        return ((int)seconds / 60);
    }

    private float GetSecondsToDisplay(float seconds)
    {
        return (seconds % 60);
    }

    private float GetMilliseconds(float seconds)
    {
        return ((seconds * 1000) % 1000);
    }
}

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
        float timerAsfloat = StringTimerToFloat(timerAsString);

        return CalculateHighScore(timerAsfloat); 
    }

    private float StringTimerToFloat(string timer)
    {
        string[] timePlayed = timer.Split(':');

        int minutes = int.Parse(timePlayed[0]);
        int seconds = int.Parse(timePlayed[1]);
        int milliseconds = int.Parse(timePlayed[2]);

        return (minutes * 60) + seconds + (milliseconds * 0.001f);
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

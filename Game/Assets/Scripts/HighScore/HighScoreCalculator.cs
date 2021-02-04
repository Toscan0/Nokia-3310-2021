using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreCalculator : MonoBehaviour
{
    /*void Start()
    {
        Debug.Log("teste1: " + CalculateHighScore(0.00000f));
        Debug.Log("teste2: " + CalculateHighScore(1.00000f));
        Debug.Log("teste3: " + CalculateHighScore(1.11111f));
        Debug.Log("teste4: " + CalculateHighScore(1.99999f));
        Debug.Log("teste5: " + CalculateHighScore(9.11111f));
        Debug.Log("teste6: " + CalculateHighScore(9.99999f));
    }*/

    public float CalculateHighScore(float timer)
    {
        return (GetMinutes(timer) * 100000)
        + (GetSecondsToDisplay(timer) * 1000)
        + (GetMilliseconds(timer) * 1);
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

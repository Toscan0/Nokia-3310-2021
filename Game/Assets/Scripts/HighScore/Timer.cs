using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    private float startTime;
    private static float currentTime = 0;

    void Start()
    {
        startTime = Time.time;
        SetTimerText();
    }

    void Update()
    {
        currentTime = Time.time - startTime;

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = GetMinutes(currentTime)
        + ":" + GetSecondsToDisplay(currentTime) + ":"
        + GetMilliseconds(currentTime);
    }

    private string GetMinutes(float seconds)
    {
        return ((int)seconds / 60).ToString();
    }

    private string GetSecondsToDisplay(float seconds)
    {
        return (seconds % 60).ToString("f0");
    }

    private string GetMilliseconds(float seconds)
    {
        return ((seconds * 1000) % 1000).ToString("f0");
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private bool isLastLevel;

    private float startTime = 0;
    private static float currentTime = 0;
    private bool stopTimer = false;

    private void Awake()
    {
        PlayerCollisionManager.OnFlyPickedUp += CheckIsLastLevel;
    }

    void Start()
    {
        startTime = -currentTime + Time.time;
        SetTimerText();
    }

    private void CheckIsLastLevel()
    {
        if (isLastLevel)
        {
            stopTimer = true;
        }
    }

    void Update()
    {
        if (!stopTimer)
        {
            currentTime = Time.time - startTime;
            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        timerText.text = GetMinutes(currentTime)
        + ":" + GetSecondsToDisplay(currentTime) + ":"
        + GetMilliseconds(currentTime);
    }


    private void OnDestroy()
    {
        PlayerCollisionManager.OnFlyPickedUp -= CheckIsLastLevel;
    }



    ////
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

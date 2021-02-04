using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private bool isLastLevel;

    private float startTime = 0;
    private bool stopTimer = false;

    public static float CurrentTime { get; private set; } = 0;

    private void Awake()
    {
        PlayerCollisionManager.OnFlyPickedUp += CheckIsLastLevel;
    }

    void Start()
    {
        startTime = -CurrentTime + Time.time;
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
            CurrentTime = Time.time - startTime;
            SetTimerText();
        }
    }

    private void SetTimerText()
    {
        if(timerText != null)
        {
            timerText.text = GetTimerAsString(CurrentTime);
        }
    }


    private void OnDestroy()
    {
        PlayerCollisionManager.OnFlyPickedUp -= CheckIsLastLevel;
    }



    ////
    private string GetTimerAsString(float timer)
    {
        return GetMinutes(timer)
        + ":" + GetSecondsToDisplay(timer) + ":"
        + GetMilliseconds(timer);
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

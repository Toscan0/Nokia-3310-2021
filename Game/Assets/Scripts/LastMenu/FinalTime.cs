using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FinalTime : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Start()
    {
        text.text = "Your Time: " + GetTimerAsString(TimerManager.CurrentTime);
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

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScoreText : MonoBehaviour
{
    private string scores = "" +
        "1) 1234567 10:10:30min\n" +
        "2) 1234567 10:10:30min\n" +
        "3) 1234567 10:10:30min\n" +
        "4) 1234567 10:10:30min\n" +
        "5) 1234567 10:10:30min\n" +
        "6) 1234567 10:10:30min\n" +
        "7) 1234567 10:10:30min\n" +
        "8) 1234567 10:10:30min\n" +
        "9) 1234567 10:10:30min\n" +
        "10) 1234567 10:10:30min";

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        text.text = scores;
    }
}


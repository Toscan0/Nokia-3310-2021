using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScoreText : MonoBehaviour
{
    private string scores = "" +
        "1) qwertyuiop 10:10s\n" +
        "2) qwertyuio 10:10s\n" +
        "3) qwertyui 10:10s\n" +
        "4) blablab 10:10s\n" +
        "5) blablab 10:10s\n" +
        "6) blablab 10:10s\n" +
        "7) blablab 10:10s\n" +
        "8) blablab 10:10s\n" +
        "9) blablab 10:10s\n" +
        "10) blablab 10:10s";

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


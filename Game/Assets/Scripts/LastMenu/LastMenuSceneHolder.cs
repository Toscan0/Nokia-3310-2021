using System;
using UnityEngine;

public class LastMenuSceneHolder : MonoBehaviour
{
    [SerializeField]
    private HighScoreCalculator highScoreCalculator;
    [SerializeField]
    private GetFromServer dataFromServer;

    private string highscore;

    private void Awake()
    {
        GetFromServer.OnDataReceived += UpdateHighScore;
    }

    private void Start()
    {
        StartCoroutine(dataFromServer.GetHighScore());
    }

    private void UpdateHighScore(string newScore)
    {
        highscore = newScore;

        // Check if player score is better;
        float playerTimer = TimerManager.CurrentTime;
        Debug.Log("playerTimer " + playerTimer);
        float playerHighScore = highScoreCalculator.CalculateHighScore(playerTimer);
        Debug.Log("score " + playerHighScore);

        

    }

    private void OnDestroy()
    {
        GetFromServer.OnDataReceived -= UpdateHighScore;
    }
}

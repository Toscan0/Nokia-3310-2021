using System;
using System.Collections.Generic;
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

    private void UpdateHighScore(List<List<string>> newScore)
    {
        //highscore = newScore;

        // Calculate player highscore
        float playerTimer = TimerManager.CurrentTime;
        Debug.Log("playerTimer " + playerTimer);
        float playerHighScore = highScoreCalculator.CalculateHighScore(playerTimer);
        //Debug.Log("score " + playerHighScore);

        // Calculate players highscore
        int otherPlayerHighscore;
        for (int i = 0; i < newScore.Count; i++)
        {
           // otherPlayerHighscore = newScore[i][1]
        }


    }

    private void OnDestroy()
    {
        GetFromServer.OnDataReceived -= UpdateHighScore;
    }
}

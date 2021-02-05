using System;
using System.Collections.Generic;
using UnityEngine;

public class LastMenuSceneHolder : MonoBehaviour
{
    public static Action<List<List<string>>> OnScoreChanged;

    [SerializeField]
    private HighScoreCalculator highScoreCalculator;
    [SerializeField]
    private GetFromServer dataFromServer;

    private void Awake()
    {
        GetFromServer.OnDataReceived += UpdateHighScore;
    }

    private void Start()
    {
        StartCoroutine(dataFromServer.GetHighScore());
    }

    private void UpdateHighScore(List<List<string>> serverScore)
    {
        string nameAux = "";
        List<List<string>> newScore = new List<List<string>>();

        newScore.AddRange(serverScore);

        //newScore = serverScore;

        string playerName = UserRandomName.UserName;
        float playerTimer = 10.20f; // TimerManager.CurrentTime;
        float playerHighScore = highScoreCalculator.CalculateHighScore(playerTimer);

        // Check 10 bigger scores
        string nameToCompare = playerName;
        float timerToCompare = playerTimer;
        float scoreToCompare = playerHighScore;

        for (int i = 0; i < serverScore.Count; i++)
        {
            string otherPlayerName = serverScore[i][0];
            string otherPlayerTimer = serverScore[i][1];

            if (otherPlayerTimer != null && otherPlayerTimer.Trim() != "")
            {
                // Calculate the other player highscore
                float otherPlayerHighscore = 
                    highScoreCalculator.CalculateHighScore(otherPlayerTimer);

                // TODO: is player score bigger ?
                if(scoreToCompare < otherPlayerHighscore)
                {
                    newScore[i][0] = nameToCompare;
                    newScore[i][1] = GetTimerAsString(timerToCompare);

                    nameAux = serverScore[i][0];
                    scoreToCompare = otherPlayerHighscore;

                    

                    //Debug.Log(newScore);
                }
            }
        }

        // TODO: post on server
        // TODO: Update High score, Maybe anim when player improve highscore
    }

    private void OnDestroy()
    {
        GetFromServer.OnDataReceived -= UpdateHighScore;
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

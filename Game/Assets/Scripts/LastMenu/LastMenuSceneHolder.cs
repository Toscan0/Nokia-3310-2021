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
    [SerializeField]
    private PostOnServer postOnServer;

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
        List<List<string>> newScore = new List<List<string>>();
        newScore = CopyListToAnotherList(serverScore);
        
        string playerName = UserRandomName.UserName;
        float playerTimer = TimerManager.CurrentTime;
        float playerHighScore = highScoreCalculator.CalculateHighScore(playerTimer);

        // Check 10 bigger scores
        string nameToCompare = playerName;
        string timerToCompare = GetTimerAsString(playerTimer);
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

                // because from start null players have score 0
                if (otherPlayerHighscore == 0)
                {
                    otherPlayerHighscore = 999999999999;
                }

                // Check if score is bigger
                if(scoreToCompare < otherPlayerHighscore )
                {
                    // update score
                    newScore[i][0] = nameToCompare;
                    newScore[i][1] = timerToCompare;

                    // update comparation
                    scoreToCompare = otherPlayerHighscore;
                    nameToCompare = otherPlayerName;
                    timerToCompare = otherPlayerTimer;

                   
                }
            }
        }

        // TODO: post on server
        // TODO: Update High score, Maybe anim when player improve highscore



        /*foreach (var i in newScore)
        {
            foreach (var e in i)
            {
                Debug.Log(e);
            }
            OnScoreChanged?.Invoke(newScore);
        }
        */

        StartCoroutine(postOnServer.PostHighScore(newScore));
    }

    private void OnDestroy()
    {
        GetFromServer.OnDataReceived -= UpdateHighScore;
    }





    private List<List<string>> CopyListToAnotherList(List<List<string>> toCopy)
    {
        List<List<string>> lst = new List<List<string>>();

        foreach (var innerLst in toCopy)
        {
            List<string> aux = new List<string>();

            foreach (var e in innerLst) {
                aux.Add(e);                
            }
            lst.Add(aux);
        }

        return lst;
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

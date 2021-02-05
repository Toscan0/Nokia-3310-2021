﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScoreText : MonoBehaviour
{
    private string scores = "Retrieving data from the server..";

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();

        GetFromServer.OnDataReceived += UpdateHighScore;
    }

    private void Start()
    {
        UpdateHighScore(scores);
    }

    private void UpdateHighScore(List<List<string>> newScore)
    {
        string score = "";

        for(int i = 0; i < newScore.Count; i++)
        {
            Debug.Log("newScore[i][0]" + newScore[i][0]);
            Debug.Log("newScore[i][1]" + newScore[i][1]);

            score += (i + 1) + ") " + newScore[i][0] + 
                " " + newScore[i][1] + "min\n";
        }

        text.text = score;
    }

    private void UpdateHighScore(string newScore)
    {
        text.text = newScore;
    }

    private void OnDestroy()
    {
        GetFromServer.OnDataReceived -= UpdateHighScore;
    }
}


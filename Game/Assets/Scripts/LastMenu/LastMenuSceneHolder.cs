using System;
using UnityEngine;

public class LastMenuSceneHolder : MonoBehaviour
{
    [SerializeField]
    private GetFromServer getDataFromServer;

    private string highscore;

    private void Awake()
    {
        GetFromServer.OnDataReceived += UpdateHighScore;
    }

    private void Start()
    {
        StartCoroutine(getDataFromServer.GetHighScore());
    }

    private void UpdateHighScore(string obj)
    {
        highscore = newScore;
    }

    private void OnDestroy()
    {
        GetFromServer.OnDataReceived -= UpdateHighScore;
    }
}

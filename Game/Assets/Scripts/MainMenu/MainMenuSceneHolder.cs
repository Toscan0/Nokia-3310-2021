using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneHolder : MonoBehaviour
{
    [SerializeField]
    private LoadSceneManager loadSceneManager;

    [SerializeField]
    private GetFromServer getDataFromServer;

    private void Start()
    {
        StartCoroutine(getDataFromServer.GetHighScore());

        Invoke("PlayGame", 5f);
    }

    private void PlayGame()
    {
        loadSceneManager.LoadNextScene();
    }
}

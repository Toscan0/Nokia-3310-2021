using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel1 : MonoBehaviour
{
    [SerializeField]
    private LoadSceneManager loadSceneManager;

    [SerializeField]
    private GetFromServer getDataFromServer;

    private void Start()
    {
        StartCoroutine(getDataFromServer.GetHighScore());

        Invoke("PlayGame", 60f);
    }

    private void PlayGame()
    {
        loadSceneManager.LoadNextScene();
    }
}

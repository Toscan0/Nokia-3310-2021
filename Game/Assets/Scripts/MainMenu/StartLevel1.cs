using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel1 : MonoBehaviour
{
    [SerializeField]
    private LoadSceneManager loadSceneManager;

    private void Start()
    {
        Invoke("PlayGame", 1f);
    }

    private void PlayGame()
    {
        loadSceneManager.LoadNextScene();
    }
}

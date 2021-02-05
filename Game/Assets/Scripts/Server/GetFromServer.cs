using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetFromServer : MonoBehaviour
{
    public static Action<List<List<string>>> OnDataReceived;

    private const string GET_HIGHSCORE_URL = "" +
        "http://web.tecnico.ulisboa.pt/~ist181633/CatchTheFly/ServerSide/Get_HighScore.php";

    public IEnumerator GetHighScore()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(GET_HIGHSCORE_URL))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.LogError("UnityWebRequest get error:" + webRequest.error);
            }
            else
            {
                OnDataReceived?.Invoke(ParseServerData(webRequest.downloadHandler.text));
            }
        }
    }
    
    private List<List<string>> ParseServerData(string data)
    {
        List<List<string>> playersHighscores = new List<List<string>>();

        data = data.Trim();

        // each player data from the server
        string[] playersData = data.Split('.');

        string[] array_aux;
        for(int i = 0; i < playersData.Length; i++)
        {
            array_aux = playersData[i].Split(';');

            if (array_aux != null && array_aux.Length == 2)
            {
                array_aux[0] = array_aux[0].Trim();
                array_aux[0] = array_aux[1].Trim();
                List<string> lst_aux = new List<string>(array_aux);
                playersHighscores.Add(lst_aux);
            }
        }

        return playersHighscores;
    }
}
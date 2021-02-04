using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetFromServer : MonoBehaviour
{
    public static Action<string> OnDataReceived;

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
    
    private string ParseServerData(string data)
    {
        Debug.Log("data received " + data);

        return data;
    }
}
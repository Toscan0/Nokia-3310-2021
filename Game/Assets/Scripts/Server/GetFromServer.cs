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
        Debug.Log("1111111111");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(GET_HIGHSCORE_URL))
        {
            Debug.Log("222222222");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            Debug.Log("333333333333");
            if (webRequest.isNetworkError)
            {
                Debug.LogError("UnityWebRequest get error:" + webRequest.error);
            }
            else
            {
                Debug.Log("44444444444");
                OnDataReceived?.Invoke(ParseServerData(webRequest.downloadHandler.text));
                Debug.Log("55555555");
            }
        }
    }
    
    private string ParseServerData(string data)
    {
        Debug.Log("data received " + data);

        return data;
    }
}
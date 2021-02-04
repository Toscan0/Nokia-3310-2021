using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetFromServer : MonoBehaviour
{
    private const string GET_HIGHSCORE_URL = "" +
        "http://web.tecnico.ulisboa.pt/~ist181633/MemoryGame/Server/Get_HighScore.php";

    public string ServerData { get; private set; }

    public IEnumerator GetHighScore()
    {
        string url = GET_HIGHSCORE_URL;

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
                ServerData = ParseServerData(webRequest.downloadHandler.text);
            }
        }
    }
    
    private string ParseServerData(string data)
    {
        Debug.Log(data);

        return data;
    }
}
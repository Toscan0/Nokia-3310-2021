using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostOnServer : MonoBehaviour
{
    private const string POST_HIGHSCORE_URL = "" +
        "http://web.tecnico.ulisboa.pt/~ist181633/CatchTheFly/ServerSide/Post_HighScore.php";

    public IEnumerator PostHighScore(string playerName, float time)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();

        string highScoreToSend = ParseDataToSend(playerName, time);

        wwwForm.Add(new MultipartFormDataSection("_content", highScoreToSend));

        UnityWebRequest www = UnityWebRequest.Post(POST_HIGHSCORE_URL, wwwForm);

        //w8 for answer
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("UnityWebRequest post error: " + www.error);
        }
    }

    private string ParseDataToSend(string playerName, float time)
    {
        Debug.Log(playerName + " " + time);

        return null;
    }
}
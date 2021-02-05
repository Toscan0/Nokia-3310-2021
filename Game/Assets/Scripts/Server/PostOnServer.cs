using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostOnServer : MonoBehaviour
{
    private const string POST_HIGHSCORE_URL = "" +
        "https://web.tecnico.ulisboa.pt/~ist181633/CatchTheFly/ServerSide/Post_HighScore.php";

    public IEnumerator PostHighScore(List<List<string>> toSend)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("_content",
            ParseDataToSend(toSend)));

        UnityWebRequest www = UnityWebRequest.Post(POST_HIGHSCORE_URL, wwwForm);

        //w8 for answer
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("UnityWebRequest post error: " + www.error);
        }
    }

    private string ParseDataToSend(List<List<string>> lst)
    {
        string toSend = "";

        for (int i = 0; i < lst.Count; i++)
        {
            // i) <PlayerName> <Time>min
            toSend += lst[i][0] + ";"
                + lst[i][1] + ".\n";
        }

        return toSend;
    }

}
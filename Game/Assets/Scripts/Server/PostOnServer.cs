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
        Debug.Log("111111");
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        Debug.Log("222222222");
        string highScoreToSend = "BLABLA";
        Debug.Log("33333333333");
        wwwForm.Add(new MultipartFormDataSection("_content", highScoreToSend));
        Debug.Log("444444444");

        UnityWebRequest www = UnityWebRequest.Post(POST_HIGHSCORE_URL, wwwForm);
        Debug.Log("5555555555");

        //w8 for answer
        yield return www.SendWebRequest();
        Debug.Log("6666666666");

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("UnityWebRequest post error: " + www.error);
        }
    }

    private string LstLStStringToString(List<List<string>> lst)
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
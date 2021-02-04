using UnityEngine;
using UnityEngine.UI;

public class UserRandomName : MonoBehaviour
{
    public static string UserName { get; private set; } = "";

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    void Start()
    {
        if (UserName == "" || UserName == null)
        {
            UserName = GenerateRandomName();
        }

        text.text = "User ID: " + UserName;
    }

    private string GenerateRandomName()
    {
        int k = 4;
        string baseName = "usr";

        for(int i = 0; i < k; i++)
        {
            baseName += Random.Range(0, 9);
        }

        return baseName;
    }
}

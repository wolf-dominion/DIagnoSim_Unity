using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PostRequest("my url here"));
    }

    IEnumerator PostRequest(string url)
    {
        string userId = "test";
        string token = "123";
        string body = "";

        WWWForm form = new WWWForm();
        form.AddField("body", body);

        var webRequest = UnityWebRequest.Post(url, form);
        webRequest.SetRequestHeader("content-type", "application/json");
        webRequest.SetRequestHeader("authorization", $"Bearer {token}");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log("Error While Sending: " + webRequest.error);
        }
        else
        {
            Debug.Log("Received: " + webRequest.downloadHandler.text);
        }

    }
}

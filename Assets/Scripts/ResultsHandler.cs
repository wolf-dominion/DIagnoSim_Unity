using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class ResultsHandler : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject dialoguePanel;
    public GameObject returnButton;
    public static ResultsHandler instance;
    // Declare all the results variables here
    int empathyScore = 0;
    int communicationScore = 0;
    int sharedDecisionScore = 0;

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Declare functions for updating variables that the multiple choice objects will access
    public void SetEmpathy(int score){
        empathyScore = score;
    }

    public void SetCommunication(int score){
        communicationScore = score;
    }

    public void SetSharedDecision(int score){
        sharedDecisionScore = score;
    }

    // Do backend stuff here, call this from outside this script using
    // ResultsHanlder.instance.SendData()

    public void SendData(){
        dialoguePanel.SetActive(false);
        returnButton.SetActive(true);
        TextBox.GetComponent<TMP_Text>().text ="You have completed the simulation. Please check your profile to see the results.";
        StartCoroutine(PostRequest("http://localhost:3000/results"));
    }

    IEnumerator PostRequest(string url)
    {
        string token = CredentialManager.instance.token;
        string body = "{\"result\":{\"empathy\":" + empathyScore + ",\"communication\":" + communicationScore + ",\"sharedecision\":" + sharedDecisionScore + "}}";

        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(body);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("content-type", "application/json");
        request.SetRequestHeader("authorization", $"Bearer {token}");

        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);
    }
}

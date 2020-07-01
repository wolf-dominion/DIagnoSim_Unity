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
        //result = {
        //    empathy: empathyScore,
        //    communication: communicationScore,
        //    sharedecision: sharedDecisionScore
        //}
        
        string token = CredentialManager.instance.token;
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

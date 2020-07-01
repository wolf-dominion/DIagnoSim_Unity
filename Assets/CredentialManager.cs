using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredentialManager : MonoBehaviour
{
    public string token;
    public static CredentialManager instance;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    public void SetToken(string t){
        token = t;
        Debug.Log($"Unity received token: {t}");
    }
}

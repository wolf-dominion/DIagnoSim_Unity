using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUser : MonoBehaviour
{

    private int user = 5;

    public Text userText;

    void Update()
    {
        userText.text = "User: " + user;

        if(Input.GetKeyDown(KeyCode.Space)){
            user++;
        }
    }
}

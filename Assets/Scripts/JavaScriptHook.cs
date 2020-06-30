using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JavaScriptHook : MonoBehaviour
{
    [SerializeField] private SpriteRenderer circleSpriteRenderer;
    [SerializeField] private Image circleImage;

    public void TintRed() {
        // circleSpriteRenderer.color 
        circleImage.color = Color.red;
    }

    public void TintGreen(){
        // circleSpriteRenderer.color = Color.green;
        circleImage.color = Color.green;
    }

    public void Update(){
        if (Input.GetKeyDown(KeyCode.T)){
            TintRed();
        }
        if (Input.GetKeyDown(KeyCode.Y)){
            TintGreen();
        }
    }
}

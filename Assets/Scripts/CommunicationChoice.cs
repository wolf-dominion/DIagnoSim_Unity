using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommunicationChoice : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject holder;

    public int ChoiceMade;

    public void ToggleChoice(bool toggleValue){
        holder.SetActive(toggleValue);
    }

    public bool IsActive(){
        return holder.activeSelf;
    }

    public void ChoiceOption1 () {
        TextBox.GetComponent<TMP_Text>().text ="You have selected Option 1";
        ChoiceMade = 1;
        ResultsHandler.instance.SetEmpathy(0);
    }
    public void ChoiceOption2 () {
        TextBox.GetComponent<TMP_Text>().text ="You have selected Option 2";
        ChoiceMade = 2;
        ResultsHandler.instance.SetEmpathy(1);
    }
    public void ChoiceOption3 () {
        TextBox.GetComponent<TMP_Text>().text ="You have selected Option 3";
        ChoiceMade = 3;
        ResultsHandler.instance.SetEmpathy(2);
    }
    public void ChoiceOption4 () {
        TextBox.GetComponent<TMP_Text>().text ="You have selected Option 4";
        ChoiceMade = 4;
        ResultsHandler.instance.SetEmpathy(3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public EmpathyChoiceScript empathy;
    public SharedChoice shared;
    public CommunicationChoice communication;

    private void Start() {
        empathy.ToggleChoice(true);
        shared.ToggleChoice(false);
        communication.ToggleChoice(false);
    }

    public void Next(){
        if (empathy.IsActive()){
            empathy.ToggleChoice(false);
            shared.ToggleChoice(true);
            return;
        }

        if (shared.IsActive()){
            shared.ToggleChoice(false);
            communication.ToggleChoice(true);
            return;
        }

        if (communication.IsActive()){
            communication.ToggleChoice(false);
            ResultsHandler.instance.SendData();
            return;
        }
    }

}

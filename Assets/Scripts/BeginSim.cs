using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSim : MonoBehaviour
{
    public void StartSim() {
        Debug.Log("Begin sim button clicked");
        Loader.Load(Loader.Scene.Structure_02);
    }
}

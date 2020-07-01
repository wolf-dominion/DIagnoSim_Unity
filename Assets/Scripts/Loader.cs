using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{

    public enum Scene {
        Structure_02,
        LoadingScreen,
        MainMenu
    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene) {
        // set the loader callback action to load the target scene
        onLoaderCallback = () => {
            SceneManager.LoadScene(scene.ToString());
        };
        // load the loading scene
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static void LoaderCallback() {
        // triggered after the first update which lets the screen refresh
        //execute the loader callback afction which will load the target scene 
        if (onLoaderCallback != null) {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class GamePause : MonoBehaviour {
    
    public static bool GameIsPaused = false;
    
    public SteamVR_Action_Boolean interaction_input;
    public storyProgressController progressController;
    public introPlay introPlay;

    private void Start() {
        Pause();
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("b"))
        {
            Debug.Log("resume");
            Resume();
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (!interaction_input.stateDown) return;
        if (GameIsPaused) {
            Resume();
        }
    }

    void Resume() {
        Time.timeScale = 1f;
        GameIsPaused = false;
        progressController.ProgressStory();
        introPlay.canStart = true;
    }

    void Pause() {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}

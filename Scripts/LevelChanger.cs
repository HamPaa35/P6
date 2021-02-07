using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour {

    public static LevelChanger instance;


    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void ChangeToLevel(string levelName) {
        SceneManager.LoadScene(levelName);
        SceneManager.sceneLoaded += PrepareScene;
    }

    private void PrepareScene(Scene scene, LoadSceneMode mode) {
        Transform playerTransform = GameObject.Find("Player").transform;
        playerTransform.position = Vector3.zero;

        Transform endTextTransform = GameObject.Find("EndText").transform;
        endTextTransform.position = playerTransform.forward * 10;
        endTextTransform.LookAt(playerTransform);
        
        endTextTransform.Rotate(0, 180, 0);
    }
    
}

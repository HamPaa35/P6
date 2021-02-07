using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HymerAnimationManager : MonoBehaviour
{
    private Animator animation;

    public static HymerAnimationManager instance;


    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playPointing()
    {
        animation.Play("Pointing_Animation", 0, 0f);
    }

    public void playPointing(int delay)
    {
        Invoke("playPointing", delay);
    }

    public void playSitting()
    {
        animation.Play("Sitting_Idle", 0, 0f);
    }
    
    public void playWalking()
    {
        animation.Play("Walking", 0, 0f);
    }
    
    public void playBow()
    {
        animation.Play("Bow", 0, 0f);
    }
    
    public void playHeil()
    {
        animation.Play("Heil", 0, 0f);
    }
    
    public void playWave()
    {
        animation.Play("Wave", 0, 0f);
    }
    public void playCut()
    {
        animation.Play("Cut_Rope", 0, 0f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeTransition : MonoBehaviour {

    private static FadeTransition _instance;

    public static FadeTransition Instance {
        get { return _instance; }
    }

    public Animator animator;
    [HideInInspector]
    public enum State {black, transparent}
    public State screen_state = State.transparent;
    public float delayBetweenFades = 1f;
    public Canvas canvas;
    public Camera vrCamera;
    private bool endState;
    
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        if (canvas == null) {
            canvas = GetComponentInChildren<Canvas>();
            vrCamera = GameObject.Find("VRCamera").GetComponent<Camera>();
            canvas.worldCamera = vrCamera;
            canvas.planeDistance = 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.K) & screen_state == State.transparent) {
            FadeOut();
        } else if (Input.GetKeyDown(KeyCode.K) & screen_state == State.black) {
            FadeIn();
        }*/

        /*if (Input.GetKeyDown(KeyCode.Z)) {
            FadeOutGameOutro();
        }*/
    }

    public void FadeOut() {
        animator.SetTrigger("FadeOut");
    }

    IEnumerator FadeIn() {
        yield return new WaitForSeconds(delayBetweenFades);
        animator.SetTrigger("FadeIn");
        screen_state = State.transparent;
    }

    public void OnFadeOutComplete() {
        screen_state = State.black;
        if (!endState) {
            StartCoroutine("FadeIn");
        } else if (endState) {
            GameObject.Find("Player").transform.parent = null;
            DontDestroyOnLoad(GameObject.Find("Player"));
            LevelChanger.instance.ChangeToLevel("EndScene");
            StartCoroutine("FadeIn");
        }
    }

    public void FadeOutGameOutro() {
        endState = true;
        FadeOut();
    }
}

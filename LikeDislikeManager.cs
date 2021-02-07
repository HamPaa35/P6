using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class LikeDislikeManager : MonoBehaviour
{
    public UnityEvent likeEvent;
    public UnityEvent dislikeEvent;
    public SteamVR_Action_Boolean like_input;
    public SteamVR_Action_Boolean dislike_input;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (like_input.stateDown)
        {
            Debug.Log("Like");
            likeEvent.Invoke();
        }

        if (dislike_input.stateDown)
        {
            Debug.Log("Dislike");
            dislikeEvent.Invoke();
        }
    }
}

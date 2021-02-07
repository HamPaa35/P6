using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryMarkerEventManager : MonoBehaviour
{
    public UnityEvent StoryMarkerEntered;
    private bool hasBeenActivated;
    [SerializeField] private bool needsToWait;
    private bool active;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasBeenActivated)
        {
            if (needsToWait && active)
            {
                Debug.Log("player head");
                hasBeenActivated = true;
                StoryMarkerEntered.Invoke();
            }

            if (!needsToWait)
            {
                Debug.Log("player head");
                hasBeenActivated = true;
                StoryMarkerEntered.Invoke();
            }
        }
    }

    public void toggleNeedsToWait()
    {
        needsToWait = !needsToWait;
    }

    public void toggleActive()
    {
        Debug.Log("toggled");
        active = !active;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class introPlay : MonoBehaviour
{
    [SerializeField]
    private AudioSource introSource;

    public bool canStart = false;
    public UnityEvent introDone;

    private bool introHasBeenPlayed;
    
    private void OnTriggerStay(Collider other)
    {
        if (!introHasBeenPlayed && canStart)
        {
            introHasBeenPlayed = true;
            // play introduction
            introSource.Play();
            introDone.Invoke();
        }
    }
}

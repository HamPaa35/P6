using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAxeCollision : MonoBehaviour
{
    public UnityEvent onHeadChop;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Choppable")
        {
            onHeadChop.Invoke();
            Debug.Log("collision with choppable");
        }
    }
}

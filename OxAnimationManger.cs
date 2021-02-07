using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxAnimationManger : MonoBehaviour
{
    private Animator animation;
    
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void playBreathing()
    {
        animation.Play("Breathing", 0, 0f);
    }
    
    public void playIdle()
    {
        animation.Play("Idle", 0, 0f);
    }
}

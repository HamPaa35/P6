using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ToggleableThrowable : Throwable
{
    private ToggleableThrowable _toggleableThrowable;
    
    protected void Start()
    {
        _toggleableThrowable = gameObject.GetComponent<ToggleableThrowable>();
    }

    protected override void OnAttachedToHand(Hand hand)
    {
        if(enabled) base.OnAttachedToHand(hand);
    }

    protected override void OnHandHoverBegin(Hand hand)
    {
        if(enabled) base.OnHandHoverBegin(hand);
    }

    protected override void HandHoverUpdate(Hand hand)
    {
        if(enabled) base.HandHoverUpdate(hand);
    }

    public void toggleThrowable()
    {
        _toggleableThrowable.enabled = !_toggleableThrowable.enabled;
    }
}

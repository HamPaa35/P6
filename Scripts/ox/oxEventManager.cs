using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class oxEventManager : MonoBehaviour
{
    private bool headSnapped;
    
    public UnityEvent headSnappedEvent;
    private bool runOnce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (headSnapped && !runOnce)
        {
            runOnce = true;
            Debug.Log("headsnap event");
            headSnappedEvent.Invoke();
        }
    }

    public void setHeadSnapped(bool headSnapped)
    {
        this.headSnapped = headSnapped;
    }
}

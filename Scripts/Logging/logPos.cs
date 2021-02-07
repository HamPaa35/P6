using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class logPos : MonoBehaviour
{
    
    // Passed variables
    [SerializeField]
    private string name;
    private Transform currentTrans;
    
    // Events
    public class PosChangedEvent : UnityEvent<Vector3> {}
    public PosChangedEvent onNewPos;

    // Components 
    private Logging logger;
    

    // Start is called before the first frame update
    void Start()
    {
        currentTrans = gameObject.GetComponent<Transform>();
        logger = GameObject.FindObjectOfType<Logging>();
        if (name == "")
        {
            Debug.LogError("Missing logPos name on " + gameObject.ToString() + "!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //onNewPos.Invoke(currentPos);
        logger.AddPosition(currentTrans.position, name);

    }

}

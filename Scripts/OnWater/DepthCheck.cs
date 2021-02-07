using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class DepthCheck : MonoBehaviour
{
    private Transform anchorTrans;

    [SerializeField]
    private GameObject water;
    private float waterLevel;
    [SerializeField]
    private GameObject threshDepthGameObject;
    private bool currectStorySegment;
    private bool hasSplashed;

    private float threshDepth;
    private bool depthReached = false;
    
    // event
    public UnityEvent wakeSnake;
    public UnityEvent waterLinecollision;

    // Start is called before the first frame update
    void Start()
    {
        waterLevel = water.GetComponent<Transform>().position.y; // give the water through the inspector
        anchorTrans = gameObject.transform;
        threshDepth = threshDepthGameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDepth();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Anker Depth Checker" && !depthReached && currectStorySegment)
        {
            wakeSnake.Invoke();
            depthReached = true;
        }

    }
    public void CheckDepth()
    {
        if (anchorTrans.position.y < waterLevel && !hasSplashed)
        {
            waterLinecollision.Invoke();
            hasSplashed = true;
        }
    }

    public void toggleCurrrectStorySegment()
    {
        currectStorySegment = !currectStorySegment;
        Debug.Log(currectStorySegment);
    }
}

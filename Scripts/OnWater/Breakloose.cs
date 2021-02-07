using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Breakloose : MonoBehaviour
{
    public UnityEvent CutLoose;
    public UnityEvent LowerSnek;
    private bool hasRun;

    [SerializeField] private float cutDelay = 30; 
    [SerializeField] private float loweringDelay = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            startFight();
        }
    }

    public void startFight()
    {
        if (!hasRun)
        {
            StartCoroutine(DelayCutLoose(cutDelay));
        }

    }

    private IEnumerator DelayCutLoose(float time)
    {
        yield return new WaitForSeconds(time);

        CutLoose.Invoke();
        StartCoroutine(DelayEscape(loweringDelay));
        hasRun = true;
        
    }
    
    private IEnumerator DelayEscape(float time)
    {
        yield return new WaitForSeconds(time);
 
        // Calls event after a delay
        LowerSnek.Invoke();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class storyProgressController : MonoBehaviour
{
    private int storyState;

    private Logging logger;
    
    private bool zeroRun;
    private bool oneRun;
    private bool twoRun;
    private bool threeRun;
    private bool fourRun;
    private bool fiveRun;
    private bool sixRun;

    public UnityEvent introEvent;
    public UnityEvent getHeadEvent;
    public UnityEvent talkedToHymirAndHasHead;
    public UnityEvent getInBoat;
    public UnityEvent battleStart;
    public UnityEvent outro;
    public UnityEvent gameFinished;
    public UnityEvent SaveLogs;
    // Start is called before the first frame update
    void Start() {
        storyState = -1;
        logger = FindObjectOfType<Logging>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateEvent();
    }

    public void ProgressStory()
    {
        storyState++;
        Debug.Log(storyState);
        logger.AddStoryProgress(storyState);
    }

    private void ActivateEvent()
    {
        switch (storyState)
        {
            case 0: // Introduction
                if (!zeroRun)
                {
                    introEvent.Invoke();
                    SaveLogs.Invoke();
                    zeroRun = true;
                }
                break;
            case 1: // Cut head off
                if (!oneRun)
                {
                    getHeadEvent.Invoke();
                    SaveLogs.Invoke();
                    oneRun = true;
                }
                break;
            case 2: // Talk to Hymer again
                if (!twoRun)
                {
                    talkedToHymirAndHasHead.Invoke();
                    SaveLogs.Invoke();
                    twoRun = true;
                }
                break;
            case 3: //Get in the boat
                if (!threeRun)
                {
                    getInBoat.Invoke();
                    SaveLogs.Invoke();
                    threeRun = true;
                }
                break;
            case 4: // To Battle!
                if (!fourRun)
                {
                    battleStart.Invoke();
                    SaveLogs.Invoke();
                    fourRun = true;
                }
                break;
            case 5: // Outro
                if (!fiveRun)
                {
                    outro.Invoke();
                    SaveLogs.Invoke();
                    fiveRun = true;
                }
                break;
            case 6: // Game finished
                if (!sixRun)
                {
                    gameFinished.Invoke();
                    SaveLogs.Invoke();
                    sixRun = true;
                }
                break;
        }
    }
}

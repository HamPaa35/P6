using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class tripChat : MonoBehaviour
{
    // Playing the audio
    [SerializeField]
    private GameObject player;
    [SerializeField] private AudioSource hymirChat;
    [SerializeField] private AudioSource angryHymer;
    [SerializeField] private AudioSource angryHymerAfter;
    [SerializeField]
    private float distance;
    private bool play;
    private bool talked;
    private bool hymerFirstPlayed = false;
    private bool oxHeadFirstPlayed = false;
    private bool hymerSecondPlayed = false;
    
    // Playing animations
    private HymerAnimationManager _animationManager;
    
    // For the delay
    private Transform other;
    private float range;
    private int delay;
    private float timing;
    
    // Event
    public UnityEvent hymirTalkedAfterOxHeadEvent;
    public UnityEvent hymirTalkedBeforeOxHeadEvent;
    private bool haveOxHead;


    // Start is called before the first frame update
    void Start()
    {
        talked = false;
        timing = Time.time;
        delay = 3;
        range = 5f;
        _animationManager = gameObject.GetComponent<HymerAnimationManager>();
        Debug.Log(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        startHymirChat();
        if (Input.GetKeyDown("u")) _animationManager.playPointing();
    }

    void startHymirChat(){
        if((player.transform.position-this.transform.position).sqrMagnitude < distance*distance && !play){
            print("test123");
            if (!talked && !haveOxHead && !hymerFirstPlayed) // hymer first
            {
                onlyPlayChatOnce();
                hymerFirstPlayed = true;
            }
            if (!talked && haveOxHead && !oxHeadFirstPlayed) // Ox head first
            {
                oxHeadFirstPlayed = true;
                headFirst();
            }
            if (talked && haveOxHead && !hymerSecondPlayed) // Proper last hymer
            {
                hymerSecondPlayed = true;
                secondTalk();
            }
        }
    }

    public void waterHymerChat()
    {
        
    }
    
    void onlyPlayChatOnce(){
        print("Play audio Chat one");
        hymirChat.Play(); //evt. AudioSource.PlayClipAtPoint(hymirChat, transform.position);
        _animationManager.playPointing(22);
        talked = true;
        hymirTalkedBeforeOxHeadEvent.Invoke();
    }
    void headFirst(){
        print("Play audio Head first");
        angryHymer.Play(); //evt. AudioSource.PlayClipAtPoint(hymirChat, transform.position);
        hymirTalkedAfterOxHeadEvent.Invoke();
    }
    private void secondTalk(){
        print("Play audio second talk");
        angryHymerAfter.Play(); //evt. AudioSource.PlayClipAtPoint(hymirChat, transform.position);
        hymirTalkedAfterOxHeadEvent.Invoke();
    }

    public void getHead()
    {
        haveOxHead = true;
    }
}
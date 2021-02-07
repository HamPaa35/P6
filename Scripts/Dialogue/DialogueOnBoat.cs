using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueOnBoat : MonoBehaviour
{
    private Transform transform;
    private float pos;

    // Inspector variables
    [SerializeField]
    private Transform firstDialogue;
    private float firstDialogueVal;

    [SerializeField]
    private Transform secondDialogue;
    private float secondDialogueVal;

    [SerializeField]
    private storyProgressController controller;

    [SerializeField] // Dialogue which plays first
    private AudioSource firstDialogueSource;
    [SerializeField] // Dialogue which plays second
    private AudioSource secondDialogueSource;
    
    // Non serialized
    private bool firstDialogueActivated;
    private bool secondDialogueActivated;

    private AudioManager _audioManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.transform;
        firstDialogueVal = firstDialogue.position.x;
        secondDialogueVal = secondDialogue.position.x;

        _audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        pos = transform.position.x;
        if (pos > secondDialogueVal && !secondDialogueActivated)
        { // Second
            secondDialogueActivated = true;
            PlayDialogue2();
            return;
        }
        
        if (pos > firstDialogueVal && !firstDialogueActivated)
        { // First
            firstDialogueActivated = true;
            PlayDialogue1();
        }
    }

    public void PlayDialogue1()
    {
        firstDialogueSource.Play();
        _audioManager.Play("BloodGushing");
        Debug.Log("aefgihjpjioaefgjopaefjoæaef");
    }
    
    public void PlayDialogue2()
    {
        secondDialogueSource.Play();
        Debug.Log("hjsdfhjkhjksdfhjkhjksdffsd");
    }
}

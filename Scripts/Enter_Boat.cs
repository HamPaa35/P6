using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Enter_Boat : MonoBehaviour {

    public SteamVR_Action_Boolean interaction_input;
    private bool boat_entered = false;
    private bool player_seated = false;
    public UnityEvent boatEnterEvent;
    
    
    public AudioManager audioManager;
    public FadeTransition fadeToBlack;
    public GameObject player;
    public GameObject boat;
    public GameObject playerSeat;

    // Start is called before the first frame update
    void Start() {
        try {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
        catch(Exception e) {
            Debug.Log("Gameobject: " + e + " not found in scene.");
        }
        try {
            fadeToBlack = GameObject.Find("FadeToBlack").GetComponent<FadeTransition>();
        }
        catch (Exception e) {
            Debug.Log("Gameobject: " + e + " not found in scene.");
        }
        
        player = GameObject.Find("Player").CompareTag("Player") ? GameObject.Find("Player") : null;
        boat = transform.parent.gameObject;
        foreach (Transform child in boat.transform) {
            if (child.name == "PlayerSeat") {
                playerSeat = child.gameObject;
            }
        }
        
        print("Player Seated: " + player_seated);
        print("Boat Entered: " + boat_entered);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_seated && boat_entered && fadeToBlack.screen_state == FadeTransition.State.black) {
            player_seated = PositionPlayerInBoat();
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {
        /*if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("fed nok!!!!!!!!!!!!!");
        }*/
        if (other.gameObject.CompareTag("Player"))
        {
            if (interaction_input.stateDown && !boat_entered) {
                boat_entered = true;
                fadeToBlack.FadeOut();
                Destroy(boat.GetComponent<Interactable>());
            }
        }
        
    }

    private bool PositionPlayerInBoat() {
        var rotationBoat = boat.transform.forward;
        playerSeat.transform.forward = player.transform.forward;
               
        player.transform.SetParent(playerSeat.transform, true);
                
        player.transform.localPosition = new Vector3(0, 0, 0);
        playerSeat.transform.forward = new Vector3(rotationBoat.x, rotationBoat.y, rotationBoat.z) * -1;
        Debug.Log("Enter boat");

        boatEnterEvent.Invoke();
        
        return true;
    }
}

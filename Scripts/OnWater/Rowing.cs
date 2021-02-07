using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

public class Rowing : MonoBehaviour {
    private GameObject leftHand, rightHand;
	private GameObject debugHand;
	public float force_scale = 1.0f;
	public float drag_scale = 0.33f;
	private Vector3 previousPosLeft;
	private Vector3 previousPosRight;
	private bool firstActivate = true;
	[SerializeField] private float speedModifier;
	private ControlerVibration vibration;
	[SerializeField] private GameObject vibrationManager;
	[SerializeField] private GameObject audioManager;
	private AudioManager _audio;
	private bool battle;
	
	// Update is called once per frame
	private void Start()
	{
		//rightHand = GameObject.Find("debugCube");
		leftHand = GameObject.Find("LeftHand");
		rightHand = GameObject.Find("RightHand");
		vibration = vibrationManager.GetComponent<ControlerVibration>();
		_audio = audioManager.GetComponent<AudioManager>();
	}

	void Update () {
		/*if (velocity_magnitude > 0.1f) {
			velocity -= direction * drag_scale * Time.deltaTime; <-- skal stå i takt med if(diff)
		}*/
	}
    public void rowControl(){
	    Vector3 differenceLeft = leftHand.transform.position - previousPosLeft;
		Vector3 differenceRight = rightHand.transform.position - previousPosRight;
	    if (firstActivate)
	    {
		    differenceLeft = new Vector3(0,0,0);
			differenceRight = new Vector3(0,0,0);
		    firstActivate = false;
	    }
		if(differenceLeft.x > 0 && differenceRight.x > 0 && !battle){
			transform.position += new Vector3 (((differenceLeft.x + differenceRight.x)/2)*speedModifier, 0, 0);//velocity * Time.deltaTime;
			vibration.vibrationOfRightController(0, 0.1f,1000,200);
			vibration.vibrationOfLeftController(0,0.1f,1000,200);
			_audio.Play("RowSound");
		}
		previousPosLeft = leftHand.transform.position;
		previousPosRight = rightHand.transform.position;
	}

    public void setFirstActivateTrue()
    {
	    firstActivate = true;
    }

    public void setBattle(bool battleState)
    {
	    this.battle = battleState;
    }
}
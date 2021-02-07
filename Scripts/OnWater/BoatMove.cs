using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour {

	public float speed = 1f;

	public float rotationSpeed;

	public float rotationControl;
	public float boatRotationY;

	private Transform OVRCamControl;

	void Start () 
	{
		OVRCamControl = GameObject.Find("OVRCameraController").transform;
	}
	
	void Update ()
	{
	}

	void FixedUpdate ()
	{
		transform.position += new Vector3(0,0,-speed);

//		rotationControl = OVRCamControl.localEulerAngles.y - 180;
//
//		if (rotationControl > -30 && rotationControl < 30)
//		{
//
//		} else {
//			boatRotationY += rotationControl * rotationSpeed; 
//		}
//
//		transform.Rotate(new Vector3(0,boatRotationY,0));
	}
}
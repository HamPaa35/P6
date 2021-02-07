using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class HymerMoveToBoat : MonoBehaviour {

    public GameObject boatGameObject;
    public GameObject hymerGameObject;
    
    void Awake()
    {
        boatGameObject = GameObject.Find("Boat");
        hymerGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveHymerToBoat() {
        HymerAnimationManager.instance.playSitting();
        hymerGameObject.transform.SetParent(boatGameObject.transform);
        hymerGameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        hymerGameObject.transform.localPosition = new Vector3(0, -0.315f, -1.5f);
    }
}

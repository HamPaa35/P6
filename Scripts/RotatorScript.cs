using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour {
    public bool rotateTrigger = true;
    public float rotationRate = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            if (rotateTrigger) {
                rotateTrigger = false;
            } else if (!rotateTrigger) {
                rotateTrigger = true;
            }
        }
        
        if (rotateTrigger) {
            this.transform.Rotate(0, rotationRate*Time.deltaTime, 0);
        }
    }
}

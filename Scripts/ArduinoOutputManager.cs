using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ArduinoOutputManager : MonoBehaviour
{

    SerialPort port=new SerialPort("COM5",9600);
	
    void Start ()
    {
    }
	
	
    void Update ()
    {
        if (Input.GetKey("a"))
        {
            runVibration("A");
        }
        else if (Input.GetKey("b"))
        {
            runVibration("B");
        }
        else if(Input.GetKey("c"))
        {
            runVibration("C");
        }
        else if(Input.GetKey("d"))
        {
            runVibration("D");
        }
        else if(Input.GetKey("z"))
        {
            runVibration("Z");
        }
        else if(Input.GetKey("f"))
        {
            runVibration("F");
        }

    }

    public void runVibration(String vibrationID)
    {
        port.Open();
        port.Write(vibrationID);
        port.Close();
    }
}


 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using Valve.VR;
 using Valve.VR.InteractionSystem;

 public class ControlerVibration : MonoBehaviour
 {
     public SteamVR_Action_Vibration hapticAction;
    
    // Update is called once per frame
    void Update()
    {
    }

    public void vibrationOfLeftController(float delay, float duration, float frequency, float amplitude)
    {
        hapticAction.Execute(delay, duration, frequency, amplitude, SteamVR_Input_Sources.LeftHand);
    }
    public void vibrationOfRightController(float delay, float duration, float frequency, float amplitude)
    {
        hapticAction.Execute(delay, duration, frequency, amplitude, SteamVR_Input_Sources.RightHand);
    }
}

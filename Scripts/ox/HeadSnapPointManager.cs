using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class HeadSnapPointManager : MonoBehaviour
{
    [SerializeField] private GameObject bodySnapPoint;
    [SerializeField] private GameObject head;
    [SerializeField] private float snapThreshold;
    [SerializeField] private GameObject vibrationManager;

    private Vector3 bodySnapPointPosition;
    private Vector3 originalHeadPosition;
    private UnityEngine.Quaternion originalHeadRotation;
    private Rigidbody headRigidbody;
    private oxRigidbody headRigidbodySript;
    private CustomThrowable _customThrowable;
    private GameObject rightHand;
    private GameObject leftHand;
    private bool hasBeenRipped = false;
    private oxEventManager _oxEventManager;
    private bool hasBeenDetatchedFromHand;
    private ControlerVibration vibration;

    private void Start()
    {
        bodySnapPointPosition = bodySnapPoint.transform.position;
        originalHeadPosition = head.transform.position;
        originalHeadRotation = head.transform.rotation;
        headRigidbody = head.GetComponent<Rigidbody>();
        headRigidbodySript = head.GetComponent<oxRigidbody>();
        _customThrowable = head.GetComponent<CustomThrowable>();
        rightHand = GameObject.Find("RightHand");
        leftHand = GameObject.Find("LeftHand");
        _oxEventManager = head.GetComponent<oxEventManager>();
        vibration = vibrationManager.GetComponent<ControlerVibration>();

    }

    private void Update()
    {
    }

    public Boolean CheckIfSnapOverThreshold()
    {
        Vector3 headSnapPointPosition = gameObject.transform.position;

        if (Vector3.Distance(headSnapPointPosition, bodySnapPointPosition) >= snapThreshold)
        {
            Debug.Log("Snap");
            return true;
        }
        if (Vector3.Distance(headSnapPointPosition, bodySnapPointPosition) <= snapThreshold)
        {
            Debug.Log("No Snap");
            return false;
        }
        {
            return false;
        }
    }

    public void ResetHeadToOriginalPosition()
    {
        if (!CheckIfSnapOverThreshold() && !hasBeenRipped)
        {
            headRigidbodySript.setGravity(false);
            head.transform.position = originalHeadPosition;
            head.transform.rotation = originalHeadRotation;
        }
        if (CheckIfSnapOverThreshold())
        {
            headRigidbodySript.setGravity(true);
            hasBeenRipped = true;
            Debug.Log("The head ripped is" + hasBeenRipped);
            _oxEventManager.setHeadSnapped(true);
        }

        if (hasBeenRipped)
        {
            headRigidbodySript.setGravity(true);
            Debug.Log("gravity");
        }

        if (!hasBeenDetatchedFromHand)
        {
            headRigidbodySript.setGravity(false);
        }
    }

    public void Interpolate()
    {
        if (!hasBeenRipped)
        {
            if (!CheckIfSnapOverThreshold() && _customThrowable.getCurrentHandType() == SteamVR_Input_Sources.LeftHand)
            {
                head.transform.position =
                    Vector3.Lerp(leftHand.transform.position, bodySnapPoint.transform.position, 0.5f);
                //head.transform.rotation =
                //UnityEngine.Quaternion.Lerp(leftHand.transform.rotation, bodySnapPoint.transform.rotation, 0.5f);
                vibration.vibrationOfLeftController(0,1,1000,200);
            }
            else if (!CheckIfSnapOverThreshold() &&
                     _customThrowable.getCurrentHandType() == SteamVR_Input_Sources.RightHand)
            {
                head.transform.position =
                    Vector3.Lerp(rightHand.transform.position, bodySnapPoint.transform.position, 0.5f);
                //head.transform.rotation =
                //UnityEngine.Quaternion.Lerp(leftHand.transform.rotation, bodySnapPoint.transform.rotation, 0.5f);
                vibration.vibrationOfRightController(0,1,1000,200);
            }
            else if (CheckIfSnapOverThreshold())
            {
                ResetHeadToOriginalPosition();
            }
        }
    }

    public void setHasBeedRipped(bool hasBeenRipped)
    {
        this.hasBeenRipped = hasBeenRipped;
    }

    public void DetatchedFromHand()
    {
        if (!hasBeenDetatchedFromHand && hasBeenRipped)
        {
            hasBeenDetatchedFromHand = true;
        }

        if (hasBeenDetatchedFromHand && hasBeenRipped)
        {
            headRigidbodySript.setGravity(true);
        }
    }
}
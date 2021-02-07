using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mjolnir : MonoBehaviour
{
    [SerializeField] private Transform MjolnirReturnPos;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform tempParent;
    private Transform posReturningFrom;

    [SerializeField] private float speed = 1;
    private float journeyLength;
    private float startTime;
    
    private Rigidbody rigid;

    private bool returning;
    
    // Lightning
    [SerializeField] private ParticleEffectManager lightning;
    [SerializeField] private ParticleEffectManager staticEffect;
    private bool lightningActive;
    
    // Holster check
    private float distCheck = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!returning) return;
        lightningActive = false;
        var trans = gameObject.transform;
        var distCovered = (Time.time - startTime) * speed;
        var fractionOfJourney = distCovered / journeyLength;
        
        // Check if mjolnir has returned to its origin.
        if (Vector3.Distance(transform.position, MjolnirReturnPos.position) < 0.01)
        {
            returning = false;
            transform.SetParent(parent);
            return;
        }
        
        // Lerp between return position and current position.
        trans.position = Vector3.Lerp(posReturningFrom.position, MjolnirReturnPos.position, fractionOfJourney);
        trans.rotation = Quaternion.Lerp(posReturningFrom.rotation, MjolnirReturnPos.rotation, fractionOfJourney);
    }

    public void GrabMjolnir()
    {
        staticEffect.StartParticle();
        rigid.constraints = RigidbodyConstraints.None;
        returning = false;
    }

    public void releaseMjolnir()
    {
        staticEffect.StopParticle();
        // Mjolnir has been holstered
        if (Vector3.Distance(transform.position, MjolnirReturnPos.position) < distCheck)
        {
            // Makes mjolnir return now
            returning = true;
            rigid.constraints = RigidbodyConstraints.FreezeAll;
            posReturningFrom = gameObject.transform;
            journeyLength = Vector3.Distance(posReturningFrom.position, MjolnirReturnPos.position);
            startTime = Time.time;
            return;
        }
        
        // Mjolnir has been thrown
        returnMjolnir();
    }

    private void returnMjolnir()
    {
        transform.SetParent(tempParent);
        lightningActive = true;
        StartCoroutine(ExecuteAfterTime(3));
    }
    
    private IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
 
        // Makes mjolnir return after a delay
        returning = true;
        rigid.constraints = RigidbodyConstraints.FreezeAll;
        posReturningFrom = gameObject.transform;
        journeyLength = Vector3.Distance(posReturningFrom.position, MjolnirReturnPos.position);
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (lightningActive)
        {
            // Play lightning particle effect
            lightning.StartParticle();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class oxRigidbody : MonoBehaviour
{
    private Rigidbody oxHeadRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        oxHeadRigidbody = gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(8, 10);
        Physics.IgnoreLayerCollision(9, 10);
        Physics.IgnoreLayerCollision(9, 14);
        Physics.IgnoreLayerCollision(8, 14);
        Physics.IgnoreLayerCollision(10, 14);
        Physics.IgnoreLayerCollision(0, 14);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setIsKinematic(bool kinematicState)    
    {
        oxHeadRigidbody.isKinematic = kinematicState;
    }
    
    public void setGravity(bool gravityState)
    {
        oxHeadRigidbody.useGravity = gravityState;
    }

    public void setIgnoreCollison(bool collisionState)
    {
        
    }
}

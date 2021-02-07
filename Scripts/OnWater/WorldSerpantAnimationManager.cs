using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSerpantAnimationManager : MonoBehaviour
{
    private Animator animation;

    [SerializeField] private GameObject anchor;
    private Rigidbody anchorRigid;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Container;
    [SerializeField] private GameObject mouthBone;
    
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        anchorRigid = anchor.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //playRiseAnimation();
        }
        //Quaternion newVector = new Quaternion(0, transform.rotation.y, transform.rotation.z, 0);
        //transform.rotation = newVector;
    }

    public void playRiseAnimation()
    {
        animation.Play("Rise up", 0, 0f);
        AttachSnek();
        AttachAnchor();

    }
    
    public void AttachAnchor()
    {
        transform.SetParent(Container.transform, true);
        anchor.transform.parent = mouthBone.transform;
        anchorRigid.constraints = RigidbodyConstraints.FreezeAll;
    }
    
    public void AttachSnek()
    {
        var tran = anchor.transform;
        var position = tran.position;
        var transform1 = transform;
        
        transform1.LookAt(player.transform);
        transform1.rotation = new Quaternion(0, transform1.rotation.y, 0f, 1);
        
        transform1.parent = tran;
        transform1.position = new Vector3(position.x, position.y, position.z);
    }
}

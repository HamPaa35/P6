using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MjolnirHolster : MonoBehaviour
{
    [SerializeField] private Transform Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Player.position;
        var rot = Player.rotation;
        var newPos = new Vector3(pos.x, pos.y, pos.z);
        var newRot = new Quaternion(0, rot.y, 0, rot.w);
        transform.position = newPos;
        transform.rotation = newRot;
    }
}

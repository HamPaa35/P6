using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTail : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,0,rotationSpeed);
    }
}

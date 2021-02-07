using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class RaiseTails : MonoBehaviour
{
    [SerializeField]
    private int lowering;

    private int randomFactor;

    [SerializeField]
    private bool raising;

    [SerializeField]
    private List<float> raiseCount;

    [SerializeField]
    private float raiseSpeed = 0.5f;

    [SerializeField] private List<Transform> tails;
    

    // Start is called before the first frame update
    void Start()
    {
        var temp = gameObject.GetComponentsInChildren<Transform>();
        tails = new List<Transform>(temp);
        tails.RemoveAt(0);
        foreach (var tail in tails)
        {
            randomFactor = UnityEngine.Random.Range(1, 150);
            float tempLow = randomFactor + lowering;
            tail.position -= new Vector3(0,tempLow,0);
            raiseCount.Add(tempLow);
        }
        
        
    }

    private void Update()
    {
        if (raising)
        {
           for (int i = 0; i < tails.Count; i++)
           {
               if (raiseCount[i] > 0)
               {
                   tails[i].position += new Vector3(0,raiseSpeed,0);
                   raiseCount[i] -= raiseSpeed;
               }
           } 
        }

    }

    public void raise()
    {
        raising = true;
    }
}

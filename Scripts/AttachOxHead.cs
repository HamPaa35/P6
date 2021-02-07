using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.Events;

public class AttachOxHead : MonoBehaviour
{
    [SerializeField] private GameObject anchorOx;
    public UnityEvent headAttachedToAnchor;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Anchor")
        {
            headAttachedToAnchor.Invoke();
            Destroy(gameObject);
            anchorOx.SetActive(true);
        }

    }
}

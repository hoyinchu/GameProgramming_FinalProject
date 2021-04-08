using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggerBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject throwObject;
    public Camera cm;
    private GameObject emptyObject;

    private void Start()
    {
        emptyObject = new GameObject();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (throwObject == null)
        {
            throwObject = GameObject.FindGameObjectWithTag("ThrowObject");
        }
        if (cm == null)
        {
            cm = Camera.main;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    other.transform.parent = transform.parent;
        //}
        if (other.gameObject.CompareTag("ThrowObject") && !PickupBehavior.isPickedUp)
        {
            // emptyObject is set as the parent of the box to prevent it from scaling to the scaling of the platform
            emptyObject.transform.parent = transform;
            other.transform.parent = emptyObject.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    other.transform.parent = null;
        //}
        if (other.gameObject.CompareTag("ThrowObject") && (other.transform.parent != cm.transform))
        {
            other.transform.parent = null;
        }
    }
}

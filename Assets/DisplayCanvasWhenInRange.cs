using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCanvasWhenInRange : MonoBehaviour
{

    public GameObject CanvasChildren;

    private void Start()
    {
        CanvasChildren.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasChildren.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasChildren.SetActive(false);
        }
    }
}
    

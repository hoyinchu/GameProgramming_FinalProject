using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public MonoBehaviour[] scriptTargets;
    public string triggerName;
    bool running = false;
    bool playerAtButton = false;
    void Start()
    {
        scriptTargets = target.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptTargets)
        {
            script.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerAtButton)
        {
            if (!running)
            {
                foreach (MonoBehaviour script in scriptTargets)
                {
                    script.enabled = true;
                }
            } else
            {
                foreach (MonoBehaviour script in scriptTargets)
                {
                    script.enabled = false;
                }
            }
            running = !running;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAtButton = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAtButton = false;
        }
    }
}

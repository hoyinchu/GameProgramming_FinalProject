using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] animatedObjects;
    public string triggerName;
    bool running = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // display message on UI saying "Press E to press button"
            if (Input.GetKeyDown(KeyCode.E) && !running)
            {
                Debug.Log("button pressed");
                running = !running;
                foreach (GameObject go in animatedObjects)
                {
                    go.GetComponent<Animator>().SetBool(triggerName, running);
                }
            }
        }
    }
}

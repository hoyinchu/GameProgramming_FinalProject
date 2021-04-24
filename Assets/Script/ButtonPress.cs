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
    public GameObject player;
    bool isPressed = false;
    public AudioClip clickSFX;

    public bool oneTimePress = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        scriptTargets = target.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptTargets)
        {
            script.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerAtButton && ((oneTimePress && !isPressed) || !oneTimePress))
        {
            isPressed = true;
            AudioSource.PlayClipAtPoint(clickSFX, player.transform.position);
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

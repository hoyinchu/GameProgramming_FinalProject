using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    bool playerAtButton = false;
    public GameObject player;
    public static bool isPressed = false;
    //public AudioClip clickSFX;
    private LevelManager levelM;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.levelM = GameObject.Find("LevelManager").GetComponent<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerAtButton)
        {
            isPressed = true;
            //AudioSource.PlayClipAtPoint(clickSFX, player.transform.position);
            levelM.LevelBeat();

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
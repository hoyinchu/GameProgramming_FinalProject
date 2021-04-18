using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NoteReading : MonoBehaviour
{
    //public Image helloNote;
    public GameObject currentNote;
    public Text noteText;
    public AudioClip readSFX;
    public GameObject player;



    LevelManager levelManager;
    bool isNoteOpen;
    Text newText;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        newText = GameObject.FindGameObjectWithTag("NoteAsset").GetComponent<Text>();
        currentNote = LevelManager.currentNote;
        noteText = LevelManager.noteText;

        isNoteOpen = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

     void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Q) && !isNoteOpen)
        {
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 5))
            {
            if (hit.collider.CompareTag("NoteAsset"))
                {
                    newText = hit.transform.GetComponentInChildren<Text>();
                    levelManager.ChangeNoteText(newText.text);
                    levelManager.SetCurrentNoteStatus(true);
                    AudioSource.PlayClipAtPoint(readSFX, player.transform.position);
                    isNoteOpen = true;
                }

            }

        }

        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q) && isNoteOpen)
        {
            levelManager.SetCurrentNoteStatus(false);
            isNoteOpen = false;

        }
    }
}

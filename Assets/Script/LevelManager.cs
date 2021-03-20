using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  [SerializeField]
    public bool isGameOver = false; 
    public string nextLevel;
    //public Text winText;
    //public Text deadText;
    //public Image textBackground;
    //public AudioClip lostSFX;
    //public AudioClip winSFX;
   
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        //winText.gameObject.SetActive(false);
        //deadText.gameObject.SetActive(false);
        //textBackground.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


    }


    public void LevelLost() {

        if(!isGameOver){

         Debug.Log("Level Lost");

        //deadText.gameObject.SetActive(true);
        //textBackground.gameObject.SetActive(true);
        //AudioSource.PlayClipAtPoint(lostSFX, Camera.main.transform.position);

        isGameOver = true;

       Invoke("LoadCurrentLevel", 2);
        }
    }

    public void LevelBeat() {

        if(!isGameOver){

         Debug.Log("Level Beat");

        //winText.gameObject.SetActive(true);
        //textBackground.gameObject.SetActive(true);
        //AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);
        isGameOver = true;

        Invoke("LoadNextLevel", 2);
        }
    
    }

    void LoadNextLevel() {

         SceneManager.LoadScene(nextLevel);
    }

    void LoadCurrentLevel(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

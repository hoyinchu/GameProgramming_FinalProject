using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehavior : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){

            if(isGamePaused){

                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
        
    }

    void PauseGame(){

        if(pauseMenu != null){

        isGamePaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ResumeGame(){

        if(pauseMenu != null){

        isGamePaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        }


    }

    public void LoadMainMenu(){

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        isGamePaused = false;


    }

    public void ExitGame(){

        Application.Quit();



    }
}

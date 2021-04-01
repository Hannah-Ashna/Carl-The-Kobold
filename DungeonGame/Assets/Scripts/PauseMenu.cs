using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gamePaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        // Set the UI to inactive and reset the time
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Pause(){
        // Set the UI to active and pause time
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void LoadMenu() {
        // Return to main menu
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
    }

    public void QuitGame() {
        // Quit the game
        Application.Quit();
    }
}

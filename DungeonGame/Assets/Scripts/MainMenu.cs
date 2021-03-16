using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        // Load in the Game Scene
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        // End the game and close application
        Application.Quit();
    }
}

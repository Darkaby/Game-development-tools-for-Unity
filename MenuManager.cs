using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Check if game is paused
    public bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject pauseButton;

    // Resume game
    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameIsPaused = false;
        Time.timeScale = 1f;
        Debug.Log("Resume game");
    }

    // Replay game after it stopped
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //GameManagerL1.gameEnded = false;
        Debug.Log("Replay game");
    }

    // Pause game
    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        gameIsPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Pause game");
    }

    // Go back to the main menu
    public void PlayNextLevel()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(0);

        if (SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(2);
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Quit Game");
        Application.Quit();

        // Go back to the main menu in the editor to see that we quitted
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
}

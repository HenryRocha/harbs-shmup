using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    // Wheter the game is currently pause or not.
    public static bool GameIsPaused = false;

    // Reference to the Pause Panel UI.
    public GameObject pausePanelUI;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Debug.Log("Paused!");
                ResumeGame();
            }
            else
            {
                Debug.Log("Continued!");
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausePanelUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;

    }

    public void ResumeGame()
    {
        pausePanelUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void QuitToMainMenu()
    {
        pausePanelUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
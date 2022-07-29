using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public UnityEvent PauseEvent;
    public UnityEvent ResumePreRoundEvent;
    public UnityEvent ResumeRoundEvent;

    private GameManager.GameState _lastState;

// Resume is called once the game is unpaused
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        if (_lastState == GameManager.GameState.Round)
            ResumeRoundEvent?.Invoke();
        else if(_lastState == GameManager.GameState.PreRound)
            ResumePreRoundEvent?.Invoke();
    }
    // Pause is called once the game is paused
    public void Pause() {
        _lastState = GameManager.state;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        PauseEvent?.Invoke();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    void Update()
    {
        // If escape is pressed, pause or resume the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}

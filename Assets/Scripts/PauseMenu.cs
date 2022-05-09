using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ToDo: Esc should activate back button on submenus, but not cascade through previous menu too.

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUi;
    public GameObject videoSettingsMenuUi;
    public GameObject audioSettingsMenuUi;
    public GameObject animationSettingsMenuUi;
    public static bool handlingBackButton = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!gameIsPaused) {
                Pause();
            } else if (pauseMenuUi.activeSelf && !handlingBackButton) {
                Resume();
            }
        } else if (handlingBackButton) {
            handlingBackButton = false;
        }
    }

    public void Resume()
    {
        Debug.Log("Resuming...");

        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Pause()
    {
        Debug.Log("Pausing...");
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowVideoSettingsMenu()
    {
        Debug.Log("Showing video settings...");
        pauseMenuUi.SetActive(false);
        videoSettingsMenuUi.SetActive(true);
    }

    public void ShowAudioSettingsMenu()
    {
        Debug.Log("Showing audio settings...");
        pauseMenuUi.SetActive(false);
        audioSettingsMenuUi.SetActive(true);
    }

    public void ShowAnimationSettingsMenu()
    {
        Debug.Log("Showing anim settings...");
        pauseMenuUi.SetActive(false);
        animationSettingsMenuUi.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

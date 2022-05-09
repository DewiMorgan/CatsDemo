using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSettingsMenu : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public GameObject videoSettingsMenuUi;
    public List<Resolution> resolutions = new List<Resolution>();
    public TMP_Text resolutionLabel;


    private static bool isFullScreen;
    private static bool isVsync;
    private static int quality;
    private static int selectedResolution = 0;

    // Start is called before the first frame update
    void Start()
    {
        isFullScreen = Screen.fullScreen;
        isVsync = QualitySettings.vSyncCount != 0;
        quality = QualitySettings.GetQualityLevel();

        // Get screen resolutions.
        foreach (Resolution res in Screen.resolutions) {
            resolutions.Add(res);
        }

        bool foundResolution = false;
        for (int i = 0; i < resolutions.Count; i++) {
            if (Screen.width == resolutions[i].width && Screen.height == resolutions[i].height) {
                selectedResolution = i;
                updateResolutionLabel();
                foundResolution = true;
                break;
            }
        }

        // If we're using another resolution, add that.
        if (!foundResolution) {
            resolutions.Add(Screen.currentResolution);
            selectedResolution = resolutions.Count - 1;
            updateResolutionLabel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (videoSettingsMenuUi.activeSelf) {
                OnBackButton();
            }
        }
    }

    public void OnBackButton()
    {
        Debug.Log("Going back...");
        pauseMenuUi.SetActive(true);
        PauseMenu.handlingBackButton = true;
        videoSettingsMenuUi.SetActive(false);
    }

    public void OnQualityDropdown(int quality)
    {
        Debug.Log("Set to quality: " + quality);
        VideoSettingsMenu.quality = quality;
    }

    public void OnFullScreenToggle(bool isFullScreen)
    {
        Debug.Log("Set FullScreen to " + (isFullScreen ? "FullScreen" : "Windowed"));
        VideoSettingsMenu.isFullScreen = isFullScreen;
    }

    public void OnVsyncToggle(bool isVsync)
    {
        Debug.Log("Set vsync to " + (isVsync ? "Vsync" : "No Vsync"));
        VideoSettingsMenu.isVsync = isVsync;
    }

    public void OnResolutionDownButton()
    {
        selectedResolution--;
        if (selectedResolution < 0) {
            selectedResolution = 0;
        }
        updateResolutionLabel();
        Debug.Log("Set res down, to " + selectedResolution);
    }

    public void OnResolutionUpButton()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1) {
            selectedResolution = resolutions.Count - 1;
        }
        updateResolutionLabel();
        Debug.Log("Set res up, to " + selectedResolution);
    }

    public void OnApplyButton()
    {
        Debug.Log("Applying settings. "
            + (VideoSettingsMenu.isFullScreen ? "FullScreen, " : "Windowed, ") 
            + (VideoSettingsMenu.isVsync ? "" : "No ") 
            + "vsync, qual=" 
            + VideoSettingsMenu.quality);
        QualitySettings.SetQualityLevel(quality);
        QualitySettings.vSyncCount = isVsync ? 1 : 0;
        Screen.SetResolution(resolutions[selectedResolution].width, resolutions[selectedResolution].height, isFullScreen, resolutions[selectedResolution].refreshRate);
    }

    public void updateResolutionLabel()
    {
        resolutionLabel.text = 
            resolutions[selectedResolution].width 
            + "x" 
            + resolutions[selectedResolution].height 
            + " @" 
            + resolutions[selectedResolution].refreshRate
            + "Hz";
    }

}

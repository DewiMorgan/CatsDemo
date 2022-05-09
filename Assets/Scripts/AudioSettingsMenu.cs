using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsMenu : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public GameObject audioSettingsMenuUi;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (audioSettingsMenuUi.activeSelf) {
                OnBackButton();
            }
        }
    }


    public void OnBackButton()
    {
        Debug.Log("Going back...");
        pauseMenuUi.SetActive(true);
        PauseMenu.handlingBackButton = true;
        audioSettingsMenuUi.SetActive(false);
    }
}

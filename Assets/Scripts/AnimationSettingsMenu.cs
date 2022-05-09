using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSettingsMenu : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public GameObject animationSettingsMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (animationSettingsMenuUi.activeSelf) {
                OnBackButton();
            }
        }
    }

    public void OnBackButton()
    {
        Debug.Log("Going back...");
        pauseMenuUi.SetActive(true);
        PauseMenu.handlingBackButton = true;
        animationSettingsMenuUi.SetActive(false);
    }
}

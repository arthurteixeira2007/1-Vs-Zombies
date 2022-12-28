using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public bool OpenMenu = false;
    public GameObject PausePanel;

    public void Start ( ) { Time.timeScale = 1f; }

    public void Update ( ) {
        if(Input.GetKey(KeyCode.Escape)) {
            if (!OpenMenu) {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
                OpenMenu = true;
            }else{
                PausePanel.SetActive(false);
                Time.timeScale = 1f;
                OpenMenu = false;
            }
        }
    }

    public void Resume ( ) { 
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        OpenMenu = false;
    }

    public void QuitGame ( ) {
        SceneManager.LoadScene("Menu");
    }
}

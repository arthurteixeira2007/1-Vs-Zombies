using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour {

    void Start ( ) {
        Cursor.visible = true;
    }

    public void RestartGame ( ) {
        SceneManager.LoadScene("Battle");
    } 

    public void GoMenu ( ) {
        SceneManager.LoadScene("Menu");
    }
}

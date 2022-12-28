using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsPanel : MonoBehaviour {
    public void Resume ( ) {
        this.gameObject.SetActive(false);
    }
}

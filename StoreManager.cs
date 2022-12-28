using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {
    public GameObject StorePanel;
    public bool IsOpen = false;

    public Player playerScript;

    void Awake() {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        Time.timeScale = 1f;
    }

    public void Update ( ) {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (IsOpen) {
                StorePanel.SetActive(false);
                IsOpen = false;
                Time.timeScale = 1f;
            }else{
                StorePanel.SetActive(true);
                IsOpen = true;
                Time.timeScale = 0f;
            }
        }
    }

    public void BuyGrenade ( ) {
        if (playerScript.Money >= 100) {
            playerScript.Money -= 100;
            playerScript.GrenadeValue++;
        }
    }

    public void BuyHealth ( ) {
        if (playerScript.Money >= 500 && playerScript.Health <= 99) {
            playerScript.Money -= 500;
            playerScript.Health += 25;
        }
    }

    public void BuyFireGun ( ) {
        if (playerScript.Money >= 350 && !playerScript.OnFire) {
            playerScript.Money -= 350;
            playerScript.WhichWeapon = 2;
        }
    }

    public void BuyOldGuitar ( ) {
        if (playerScript.Money >= 450 && !playerScript.WithGuitar)  {
            playerScript.Money -= 450;
            playerScript.WithGuitar = true;
        }
    }

    public void BuyShotgun ( ) {
        if (playerScript.Money >= 250 && !playerScript.WithShotgun) {
            playerScript.Money -= 250;
            playerScript.WhichWeapon = 3;
        }
    }
}

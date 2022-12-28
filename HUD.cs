using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public int Death;
    public int C;
    public Text TextDeath;

    public Player player;
    public Text TextGrenade;

    public Text TextMoney;

    public Animator anim;
    public AudioSource IhaFX;

    public void Update ( ) {
        TextDeath.text = "DEATH'S: " + Death.ToString();
        TextGrenade.text = "GRENADE's: " + player.GrenadeValue.ToString(); 
        TextMoney.text = "$" + player.Money.ToString("D3");
        if (C >= 50) {
            InsaneAnimation();
        }
    }

    public void InsaneAnimation ( ) {
        anim.SetBool("insane", true);
        IhaFX.Play();
        C = 0;
    }

    public void EndInsaneAnimation ( ) {
        anim.SetBool("insane", false);
    }
}

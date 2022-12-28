using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public int Timer = 0;
    public int C = 1;
    public GameObject Zombie;
    public GameObject BigZombie;
    public int TimerBigZombie = 0;

    public PauseMenu Paused;

    public void Update ( ) {
        if (!Paused.OpenMenu) {
            Timer++;
            TimerBigZombie++;
            if (Timer >= 180) {
                do{
                    Instantiate(Zombie, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    C++;
                }while (C <= 2);
                C = 0;
                Timer = 0;
            }

            if (TimerBigZombie >= 800) {
                Instantiate(BigZombie, this.gameObject.transform.position, this.gameObject.transform.rotation);
                TimerBigZombie = 0; 
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public SpriteRenderer SprRender;
    public Sprite NormalGun, FireGun;
    public Sprite DieSprite;
    
    public Sprite ShotgunSprite;
    public bool WithShotgun = false;

    public int WhichWeapon = 1;

    public PauseMenu Paused;
    public StoreManager Store;

    public GameObject GrenadeObject;
    public int GrenadeValue = 4;

    public GameObject AttackGuitar;
    public GameObject HudGuitar;
    public bool WithGuitar;

    public int Money = 0;

    public float C = 26.5f;

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public int Health = 100;
    public Text HealthText;

    public GameObject DeathHUD;

    public GameObject ControlsHUD;

    public float runSpeed = 20.0f;

    public AudioSource DeathFX;
    public HUD hud; 

    public AudioSource MapFX;

    public bool OnFire = false;

    void Start (){
        body = GetComponent<Rigidbody2D>();
        hud = GameObject.Find("Canvas").GetComponent<HUD>();
        SprRender = GetComponent<SpriteRenderer>();
        MapFX.Play();
    }

    void Update() {
        // Instantiate the grenade
        if (Input.GetKeyDown(KeyCode.Space) && GrenadeValue >= 1) {
            Instantiate(GrenadeObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
            GrenadeValue -= 1;
        }

        //Open Controls Menu
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            ControlsHUD.SetActive(true);
        }

        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Health >= 100) {
            Health = 100; 
        }
        if (Health <= 0) {
            this.SprRender.sprite = DieSprite;
            Health = 0; 
        }

        HealthText.text = "HP: " + Health.ToString();
        if (Health <= 0) {
            
            DeathHUD.SetActive(true);
        }

        if (WithGuitar && !Store.IsOpen) {
            AttackGuitar.SetActive(true);
            HudGuitar.SetActive(true);
            StartCoroutine("EndGuitarAttack");
        }

        //Select Weapon
        if (Health != 0) {
            switch (WhichWeapon) {
                case 1:
                    SprRender.sprite = NormalGun;
                    WithShotgun = false;
                    OnFire = false;
                    break;
                case 2:
                    SprRender.sprite = FireGun;
                    OnFire = true;
                    WithShotgun = false;
                    break;
                case 3:
                    SprRender.sprite = ShotgunSprite;
                    WithShotgun = true;
                    OnFire = false;
                    break;
                default:
                    SprRender.sprite = NormalGun;
                    WithShotgun = false;
                    OnFire = false;
                    break;
            }
        }else{
            SprRender.sprite = DieSprite;
        }
    }

    void FixedUpdate() {
        if (horizontal != 0 && vertical != 0) {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 10) {
            Health -= 25;
        }
    }

    IEnumerator EndGuitarAttack ( ) {
        yield return new WaitForSeconds(26.5f);
    
        AttackGuitar.SetActive(false);
        HudGuitar.SetActive(false);
        WithGuitar = false;
    } 
}

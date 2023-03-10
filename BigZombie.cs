using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombie : MonoBehaviour {
    public Transform player;
    public Player playerScript;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject Blood;
    public HUD hud;
    public int Health = 10;

    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        hud = GameObject.Find("Canvas").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if (Health <= 0) {
            Destroy(this.gameObject);
            Instantiate(Blood, this.gameObject.transform.position, this.gameObject.transform.rotation);
            hud.Death++;
            hud.C++;
            playerScript.Money += 10;
        }
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 9) {
            Health--;
        }

        if (other.gameObject.layer == 11) {
            Health = 0;
        }
    }
}

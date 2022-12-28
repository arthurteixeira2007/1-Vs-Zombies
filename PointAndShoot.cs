using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour {
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject FireBullet;
    public GameObject bulletStart;
    public GameObject shotgunBullet;

    public Player playerScript;

    public float bulletSpeed = 8.0f;

    private Vector3 target;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update () {
            target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            crosshairs.transform.position = new Vector2(target.x, target.y);

        
        if (playerScript.Health != 0) {
            Vector3 difference = target - player.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

            if (playerScript.OnFire) {
                bulletSpeed = 4.5f;
            }

            if(Input.GetMouseButtonDown(0)){
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                fireBullet(direction, rotationZ);
            }
        }
    }
    void fireBullet(Vector2 direction, float rotationZ){
        if (playerScript.WhichWeapon == 1) {
            GameObject b = Instantiate(bulletPrefab) as GameObject;
            b.transform.position = bulletStart.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }else if (playerScript.WhichWeapon == 2) {
            GameObject b = Instantiate(FireBullet) as GameObject;
            b.transform.position = bulletStart.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }else{
            GameObject b = Instantiate(shotgunBullet) as GameObject;
            /*GameObject b = Instantiate(bulletPrefab) as GameObject;*/
            b.transform.position = bulletStart.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            GameObject b2 = Instantiate(shotgunBullet) as GameObject;
            /*GameObject b = Instantiate(bulletPrefab) as GameObject;*/
            b2.transform.position = bulletStart.transform.position;
            b2.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b2.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}

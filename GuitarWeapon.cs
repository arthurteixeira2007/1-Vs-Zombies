using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarWeapon : MonoBehaviour {
    public GameObject rotateAround;
    public float rotationSpeed;
    public Transform player;

    void Awake ( ) {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void FixedUpdate ( ) {
        transform.RotateAround(rotateAround.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}

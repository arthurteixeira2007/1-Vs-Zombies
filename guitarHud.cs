using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guitarHud : MonoBehaviour {
    public float rotationSpeed;
    public Vector3 rotationDirection;
    public Player playerScript;
    public AudioSource GuitarSoloFX;

    void Start ( ) {
        GuitarSoloFX.Play();
    }

    private void FixedUpdate() {
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {
    public Transform ObjectAnchor;

    public void FixedUpdate ( ) {
        transform.position = new Vector3(ObjectAnchor.position.x, ObjectAnchor.position.y, 0f);
    }
}

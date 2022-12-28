using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    public float TimeToDestroy;

    public void Start ( ) {
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject ( ) {
        yield return new WaitForSeconds(TimeToDestroy);

        Destroy(this.gameObject);
    }
}

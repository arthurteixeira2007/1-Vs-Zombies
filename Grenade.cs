using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
   public GameObject ExplosionObject;

   private void OnCollisionEnter2D(Collision2D other) {
       if (other.gameObject.layer == 10) {
           Instantiate(ExplosionObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
           Destroy(this.gameObject);
       }
   }
}

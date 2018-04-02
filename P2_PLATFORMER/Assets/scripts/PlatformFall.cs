using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour {

    public float delay;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        { //don't need if statement if everything that hits it
            Invoke("Fall", delay); //no need to invoke if no delay, just edit isKinematic here
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}

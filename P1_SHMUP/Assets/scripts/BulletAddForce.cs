using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAddForce : MonoBehaviour {

    private Rigidbody2D rib;
    public float speed = 1000f;

    // Use this for initialization
    void Start () {
        rib = GetComponent<Rigidbody2D>();
        rib.AddForce(transform.right * speed);
        Destroy(this.gameObject, 2);
    }
}

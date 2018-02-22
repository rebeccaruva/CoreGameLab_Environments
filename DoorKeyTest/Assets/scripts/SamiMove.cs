using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamiMove : MonoBehaviour {

    Rigidbody2D rib;
    public float speed = 4f;

	// Use this for initialization
	void Start () {
        rib = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //left and right
        float xSpeed = Input.GetAxisRaw("Horizontal");
        //up and down
        float ySpeed = Input.GetAxisRaw("Vertical");
        rib.velocity = new Vector2(xSpeed, ySpeed) * speed;

	}
}

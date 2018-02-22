using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour {

    Rigidbody2D rib;
    private float speed = 8f;
    public bool hasKey = false;

	// Use this for initialization
	void Start () {
        rib = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float speedX = Input.GetAxis("Horizontal");
        float speedY = Input.GetAxis("Vertical");
        //GetAxisRaw, either moving or not
        rib.velocity = new Vector2(speedX, speedY) * speed;
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("door") && hasKey) {
            print("you win!");
            SceneManager.LoadScene("win");
        }
    }
}

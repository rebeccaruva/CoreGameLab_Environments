using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeMove : MonoBehaviour {

    public float speed = 10f;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(xSpeed, ySpeed) * speed;
        
	}

    void OnCollisioinEnter(Collider2D other)
    {
        if(other.CompareTag("wasp1"))
        {
            SceneManager.LoadScene("3-restart");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpAndDown : MonoBehaviour {


    public float speed = .5f; //how fast it moves
    public float distance = 2f; //how far up it moves
    private float startPosition; //needs to get back to start

    void Start()
    {
        startPosition = transform.position.y;
    }

    void Update()
    {
        Vector2 newPosition = transform.position; //temp variable
        newPosition.y = Mathf.SmoothStep(startPosition, startPosition + distance, Mathf.PingPong(Time.time * speed, 1)); //assign
        transform.position = newPosition; //new calculated position
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PlayerPicto") || coll.gameObject.CompareTag("PlayerBat") || coll.gameObject.CompareTag("PlayerHide"))
        {
            coll.transform.SetParent(transform); //sets player as a child
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PlayerPicto") || coll.gameObject.CompareTag("PlayerBat") || coll.gameObject.CompareTag("PlayerHide"))
        {
            coll.transform.SetParent(null); //puts player back
        }
    }
}

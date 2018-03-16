using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonLerp : MonoBehaviour {
    float speed = .4f;
    float distance;

    void Start()
    {
        // if you want it to go across the whole screen.
        //distance = Camera.main.orthographicSize * Screen.width / Screen.height;
        distance = 4f;
    }

    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.SmoothStep(-distance-14, distance-14, Mathf.PingPong(Time.time * speed, 1));
        transform.position = newPosition;
    }

}

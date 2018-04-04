﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpy : MonoBehaviour
{
    public float speed = .4f;
    public float distance;

    void Start()
    {
        // if you want it to go across the whole screen.
        //distance = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.SmoothStep(-distance + 129, distance + 129, Mathf.PingPong(Time.time * speed, 1));
        transform.position = newPosition;
    }

}

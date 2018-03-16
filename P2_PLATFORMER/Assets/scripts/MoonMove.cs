using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMove : MonoBehaviour {

    private float timeCounter;
    private float speed;
    private float width;
    private float height;

    // Use this for initialization
    void Start()
    {
        timeCounter = 0f;
        speed = .1f;
        width = 30f;
        height = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter) * -width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = 20;

        transform.position = new Vector3(x, y, z);
    }
}

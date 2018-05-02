using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTongue : MonoBehaviour {
    private Transform start;
    private Transform end;
    public float speed;
    private float startTime;
    private float journeyLength;

	// Use this for initialization
	void Start () {
        //randomize
        start.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-.8f, 53f), Random.Range(-5f, 5f));
        end.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-.8f, 53f), Random.Range(-5f, 5f));


        startTime = Time.time;
        journeyLength = Vector3.Distance(start.position, end.position);
	}
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(start.position, end.position, fracJourney);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOwl : MonoBehaviour {
    public TextMesh talk;
    private bool talking = false;
    private int lineNum = 0;
    private string[] words;


	// Use this for initialization
	void Start () {
        words = new string[5];
        words[0] = "hoot hoot";
        words[1] = "sometimes we'll give you advice";
        words[2] = "be careful some of us lie";
        words[3] = "goodbye now!";
        words[4] = " ";
	}
	
	// Update is called once per frame
	void Update () {
		if (talking && Input.GetButtonUp("Fire2"))
        {
            //Debug.Log("i talk");
            talk.text = words[lineNum];
            lineNum++;
            if (lineNum >= words.Length)
            {
                lineNum = 0;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerPicto"))
        {
            //Debug.Log("i can talk");
            talking = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("PlayerPicto"))
        {
            //Debug.Log("no talk");
            talking = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOwl : MonoBehaviour {
    public TextMesh talk;
    private bool talking = false;
    private int lineNum = 0;
    private string[] words;

    public AudioClip owl;
    private AudioSource audi;

    public GameObject followText;


    // Use this for initialization
    void Start () {
        words = new string[5];
        words[0] = "hoot hoot";
        words[1] = "sometimes we'll give you advice";
        words[2] = "be careful some of us lie";
        words[3] = "goodbye now!";
        words[4] = " ";

        audi = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (talking && Input.GetButtonUp("Fire2"))
        {
            
            talk.text = words[lineNum];
            lineNum++;
            if (lineNum >= words.Length)
            {
                lineNum = 0;
            }
            if (lineNum == 0)
            {
                audi.PlayOneShot(owl);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerPicto"))
        {
            //Debug.Log("i can talk");
            talking = true;
            followText.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("PlayerPicto"))
        {
            //Debug.Log("no talk");
            talking = false;
            talk.text = " ";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceOwlFour : MonoBehaviour
{
    public TextMesh talk;
    private bool talking = false;
    private int lineNum = 0;
    private string[] words;

    public AudioClip owl;
    private AudioSource audi;


    // Use this for initialization
    void Start()
    {
        words = new string[6];
        words[0] = "hoot hoot";
        words[1] = "down keeps you alive";
        words[2] = "but can also kill you";
        words[3] = "a jaguar is nearby";
        words[4] = "be ready to ctrl it";
        words[5] = " ";

        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (talking && Input.GetButtonUp("Fire2"))
        {
            //Debug.Log("i talk");
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
        if (other.CompareTag("PlayerPicto"))
        {
            //Debug.Log("i can talk");
            talking = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerPicto"))
        {
            //Debug.Log("no talk");
            talking = false;
        }
    }
}

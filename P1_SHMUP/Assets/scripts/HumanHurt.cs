using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HumanHurt : MonoBehaviour {

    public int humanHealth = 6;
    public Sprite[] healthSprite = new Sprite[6];
    Image image;

    public GameObject gamesControl; //access health and score
    private GameController gamesController;

    // Use this for initialization
    void Start () {
        //Canvas canvas = GetComponent<Canvas>();
        image = GetComponent<Image>();
        gamesController = gamesControl.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (humanHealth == 6)
        {
            image.sprite = healthSprite[5];
        }
        else if (humanHealth == 5)
        {
            image.sprite = healthSprite[4];
        }
        else if (humanHealth == 4)
        {
            image.sprite = healthSprite[3];
        }
        else if (humanHealth == 3)
        {
            image.sprite = healthSprite[2];
        }
        else if (humanHealth == 2)
        {
            image.sprite = healthSprite[1];
        }
        else if (humanHealth == 1)
        {
            image.sprite = healthSprite[0];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("wasp1"))
        {
            if(humanHealth<0)
            {
                gamesController.ResetScore();
                SceneManager.LoadScene("3-restart");
            }
            humanHealth--;
        }
        if(other.CompareTag("bossWasp"))
        {
            gamesController.ResetScore();
            SceneManager.LoadScene("3-restart");
        }
    }
}

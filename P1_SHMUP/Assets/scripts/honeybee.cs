using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeybee : MonoBehaviour {

    private int honeyHit = 0;
    public Rigidbody2D rib;
    private float speed = -70f;
    //public SpriteRenderer honeyGlaze;
    public GameObject honey;

    //Animator anim;

    public GameObject honeyExplosion;
    public GameObject pollenExplosion;

    private GameObject gameControllerObject; //access health and score
    private GameController gamesController;

    // Use this for initialization
    void Start()
    {

        //access game control
        gameControllerObject = GameObject.FindWithTag("gamecontroller");
        gamesController = gameControllerObject.GetComponent<GameController>();
        // GameControl gamesControl = gameControl.GetComponent<GameControl>();

        //move wasp, don't glaze yet and don't affect animation yet
        //anim = GetComponent<Animator>();
        //honeyGlaze.enabled = false;
        rib.AddForce(Vector2.right * speed);
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PollenBullet"))
        {
            //Debug.Log("I'm hit!");
            Instantiate(pollenExplosion, transform.position, Quaternion.identity);

            gamesController.AddScore(-3); // increase player score

            Destroy(other.gameObject);
            Destroy(honey);
            //Destroy(this.gameObject);
        }

        if (other.CompareTag("HoneyBullet"))
        {
                Instantiate(honeyExplosion, transform.position, Quaternion.identity);

                gamesController.AddScore(-5); // increase player score

                Destroy(other.gameObject);

                honeyHit = 0;

                Destroy(honey);
                //Destroy(this.gameObject);

        }
    }
}

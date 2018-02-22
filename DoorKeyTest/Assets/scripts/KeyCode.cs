using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCode : MonoBehaviour {

    //private GameObject player;
    public GameObject player;

    void Start() {
        //if you need to find private, use tag
        //GameObject.FindGameObjectsWithTag - returns array
        //GameObject.FindGameObjectWithTag - returns first one
        //player = GameObject.FindGameObjectWithTag("Player");
        
        //if you need to use find
        //player = GameObject.Find("sami");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerCode>().hasKey = true;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //only change scene if sami tag is changed
        if(collision.CompareTag("PlayerReady"))
        {
            SceneManager.LoadScene("win");
        }
    }

}

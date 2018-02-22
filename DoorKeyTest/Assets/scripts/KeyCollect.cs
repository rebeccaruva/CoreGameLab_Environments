using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollect : MonoBehaviour {

    bool readyCheck = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //change tag and make key disappear
        if (collision.CompareTag("key"))
        {
            readyCheck = true;
            //this.gameObject.tag = "PlayerReady";
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("door") && readyCheck)
        {
                SceneManager.LoadScene("win");
        }
    }
}

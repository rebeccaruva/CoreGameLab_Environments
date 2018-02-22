using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void BeeOnMouseUp()
    {
        SceneManager.LoadScene("2-shmup");
    }

    public void QuitOnMouseUp()
    {
        //SceneManager.LoadScene("1-title");
        Application.Quit();
    }
}


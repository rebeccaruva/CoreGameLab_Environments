using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryOne : MonoBehaviour {

    public void RetryLevelOne()
    {
        SceneManager.LoadScene("2-xibalba");
    }

    public void RetryLevelTwo()
    {
        SceneManager.LoadScene("3-earth");
    }

    public void RetryLevelThree()
    {
        SceneManager.LoadScene("4-ball");
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("1.5-intro");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HopyAgain : MonoBehaviour
{

    public AudioClip flute;
    private AudioSource audi;

    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerPicto"))
        {
            audi.PlayOneShot(flute);
            Invoke("NewScreen", 3);
        }
    }

    void NewScreen()
    {
        SceneManager.LoadScene("3-earth");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHoop : MonoBehaviour {

    public int numGO = 5;
    public GameObject[] roundUno;
    public GameObject[] roundDos;
    public GameObject cam;

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
        cam.GetComponent<PlayerFollowX>().enabled = true;
        for (int i = 0; i < numGO; i++)
        {
            roundUno[i].SetActive(false);
        }
        for (int i = 0; i < numGO; i++)
        {
            roundDos[i].SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}

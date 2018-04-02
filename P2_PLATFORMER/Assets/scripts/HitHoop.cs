using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHoop : MonoBehaviour {

    public int numGO = 5;
    public GameObject[] roundUno;
    public GameObject[] roundDos;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerPicto"))
        {
            for (int i=0; i < numGO; i++)
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
}

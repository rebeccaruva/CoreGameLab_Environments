using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHoop : MonoBehaviour {

    public GameObject Hoop;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerPicto"))
        {
            Hoop.SetActive(true);
        }
    }
}

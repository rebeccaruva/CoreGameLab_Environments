using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBullet : MonoBehaviour {

    public GameObject honeyBulletPrefab;
    public GameObject pollenBulletPrefab;
    private GameObject bulletPrefab;

    public AudioClip shootHoney;
    public AudioClip shootPollen;
    private AudioClip shoot;
    private AudioSource audi;

    public Transform posRef;
    //
    //can combine this code with player control!!!
    //

	// Use this for initialization
	void Start () {
        bulletPrefab = honeyBulletPrefab;
        shoot = shootHoney;
        audi = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //or can use Input.GetButtonDown("Jump")
        //if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(2))
        //{
        //    if(bulletPrefab == pollenBulletPrefab)
        //    {
        //        bulletPrefab = honeyBulletPrefab;
        //        shoot = shootHoney;
        //    } else
        //    {
        //        bulletPrefab = pollenBulletPrefab;
        //        shoot = shootPollen;
        //    }
        //}


		if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bulletPrefab, posRef.position, Quaternion.identity);
            audi.PlayOneShot(shoot);
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("flow"))
        {
            bulletPrefab = pollenBulletPrefab;
            shoot = shootPollen;
        }
    }
}

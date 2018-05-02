using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueStretch : MonoBehaviour {

    public Vector3 startPosition;
    public GameObject tongue;
    public bool mirrorZ;
    //private RaycastHit hit;

	// Use this for initialization
	void Start () {
        //Stretch(gameObject, startPosition, endPosition, mirrorZ);
    }
	
	// Update is called once per frame
	void Update () {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if(Input.GetMouseButton(0))
            {
                tongue.transform.localScale += new Vector3(0f, hit.distance, 0f);
                //tongue.transform.position += new Vector3(0f, hit.distance / 2, 0f);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            tongue.transform.localScale = startPosition;
        }
    }

    //public void Stretch(GameObject _sprite, Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ)
    //{
    //    Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
    //    _sprite.transform.position = centerPos;
    //    Vector3 direction = _finalPosition - _initialPosition;
    //    direction = Vector3.Normalize(direction);
    //    _sprite.transform.right = direction;
    //    if (_mirrorZ) _sprite.transform.right *= -1f;
    //    Vector3 scale = new Vector3(1, 1, 1);
    //    scale.x = Vector3.Distance(_initialPosition, _finalPosition);
    //    _sprite.transform.localScale = scale;
    //}
}

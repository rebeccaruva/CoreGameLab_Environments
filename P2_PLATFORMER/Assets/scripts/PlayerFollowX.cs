using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowX : MonoBehaviour
{

    public Transform player;

    void LateUpdate()
    {
        //x and y
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        //only x
        transform.position = new Vector3(player.position.x, player.position.y-player.position.y, transform.position.z);
    }
}

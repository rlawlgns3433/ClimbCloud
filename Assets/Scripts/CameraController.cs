using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
}

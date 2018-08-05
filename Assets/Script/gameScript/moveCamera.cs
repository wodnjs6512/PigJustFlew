using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    Transform player;
    float offsetX;
    // Use this for initialization
    void Start()
    {
        GameObject player_obj = GameObject.Find("Player");

        player = player_obj.transform;
        if (player == null)
        {
            Debug.Log("no player");
        }

        offsetX = transform.position.x - player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
    }
}

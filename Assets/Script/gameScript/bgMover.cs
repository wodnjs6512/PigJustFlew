using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMover : MonoBehaviour {
    public BirdMovement birdMove;
    Vector3 pos;
    // Update is called once per frame
    Transform player;
    float offsetX;

    private void Start()
    {
        GameObject birdObj = GameObject.Find("Player");
        birdMove = birdObj.GetComponent<BirdMovement>();
        player = birdObj.transform;
        offsetX = transform.position.x - player.position.x;

    }
    void FixedUpdate() {
       
        pos = transform.position;
        pos.x = player.position.x + offsetX;
        transform.position = pos;
	}
}

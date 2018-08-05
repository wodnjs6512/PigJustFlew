using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollCamera : MonoBehaviour {

    // Use this for initialization
    float maxXleft =  0f;
    float maxXright = 300f;
    float maxYleft =  0f;
    float maxYright = 1f;
    float speed = 8f;
    float adjustSpeed = 13f;
    float min = 0f;
    float max = 150f;
    public int page = 0;
    private Vector2 prevPos;

    void Update()
    {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                Mathf.Clamp(touchDeltaPosition.x, min, max);
                transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime*2,0,0);

                //-touchDeltaPosition.y * speed * Time.deltaTime
                Vector3 tmpPosX = transform.position;
                tmpPosX.x = Mathf.Clamp(tmpPosX.x, maxXleft, maxXright);
                transform.position = tmpPosX;

                Vector3 tmpPosY = transform.position;
                tmpPosY.y = Mathf.Clamp(tmpPosY.y, maxYleft, maxYright);
                transform.position = tmpPosY;
            
        }
        adjust();
    }
  
    void adjust()
    {
        for (int i = 0; i < 15; i++)
        {
            if (Mathf.Abs(i * 15f - transform.position.x) < 0.45)
            {
                page = i;
                break;
            }
        }
        
        
        float posix = page * 15f;
        Mathf.Clamp(posix, min, max);

        
        if (transform.position.x < posix-0.15f)
        {
            transform.Translate(adjustSpeed * Time.deltaTime, 0, 0);
            transform.position = new Vector3(transform.position.x+ adjustSpeed * Time.deltaTime, 0, transform.position.z);
        }
        if(transform.position.x>posix+0.15f)
        {
            transform.Translate(-adjustSpeed * Time.deltaTime, 0, 0);
            transform.position = new Vector3(transform.position.x - adjustSpeed * Time.deltaTime, 0, transform.position.z);
        }
    }
}

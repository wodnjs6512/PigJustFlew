using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looper : MonoBehaviour {
    Vector3 pos;
    Transform trans;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider.transform.name);
        trans = collider.transform;
        string tag = trans.tag;
        
        if (tag == "obj")
        {
            //Debug.Log("OBJ destroyed");
            Destroy(collider.gameObject);
            return;
        }
        if (tag == "bar")
        {
            //Debug.Log("OBJ destroyed");
            Destroy(collider.gameObject);
            return;
        }
        if(tag== "effect")
        {
            //Debug.Log("OBJ destroyed");
            Destroy(collider.gameObject);
            return;
        }


        pos= trans.position;

        pos.x += 59f*2;

        trans.position = pos;
    }
}

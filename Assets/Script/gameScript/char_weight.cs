using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class char_weight : MonoBehaviour
{
    private BirdMovement birdMove;
    public RuntimeAnimatorController anim_pig;
    public Sprite img1, img2, img3, img4, img5;
    private Animator current_anim;
    private SpriteRenderer current_img;
    private int previousLevel;
    public GameObject collision_trigger1, collision_trigger2, collision_trigger3, collision_trigger4, collision_trigger5;
    public GameObject triggers;
    GameObject player_obj;
    float starting_updater;
    public int level;

    private void Awake()
    {
        current_anim = this.transform.GetComponentInChildren<Animator>();
        current_img = this.transform.GetComponentInChildren<SpriteRenderer>();
        current_anim.runtimeAnimatorController = anim_pig;
    }
    // Use this for initialization
    void Start()
    {
        birdMove = GameObject.Find("Player").GetComponent<BirdMovement>();
        current_img.sprite= img3;
        previousLevel = 3;
        level = 3;
        birdMove.dead = false;
        Time.timeScale = 1;
        current_anim.SetTrigger("DoFlap");
        current_img.sprite = img3;


        if (triggers != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player_collider"));
        }
        triggers = Instantiate(collision_trigger3) as GameObject;
        triggers.transform.parent = this.transform;
        player_obj = GameObject.FindGameObjectWithTag("Player");
        triggers.transform.position = player_obj.transform.position;

    }

    void Update()
    {
        if (birdMove.gauge <= 2f)
        {
            level = 1;
            birdMove.flapVelocity = 19f;
           // Debug.Log("case1");
            current_img.sprite = img1;
            matchAnim();
        }
        else if (2f<birdMove.gauge&&birdMove.gauge <6f)
        {
            level = 2;
            birdMove.flapVelocity = 16f;
           // Debug.Log("case2");
            current_img.sprite = img2;
            matchAnim();
        }
        else if (birdMove.gauge>=7f && birdMove.gauge< 11.1f)
        {
            level = 3;
            birdMove.flapVelocity = 13f;
            //Debug.Log("case3");
            current_img.sprite = img3;
            matchAnim();
        }
        else if (birdMove.gauge >= 12f && birdMove.gauge < 14f)
        {
            level = 4;
            birdMove.flapVelocity = 6f;
          //  Debug.Log("case4");
            current_img.sprite = img4;
            matchAnim();
        }
        else if (birdMove.gauge >=16f)
        {
            level = 5;
            birdMove.flapVelocity = 3f;
           // Debug.Log("case5");
            current_img.sprite = img5;
            matchAnim();
        }

        if (birdMove.didFlap)
        {
            current_anim.SetTrigger("DoFlap");
            if(birdMove.update_flap) {
                if(level == 1)
                {
                    birdMove.gauge -= 0.1f;
                }
                else if (level == 2)
                {
                    birdMove.gauge -= 0.2f;
                }
                else if (level == 3)
                {
                    birdMove.gauge -= 0.2f;
                }
                else if (level == 4)
                {
                    birdMove.gauge -= 0.2f;
                }
                else if (level == 5)
                {
                    birdMove.gauge -= 0.2f;
                }
                birdMove.gauge = Mathf.Clamp(birdMove.gauge, birdMove.gauge_min, birdMove.gauge_max);
                birdMove.update_flap = false;
            }
        }
        if (birdMove.eat)
        {
            birdMove.gauge += 1f;
            birdMove.gauge = Mathf.Clamp(birdMove.gauge, birdMove.gauge_min, birdMove.gauge_max);
            birdMove.eat = false;
        }

        if (birdMove.dead)
        {
            current_anim.SetTrigger("Death");
        }
    }



    GameObject findCollider(int level)
    {
        switch (level)
        {
            case 1:
                return collision_trigger1;
            case 2:
                return collision_trigger2;
            case 3:
                return collision_trigger3;
            case 4:
                return collision_trigger4;
            case 5:
                return collision_trigger5;
            default:
                return collision_trigger3;
        }

    }
    void matchAnim()
    {
        //Debug.Log("level  = " + level);
        //Debug.Log("previous = " + previousLevel);
        if (previousLevel > level)
        {
            //Debug.Log("prev from, to" + previousLevel + " " + previousLevel--);
            previousLevel--;
            current_anim.SetTrigger("down");
            //Debug.Log("down");
        }
        else if (previousLevel < level)
        {
            //Debug.Log("prev from, to" + previousLevel + " " + previousLevel++);
            previousLevel++;
            current_anim.SetTrigger("up");
           // Debug.Log("up");
        }
        
        if (triggers != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player_collider"));
        }
        triggers = Instantiate(findCollider(level)) as GameObject;
        triggers.transform.parent = this.transform;
        player_obj = GameObject.FindGameObjectWithTag("Player");
        triggers.transform.position = player_obj.transform.position;
        previousLevel = level;
        //Debug.Log(previousLevel + "  " + level);
    }
}
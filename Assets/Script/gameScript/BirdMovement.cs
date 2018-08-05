using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;


public class BirdMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private float unitTime = 2f;
    private float nextScoringTime;

    
    private float forwardSpeed = 10f;
    private float nextUpdate;
    public int score;
    private saveLoad SaveLoad;

    public bool godMode = false;
    public float flapVelocity;
    public float gauge;
    public float gauge_max = 20f, gauge_min=0f;

    //float angle = 0;
    charSet set;
    public GameObject character;

    public AudioSource audios;
    private float death_delay;
    
    public bool eat = false;
    public bool update_flap = false;
    public bool dead = false;
    public bool didFlap = false;
    private int death_delay_update;

    private void Awake()
    {
        SaveLoad = GameObject.Find("gameControl").GetComponent<saveLoad>();
        SaveLoad.load();
        Debug.Log(SaveLoad.current_character);
        set = this.GetComponent<charSet>();
        if(set == null)
        {
            Debug.Log("Null");
        }
        SaveLoad.changeCurrentCharacter(1);
        switcher();
        GameObject char_obj = Instantiate(character) as GameObject;
        char_obj.transform.parent = this.transform;
        audios = GetComponent<AudioSource>();
    }
    void switcher()
    {
        switch (SaveLoad.current_character) { 
            //piggy
            case 0:
                character = set.c0;
            return;
            //shiba
            case 1:
                character = set.c1;
            return;
            //cola bear
            case 2:
                character = set.c2;
            return;
            //calf
            case 3:
                character = set.c3;
            return;
            //Jerry
            case 4:
                character = set.c4;
            return;
            //Tyranno
            case 5:
                character = set.c5;
            return;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (Vector2.up * flapVelocity);
        nextScoringTime = Time.time + unitTime;
        gauge = 11f;
        score = 0;
        rb.gravityScale = 5;
        death_delay_update = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition.y);
            didFlap = true;
            //Debug.Log(Time.time + "  " + death_delay);
            if (dead && Time.time > death_delay && Input.mousePosition.y>270f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                dead = false;
                return;
            }
        }
        if (Time.time > nextScoringTime &&!dead)
        {
            nextScoringTime = nextScoringTime + unitTime;
            score += 50;
        }
    }
    void FixedUpdate()
    {
        if (dead) {
            return;
        }
        Vector2 right = new Vector2(forwardSpeed, rb.velocity.y);
        rb.velocity = right;

        if (didFlap == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, flapVelocity);
            Mathf.Clamp(rb.velocity.y, -flapVelocity, flapVelocity/2);
            didFlap = false;
            update_flap = true;
            //audios.Play();
        }
        /*
        if (rb.velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -30, -rb.velocity.y / maxSpeed);
        }
        else if (rb.velocity.y > 0)
        {
            angle = Mathf.Lerp(0, 30, rb.velocity.y / maxSpeed);
        }*/


       // transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision.transform.tag);
        if ((collision.transform.tag == "ground" || collision.transform.tag == "bar") && !godMode){ 
            dead = true;
            if (death_delay_update<1) { 
                death_delay = Time.time + 3f;
                Debug.Log(Time.time + "  " + death_delay);
                death_delay_update++;
            }
            SaveLoad.updateHighScore(score);
            //Debug.Log(collision.transform.name);
            rb.velocity = Vector3.zero;
            SaveLoad.gameOverScreen = true;
            SaveLoad.save();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.name == "beans(Clone)")
        {
            //Debug.Log(collision.transform.name);
            Destroy(collision.gameObject);
            score = score + 10;
            gauge = Mathf.Clamp(gauge, gauge_min, gauge_max);
            eat = true;
        }
        else if (collision.transform.name == "gem(Clone)")
        {
            //Debug.Log(collision.transform.name);
            Destroy(collision.gameObject);
            SaveLoad.gem++;
            gauge = Mathf.Clamp(gauge, gauge_min, gauge_max);
            eat = true;
        }
    }
}

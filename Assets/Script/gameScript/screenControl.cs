using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenControl : MonoBehaviour {

    public Text count1,count2,count3;
    // Use this for initialization
    private saveLoad SaveLoad;
    private BirdMovement birdMove;

    public Button share, store, exit,rating;
    public Text scoreInd, gemInd, record, newrecord_pop, finalscore, tapToRestart;

	void Start () {
        SaveLoad = GameObject.Find("gameControl").GetComponent<saveLoad>();
        birdMove = GameObject.Find("Player").GetComponent<BirdMovement>();

        SaveLoad.countdown = true;
        SaveLoad.gameOverScreen = false;
        // counter items;
        count1.enabled = false;
        count2.enabled = false;
        count3.enabled = false;

        //play status
        scoreInd.enabled = true;
        record.enabled = true;

        //gameover items;
        newrecord_pop.enabled = false;
        tapToRestart.enabled = false;
        finalscore.enabled = false;
        exit.enabled = false;
        store.enabled = false;
        rating.enabled = false;
        share.enabled = false;
        share.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        store.gameObject.SetActive(false);
        rating.gameObject.SetActive(false);
    }
    void Update()
    {
        if (SaveLoad.countdown)
        {
            StartCoroutine(startCount());
            SaveLoad.countdown = false;
        }
        gemInd.text = "Gem : "+SaveLoad.gem;
        scoreInd.text = ""+birdMove.score;
        finalscore.text = "" + birdMove.score;
        record.text = "HIGH : " + SaveLoad.highscore;
        if (SaveLoad.gameOverScreen)
        {
            textControl(true);
            buttonControl(true);
            //Debug.Log("gameover");
        }
    }
    void textControl(bool play)
    {
        scoreInd.enabled = !play;
        record.enabled = !play;
        if (birdMove.score == SaveLoad.highscore) { 
            newrecord_pop.enabled = play;
        }
        tapToRestart.enabled = play;
        finalscore.enabled = play;
    }
    void buttonControl(bool on)
    {
            exit.enabled = on;
            store.enabled = on;
            rating.enabled = on;
            share.enabled = on;
            share.gameObject.SetActive(on);
            exit.gameObject.SetActive(on);
            store.gameObject.SetActive(on);
            rating.gameObject.SetActive(on);   
    }
   
    public void moveToStore()
    {
        SceneManager.LoadScene("char_unlock_store");
    }
    public void moveToMainMenu()
    {
        SceneManager.LoadScene("MainScreen");
    }
    IEnumerator startCount()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        count1.enabled = false;
        count2.enabled = false;
        count3.enabled = true;
        yield return new WaitForSecondsRealtime(1);
        count1.enabled = false;
        count2.enabled = true;
        count3.enabled = false;
        yield return new WaitForSecondsRealtime(1);
        count1.enabled = true;
        count2.enabled = false;
        count3.enabled = false;
        yield return new WaitForSecondsRealtime(1);
        count1.enabled = false;
        count2.enabled = false;
        count3.enabled = false;
        Time.timeScale = 1;
    }
}

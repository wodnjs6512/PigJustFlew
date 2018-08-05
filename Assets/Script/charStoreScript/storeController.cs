using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class storeController : MonoBehaviour {
    // Use this for initialization
    saveLoad SaveLoad;
    public Camera cam;
    scrollCamera mainCam;
    public Text gemInd, stat, charName, desc;
    private int page;
	void Start () {
        SaveLoad = GameObject.Find("Canvas").GetComponent<saveLoad>();
        SaveLoad.load();
        mainCam = cam.GetComponent<scrollCamera>();
    }

    // Update is called once per frame
    void Update () {
        gemInd.text = "Gem : " + SaveLoad.gem;
        page = mainCam.page;
        stat.text = "";
        /*int newthang = (int)(cam.transform.position.x / 15f);
        stat.text = "int :  "+ newthang + " page : "
            +cam.GetComponent<scrollCamera>().page +
            "page up " 
            + (transform.position.x / 15f - (int)(transform.position.x / 15f) > 0.5f) + 
            "posx " + cam.transform.position.x;
            */
        switch (page)
        {
            case 0:
                charName.text = "PIGGY";
                desc.text = "Eats Everything";
                return;
            case 1:
                charName.text = "SHIBA";
                desc.text = "From Japan";
                return;
            case 2:
                charName.text = "COLA BEAR";
                desc.text = "Need Black Drink";
                return;
            case 3:
                charName.text = "BULL";
                desc.text = "Aggressive";
                return;
            case 4:
                charName.text = "JERRY";
                desc.text = "Eats Everything";
                return;
            case 5:
                charName.text = "TYRANNO";
                desc.text = "ROAR!!!";
                return;
        }
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainScreen");
    }
}

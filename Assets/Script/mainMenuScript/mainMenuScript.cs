using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button play;
    public Button store;
    public Button exit;

    // Use this for initialization
    
    void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        play = play.GetComponent<Button>();
        store = store.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        quitMenu.enabled = false;
	}

    // Update is called once per frame
    public void ExitPress()
    {
        quitMenu.enabled = true;
        play.enabled = false;
        store.enabled = false;
        exit.enabled = false;
    } 
    public void Oink()
    {
        quitMenu.enabled = false;
        play.enabled = true;
        store.enabled = true;
        exit.enabled = true;
    }
    public void playGame()
    {
        SceneManager.LoadScene("PlayScreen");
    }
    public void moveToStore()
    {
        SceneManager.LoadScene("char_unlock_store");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

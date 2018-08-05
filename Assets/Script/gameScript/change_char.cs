using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class change_char : MonoBehaviour {
    public saveLoad SaveLoad;
    public int current_char;

    void start()
    {
        SaveLoad = GameObject.Find("gameControl").GetComponent<saveLoad>();
        SaveLoad.load();
        current_char = SaveLoad.current_character;
        Debug.Log("prev "+SaveLoad.current_character);
        if(SaveLoad.current_character == 1) { 
            SaveLoad.changeCurrentCharacter(0);
        }
        else
        {
            SaveLoad.changeCurrentCharacter(1);
        }
        Debug.Log("curr "+SaveLoad.current_character);
    }

}

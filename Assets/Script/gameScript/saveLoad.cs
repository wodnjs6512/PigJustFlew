using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class saveLoad : MonoBehaviour {

    public static saveLoad SL;
    public int highscore;
    public int gem;
    public List<int> unlocked_character;
    public int current_character;
    public bool countdown = false;
    public bool gameOverScreen = false;

    void Awake()
    {
        SL = this;
    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            file= File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        }
        else
        {
            file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.CreateNew);
        }

        PlayerData data = new PlayerData();
        data.highscore = highscore;
        data.gem = gem;
        data.unlocked_character = unlocked_character;
        data.current_character = current_character;
        bf.Serialize(file, data);
        file.Close();
    }
    public void load()
    {
        if(File.Exists(Application.persistentDataPath+ "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            highscore = data.highscore;
            gem = data.gem;
            unlocked_character = data.unlocked_character;
            current_character = data.current_character;
        }
    }
    public void updateHighScore(int score)
    {
        if(score > highscore)
        {
            highscore = score;
            save();
        }
    }
    public void updateGem(int newGemValue)
    {
        gem = gem + newGemValue;
        save();
    }
    public void updateUnlockedCharacter(int characterNum)
    {
        //if (unlocked_character.Contains(characterNum))
       // {
         //   updateGem(30);
            // notify;
           // save();
       // }
        //else { 
            unlocked_character.Add(characterNum);
            save();
        //}
    }
    public void changeCurrentCharacter(int characterNum)
    {
        
        if(current_character != characterNum && unlocked_character.Contains(characterNum))
        {
            current_character = characterNum;
        }
        save();
    }
}

[Serializable]
class PlayerData
{
    public int highscore;
    public int gem;
    public List<int> unlocked_character;
    public int current_character;
}
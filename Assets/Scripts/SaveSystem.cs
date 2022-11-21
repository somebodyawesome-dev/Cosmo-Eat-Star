using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static string playerDataPath = Application.persistentDataPath + "/PlayerData.xD";

    public static void savePlayerData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerDataPath, FileMode.Create);
        SavedPlayerData savedPlayerData = new SavedPlayerData();
        formatter.Serialize(stream, savedPlayerData);
        stream.Close();

    }
    public static void LoadPlayerData()
    {
        if (File.Exists(playerDataPath))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(playerDataPath, FileMode.Open);
            SavedPlayerData savedPlayerData = formatter.Deserialize(stream) as SavedPlayerData;
            stream.Close();
            //load data into scriptableObjcet
            if (savedPlayerData != null)
            {
                PlayerData.highScore = savedPlayerData.highScore;
                PlayerData.isMusicOff = savedPlayerData.isMusicOff ;
                PlayerData.isSoundOff = savedPlayerData.isSoundOff ;
                PlayerData.token = savedPlayerData.token ?? string.Empty;
            }
        }
        else
        {
            Debug.LogError("PlayerData File not found in :" + playerDataPath);
            PlayerData.highScore = 0;
            PlayerData.isMusicOff = false ;
            PlayerData.isSoundOff = false ;
            PlayerData.token = string.Empty;
            
        }
    }
}

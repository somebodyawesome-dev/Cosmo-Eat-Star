using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedPlayerData 
{
    public int highScore;
    public bool isMusicOff;
    public bool isSoundOff;

    public SavedPlayerData()
    {
        highScore = PlayerData.highScore;
        isMusicOff = PlayerData.isMusicOff;
        isSoundOff = PlayerData.isSoundOff;
    }
}

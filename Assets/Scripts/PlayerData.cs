using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
public class PlayerData : SingletonScriptableObject<PlayerData>
{
    [SerializeField] private int _highScore;
    public static int highScore
    {
        get
        {
            return Instance._highScore;
        }
        set
        {
            Instance._highScore = value;
            SaveSystem.savePlayerData();    
        }
    }

    [SerializeField] private bool _isSoundOff;
    public static bool isSoundOff
    {
        get
        {
            return Instance._isSoundOff;
        }
        set
        {
            Instance._isSoundOff = value;
            SaveSystem.savePlayerData();
            FindObjectOfType<AudioManager>().setSound(value);
        }
    }
    [SerializeField] private bool _isMusicOff;
    public static bool isMusicOff
    {
        get
        {
            return Instance._isMusicOff;
        }
        set
        {
            Instance._isMusicOff = value;
            SaveSystem.savePlayerData();
            
            FindObjectOfType<AudioManager>().setMusic(value);
        }
    }

    [SerializeField] private string _token = string.Empty;

    public static string token
    {
        get
        {
            return Instance._token;
        }
        set
        {
            Instance._token = value;
            SaveSystem.savePlayerData();
        }
    }

}

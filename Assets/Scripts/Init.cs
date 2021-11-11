using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    public Text bestScore;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject musicOn;
    public GameObject musicOff;
    void Start()
    {
      
        SaveSystem.LoadPlayerData();
        bestScore.text = PlayerData.highScore.ToString();
        musicOff.SetActive(PlayerData.isMusicOff);
        musicOn.SetActive(!PlayerData.isMusicOff);
        soundOff.SetActive(PlayerData.isSoundOff);
        soundOn.SetActive(!PlayerData.isSoundOff);

    }

    
}

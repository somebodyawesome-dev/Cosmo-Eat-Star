using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataContainer : MonoBehaviour
{
    public static int currScore {
        set
        {
            FindObjectOfType<PlayerDataContainer>()._currScore = value;
            FindObjectOfType<PlayerDataContainer>().text.text = currScore.ToString();
        }
        get
        {
            return FindObjectOfType<PlayerDataContainer>()._currScore;
        }

    }
    private int _currScore;
    public Text text;
    private void Start()
    {
        currScore = 0;
    }
}

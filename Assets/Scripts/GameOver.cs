using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject touchPad;
    public GameObject currScore;
    public GameObject gameOverPanel;
    public Text showFinaleScore;
    void Start()
    {
        
        FindObjectOfType<AudioManager>().play("GameOver");
        FindObjectOfType<SpawnSystem>().enabled = false;
        int score = PlayerDataContainer.currScore;
        if (score > PlayerData.highScore) PlayerData.highScore = score;
        touchPad.SetActive(false);
        currScore.SetActive(false);
        GameObject[] aux = GameObject.FindGameObjectsWithTag("Star");
        foreach (GameObject obj in aux)
        {

            Destroy(obj);
        }
        aux = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject obj in aux)
        {
            Destroy(obj);
        }
        gameOverPanel.SetActive(true);
        showFinaleScore.text = score.ToString();
    }

   
}

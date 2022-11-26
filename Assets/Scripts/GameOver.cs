using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject touchPad;
    public GameObject currScore;
    public GameObject gameOverPanel;
    public Text showFinaleScore;
    public Text rankText;
    void Start()
    {
        
        FindObjectOfType<AudioManager>().play("GameOver");
        FindObjectOfType<SpawnSystem>().enabled = false;
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
        int score = PlayerDataContainer.currScore;
        if (!string.IsNullOrEmpty(PlayerData.token))
        {
            if (score > PlayerData.highScore)
            {
                //if user logged in update score in db
                StartCoroutine(updateScore(score));
            }
            else
            {
                StartCoroutine(getRank());
            }
        }
        else
        {
            rankText.text = "No Auth";
        }
       
        
        showFinaleScore.text = score.ToString();
    }

    private IEnumerator getRank()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://localhost:7292/api/User/getRank"))
        {
            
            www.certificateHandler = new AuthService.BypassCertificate();
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("accept", "text/plain");
            www.SetRequestHeader("Authorization",$"Bearer {PlayerData.token}");


            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                var rank = www.downloadHandler.text;
                Debug.Log("rank : " + rank);
                rankText.text = rank;
            }
        }
    }
    private IEnumerator updateScore(int score)
    {
        // user is signed in 
        var body = score.ToString();
        using (UnityWebRequest www = UnityWebRequest.Post("https://localhost:7292/api/User/updateScore", body))
        {
            www.uploadHandler = new UploadHandlerRaw(string.IsNullOrEmpty(body) ? null : Encoding.UTF8.GetBytes(body));
            www.certificateHandler = new AuthService.BypassCertificate();
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("accept", "text/plain");
            www.SetRequestHeader("Authorization",$"Bearer {PlayerData.token}");


            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                var token = www.downloadHandler.text;
                Debug.Log("Received : " + token);
                    
            }

            yield return StartCoroutine(getRank());
        }
    }
}

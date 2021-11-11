
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    public void sceneAt(int targetindex)
    {
        StartCoroutine(delayFunc(0.25f,targetindex));
       // SceneManager.LoadScene(targetindex);
    }
    
    IEnumerator delayFunc(float delay,int index)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class TargetShip : MonoBehaviour
{
    public static int lastlevelused=1;
    public bool touchedSpaceship;
    public bool isRight;
    public Transform[] route1;
    public Transform[] route2;
    public float speed;
    public Transform[] points;
    public Transform chooseRoute;
    public int choosenlevel;
    public float t;
    private void Start()
    {
        touchedSpaceship = false;
       
        //Init Routes
       Route[] aux = GameObject.FindObjectsOfType<Route>();
        route1 = new Transform[aux.Length/2];
        route2 = new Transform[aux.Length/2];
        for (int i = 0,j=0,k=0; i < aux.Length; i++)
        {
           if(aux[i].level == 1)
            {
                route1[j++] = aux[i].transform;
            }
            else
            {
                if(aux[i].level == 2)
                {
                    route2[k++] = aux[i].transform;
                }
            }
        }

         SpawnSystem spawnSystem = FindObjectOfType<SpawnSystem>();
        choosenlevel = UnityEngine.Random.Range(1, 3);
        if (spawnSystem.prevIsBomb && gameObject.tag == "Star" || !spawnSystem.prevIsBomb && gameObject.tag == "Bomb")
         {
             while(Mathf.Abs(lastlevelused-choosenlevel)== 1) choosenlevel = lastlevelused;
        }
         
         
      
        if (choosenlevel == 1)
        {
            chooseRoute = route1[UnityEngine.Random.Range(0, route1.Length)];
        }
        else
        {
            if(choosenlevel == 2)
            {
                chooseRoute = route2[UnityEngine.Random.Range(0, route2.Length)];
            }
        }


        points = new Transform[chooseRoute.childCount];
        for(int  i = 0; i< chooseRoute.childCount; i++)
        {
            points[i] = chooseRoute.GetChild(i);
        }
        t = 0;
        transform.position = points[0].position;
        if (transform.position.x > 0) isRight = true;
        else isRight = false;


      //StartCoroutine(followRoute());
        
    }
    
   IEnumerator followRoute()
    {
        

        while(t< 1)
        {
            t += speed * Time.deltaTime;
            transform.position= Mathf.Pow(1 - t, 3) * points[0].position + 3 * Mathf.Pow(1 - t, 2) * t * points[1].position + 3 * (1 - t) * Mathf.Pow(t, 2) * points[2].position + Mathf.Pow(t, 3) * points[3].position;
            

            yield return new WaitForEndOfFrame();
        }

        
    }

}

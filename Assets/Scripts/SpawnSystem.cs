using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject star;
    [SerializeField] Spawn[] spawns;
    [SerializeField] float roundTime;
    [SerializeField] int numberofObjectPerRound;
    [SerializeField] public int roundNumber;
    [SerializeField] int numberMaxOfBombs;
    [SerializeField] Transform[] routes;
    public bool RoundOver = false;
    private void Start()
    {
        spawns = FindObjectsOfType<Spawn>();
        RoundOver = false;
        roundNumber = 1;
        numberMaxOfBombs = UnityEngine.Random.Range(2, 3);
        StartCoroutine(startTheGame());
    }


    IEnumerator startTheGame()
    {

        yield return new WaitForSeconds(2f);
        while (!FindObjectOfType<GameOver>().enabled)
        {
          
            float aux = UnityEngine.Random.Range(roundNumber/5, roundNumber);
            roundTime = UnityEngine.Random.Range(2f+aux , 5f+aux );
            RoundOver = false;
            StartCoroutine(startRound());
            roundNumber++;
            yield return new WaitUntil(() => RoundOver );
        }
        
    }


    int objectSpawned ;
    int bombspawned;
    float spawningRate;
    IEnumerator startRound()
    {
        
        
        numberofObjectPerRound = 6 + roundNumber;
        
        if (PlayerDataContainer.currScore >= 20)
        {
            numberMaxOfBombs = Convert.ToInt32(UnityEngine.Random.Range(0.6f, 0.8f) * numberofObjectPerRound);
            chanceOfBomb = 0.6f;
        }
        else
        {
            numberMaxOfBombs = numberofObjectPerRound / 3;
        }
        spawningRate = roundTime/numberofObjectPerRound;
        objectSpawned = 0;
        bombspawned = 0;
        while (objectSpawned < numberofObjectPerRound && !FindObjectOfType<GameOver>().enabled)
        {
            StartCoroutine(SpawnObject());
            objectSpawned++;
            yield return new WaitForSeconds(spawningRate);
            // if(prevIsBomb && !currIsBomb || !prevIsBomb && currIsBomb) yield return new WaitForSeconds(spawningRate/2);
            prevIsBomb = currIsBomb;

        }

        RoundOver = true;
        
    }
  
   public  bool prevIsBomb=false;
   public  bool currIsBomb;
    public int lastlevelused;
    int indexoflastspawn;
    [SerializeField] [Range(0, 1)] float chanceOfBomb;
    
    IEnumerator SpawnObject()
    {
        int spawnIndex= UnityEngine.Random.Range(0,spawns.Length);
        GameObject objectTospawn;
        if (UnityEngine.Random.value < chanceOfBomb && bombspawned < numberMaxOfBombs)
        {
            objectTospawn = bomb;
            bombspawned++;
            currIsBomb = true;
            spawnIndex = indexoflastspawn;

        }
        else
        {
            objectTospawn = star;
            currIsBomb = false;
        }
        /* if (spawns[spawnIndex].state == Spawn.spawnStat.SPAWNING)
          {

              yield return new WaitUntil(() => spawns[spawnIndex].state == Spawn.spawnStat.WAITING);
          }
          GameObject spawnedGameObject = Instantiate(objectTospawn, spawns[spawnIndex].transform.position, spawns[spawnIndex].transform.rotation);

          indexoflastspawn = spawnIndex;
          spawnedGameObject.transform.parent = GameObject.Find("Bombs and stars holder").transform;
        */
        spawnIndex = UnityEngine.Random.Range(0, routes.Length);
        GameObject spawnedObject = Instantiate(objectTospawn, routes[spawnIndex].GetChild(0).position, routes[spawnIndex].GetChild(0).rotation);
       spawnedObject.transform.parent= GameObject.Find("Bombs and stars holder").transform;
        
        yield return null;
    }



}

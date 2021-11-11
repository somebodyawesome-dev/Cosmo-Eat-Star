using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public enum spawnStat { WAITING,SPAWNING}
    public spawnStat state;
    private void Start()
    {
        state = spawnStat.WAITING;
    }
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y), 0.2f);
        
        
        if(colliders.Length == 0) {
            state = spawnStat.WAITING;
        }
        else
        {
            state = spawnStat.SPAWNING;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAndBombManager : MonoBehaviour
{
    TargetShip[] targetShips;

    // Update is called once per frame
    void FixedUpdate()
    {
        float deltaTime = Time.fixedDeltaTime;
        targetShips = GameObject.FindObjectsOfType<TargetShip>();
        foreach(TargetShip targetShip in targetShips)
        {
             if (targetShip.t < 1)
             {
                 targetShip.t += targetShip.speed * deltaTime;
                 targetShip.transform.position = Mathf.Pow(1 - targetShip.t, 3) * targetShip.points[0].position + 3 * Mathf.Pow(1 - targetShip.t, 2) * targetShip.t * targetShip.points[1].position + 3 * (1 - targetShip.t) * Mathf.Pow(targetShip.t, 2) * targetShip.points[2].position + Mathf.Pow(targetShip.t, 3) * targetShip.points[3].position;
             }
            
        }
    }


   
}

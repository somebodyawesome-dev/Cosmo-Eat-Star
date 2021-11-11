using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] public Transform[] point;
     public int level;
    private void OnDrawGizmos()
    {
     
        for(float i = 0; i < 1; i += 0.05f)
        {
            Vector2 gizmoPoint = Mathf.Pow(1 - i, 3) * point[0].position + 3* Mathf.Pow(1-i,2)*i* point[1].position+3*(1-i)*Mathf.Pow(i,2)* point[2].position+Mathf.Pow(i,3)* point[3].position;
            Gizmos.DrawSphere(gizmoPoint, 0.05f);
        }
        Gizmos.DrawLine((Vector2)point[0].position, (Vector2)point[1].position);
        Gizmos.DrawLine((Vector2)point[1].position, (Vector2)point[2].position);
        Gizmos.DrawLine((Vector2)point[2].position, (Vector2)point[3].position);

    }
}

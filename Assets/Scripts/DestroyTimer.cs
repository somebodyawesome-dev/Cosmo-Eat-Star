using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] float time=5f;
    float counter;
    private void Start()
    {
        counter = 0f;
    }
    private void Update()
    {
        if (counter < time) counter += Time.deltaTime;
        else Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCar : MonoBehaviour
{
    private float xRange = 15;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, -4, 0);
        }
    }
}

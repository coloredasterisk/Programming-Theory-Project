using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Car : Vehicle
{
    //POLYMORPHISM
    protected override void Move()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
        Vector3 position = GameObject.Find("Player").transform.position;
        position.y = transform.position.y;
        if(transform.position.z > 30)
        {
            transform.LookAt(position);
        }
        
    }

    protected override void SetValue()
    {
        speed = 30;
        scoreValue = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : Vehicle
{
    protected override void SetValue()
    {
        speed = 60;
        scoreValue = 2;
    }
}

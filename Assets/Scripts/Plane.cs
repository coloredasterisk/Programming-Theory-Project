using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Vehicle
{
    protected override void SetValue()
    {
        xSpawnRange = 7;
        speed = 60;
        scoreValue = 7;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : Spawner
{
    public override void Spawn()
    {
        GameObject boxInstance = Instantiate(objToSpawn);
        boxInstance.transform.position = transform.position;
    }
}

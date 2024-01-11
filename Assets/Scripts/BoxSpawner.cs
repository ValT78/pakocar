using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : Spawner
{
    public override void Spawn()
    {
        int randomInt = Random.Range(0, transform.childCount-1);
        GameObject boxInstance = Instantiate(objToSpawn);
        boxInstance.transform.position = transform.GetChild(randomInt).position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject objToSpawn;
    [SerializeField]
    private float timeUntilNextSpawn;

    private bool waitingNextSpawn;

    private void Start()
    {
        waitingNextSpawn = false;
    }

    private void Update()
    {
        if (!waitingNextSpawn)
        {
            StartCoroutine(Wait());
            Spawn();
        }
    }

    public virtual void Spawn()
    {
        
    }
    private IEnumerator Wait()
    {
        waitingNextSpawn = true;
        yield return new WaitForSeconds(timeUntilNextSpawn);
        waitingNextSpawn = false;
    }
}

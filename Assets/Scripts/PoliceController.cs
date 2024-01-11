using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private NavMeshAgent agent;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}

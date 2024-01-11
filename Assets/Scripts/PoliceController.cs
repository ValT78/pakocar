using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class PoliceController : VehicleBehavior
{
    private Transform player;
    private Quaternion targetAngle;
    private bool isDestroy;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float updateTime;
    [SerializeField] private float smoothRotationSpeed;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
        if (player != null)
        {
            StartCoroutine(Destination());
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, smoothRotationSpeed * Time.deltaTime);
    }

    private IEnumerator Destination()
    {
        agent.SetDestination(player.position);

        targetAngle = Quaternion.LookRotation(player.position - transform.position);
        

        yield return new WaitForSeconds(updateTime);
        StartCoroutine(Destination());
    }

    public override void BreakObject()
    {
        base.BreakObject();
        isDestroy = true;
        Destroy(agent);
    }

}
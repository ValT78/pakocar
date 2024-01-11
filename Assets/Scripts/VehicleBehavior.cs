using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehavior : MonoBehaviour
{
    [SerializeField] private GameObject explosionParticle;


    public virtual void BreakObject()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehavior : MonoBehaviour
{
    [SerializeField] private GameObject explosionParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            BreakObject();
        }
    }


    public virtual void BreakObject()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

}

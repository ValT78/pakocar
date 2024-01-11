using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed = 3f;
    [SerializeField]
    private float angleSpeed = 1.0f;

    private Rigidbody rb;
    private Ray ray;
    private Camera cam;

    private Vector3 angleDest;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.Force);
        Vector3 HorizontalInput = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        angleDest += HorizontalInput * angleSpeed;
        Quaternion rotation = Quaternion.Euler(angleDest);
        rb.MoveRotation(rotation);

    }

}

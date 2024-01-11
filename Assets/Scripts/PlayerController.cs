using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : VehicleBehavior
{
    [SerializeField]
    private float forwardSpeed = 3f;
    [SerializeField]
    private float angleSpeed = 1.0f;
    [SerializeField]
    private GameObject missile;
    [SerializeField]
    private Transform missileTransformSpawnForward;
    [SerializeField]
    private Transform missileTransformSpawnBackward;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject missileInstanceForward = Instantiate(missile);
            GameObject missileInstanceBackward = Instantiate(missile);
            missileInstanceForward.transform.position = missileTransformSpawnForward.position;
            missileInstanceBackward.transform.position = missileTransformSpawnBackward.position;
            missileInstanceForward.transform.rotation = missileTransformSpawnForward.rotation;
            missileInstanceBackward.transform.rotation = missileTransformSpawnBackward.rotation;
        }
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

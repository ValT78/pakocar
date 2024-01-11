using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : VehicleBehavior
{
    [SerializeField]
    private float forwardSpeed;
    [SerializeField]
    private float angleSpeed = 1.0f;
    [HideInInspector] public int nbrMunition;
    [SerializeField]
    private float boost;
    [SerializeField]
    private float timeBoosted;
    [SerializeField]
    private float timeUntilNextBoost;
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

    private bool waitUntilNextBoost;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        nbrMunition = 3;
        waitUntilNextBoost = false;
    }

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);


        if (Input.GetKeyDown(KeyCode.Z) && !waitUntilNextBoost)
        {
            StartCoroutine(BoostSpeed());
            StartCoroutine(Wait());
        }

        if (Input.GetKeyDown(KeyCode.Space) && nbrMunition>=1)
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

    private IEnumerator BoostSpeed()
    {
        forwardSpeed += boost;
        yield return new WaitForSeconds(timeBoosted);
        forwardSpeed -= boost;
    }

    private IEnumerator Wait()
    {
        waitUntilNextBoost = true;
        yield return new WaitForSeconds(timeUntilNextBoost);
        waitUntilNextBoost = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : VehicleBehavior
{
    [SerializeField]
    private float forwardSpeed;
    [SerializeField]
    [HideInInspector] public int nbrMunition;
    [SerializeField]
    private float angleSpeed;
    [SerializeField]
    private float increaseAngleSpeed;
    [SerializeField]
    private float driftAngle;
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
    [SerializeField] private Renderer renderer;

    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material driftMaterial;

    private Rigidbody rb;
    private Ray ray;
    private Camera cam;

    private float angleDest;

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
        if (Mathf.Abs(angleDest - transform.rotation.y) > driftAngle)
        {
            rb.AddRelativeForce(Vector3.forward * forwardSpeed / 2, ForceMode.Force);
            renderer.material = driftMaterial;
        }
        else
        {
            rb.AddRelativeForce(Vector3.forward * forwardSpeed, ForceMode.Force);
            renderer.material = baseMaterial;

        }

        angleDest += Input.GetAxis("Horizontal") * increaseAngleSpeed;
        Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, angleDest, 0)), angleSpeed * Time.deltaTime);
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

    public override void BreakObject()
    {
        base.BreakObject();
        forwardSpeed = 0;
        angleSpeed = 0;
        GameManager.EndOfTheGame();
    }
}

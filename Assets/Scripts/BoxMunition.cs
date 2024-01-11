using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMunition : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.nbrMunition = 3;
            Destroy(gameObject);
        }
    }
}

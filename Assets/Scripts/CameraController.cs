using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform car;

    void Update()
    {
        transform.position = car.transform.position +
            new Vector3(0, 17, -18);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float emissionTime;
    [SerializeField] private float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyParticle), emissionTime);
    }

    void DestroyParticle()
    {
        _particleSystem.Stop();
        Destroy(gameObject, destroyTime);
    }
}

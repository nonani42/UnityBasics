using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    Rigidbody _rbLandmine;
    float time = 5f;
    float explosionForce = 400f;
    float explosionRadius = 15f;
    float upwardsModifier = 45f;

    private void Awake()
    {
        _rbLandmine = GetComponent<Rigidbody>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rb))
        {
            _rbLandmine.AddForce(Vector3.up * explosionForce * upwardsModifier * _rbLandmine.mass);
            rb.AddForce(Vector3.up * explosionForce * upwardsModifier * rb.mass);
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach(Collider coll in colliders)
            {
                if (coll.TryGetComponent(out Rigidbody foundrb))
                {
                    foundrb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
                }
            }
            Destroy(gameObject);
        }
    }
}

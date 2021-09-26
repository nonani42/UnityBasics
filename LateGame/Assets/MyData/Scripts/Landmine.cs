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
        if (!other.CompareTag("Untagged"))
        {
            _rbLandmine.AddForce(Vector3.up * explosionForce * upwardsModifier * _rbLandmine.mass);
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * explosionForce * upwardsModifier * other.GetComponent<Rigidbody>().mass);
            //_rbLandmine.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            //other.GetComponent<Rigidbody>().AddExplosionForce(4000f, transform.position, 15f, 45f, ForceMode.Impulse);
            Destroy(other.gameObject, time);
            Destroy(gameObject, time);
        }
    }
}

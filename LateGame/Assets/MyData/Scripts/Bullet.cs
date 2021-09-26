using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _lifetime = 5f;
    private Rigidbody _rbBullet;
    void Awake()
    {
        _rbBullet = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Destroy(gameObject, _lifetime);
        _rbBullet.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

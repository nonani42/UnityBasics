using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    private GameObject _target;
    private float _speed = 50f;
    Vector3 direction;
    Vector3 stepDirection;
    Quaternion _returnRot;
    private float step = 0f;
    private GameObject boss;

    void Start()
    {
    }
    void FixedUpdate()
    {
        if (_target == null)
        {
            step++;
            transform.Rotate(Vector3.up * Time.deltaTime * _speed, Space.World);
            if (Mathf.Approximately(step, 180f))
            {
                _speed = -_speed;
                step = 0f;
            }
        }
        else
        {
            direction = _target.transform.position - transform.position;
            stepDirection = Vector3.RotateTowards(transform.forward, direction, _speed * Time.fixedDeltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(stepDirection);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<Player>().HasEgg)
            {
                _target = other.gameObject;
                _returnRot = transform.rotation;
                boss = GameObject.FindGameObjectWithTag("Boss");
                boss.GetComponent<Boss>().IsAlert = true;
                boss.GetComponent<Boss>().Target = other.transform;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _target != null)
        {
            _target = null;
            transform.rotation = _returnRot;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    private Animator _anim;
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _anim.SetTrigger("isPickedUp");
            Destroy(gameObject, 1f);
        }
    }
}

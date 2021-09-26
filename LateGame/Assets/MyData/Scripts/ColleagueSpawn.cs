using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColleagueSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _colleaguePrefab;
    private Vector3 _position;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _position = other.transform.position + other.transform.forward * 3f;
            GameObject colleague = Instantiate(_colleaguePrefab, _position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }
}

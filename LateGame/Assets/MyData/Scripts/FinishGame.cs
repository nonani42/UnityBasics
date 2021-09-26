using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private Animator _anim;
    public void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>()._hasKeyCard)
        {
            Debug.Log("You won.");
            _anim.SetTrigger("_open");
            Destroy(GetComponent<BoxCollider>());
        }
    }
}

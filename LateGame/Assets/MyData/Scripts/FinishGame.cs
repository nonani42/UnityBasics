using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private Animator _anim;
    private Boss boss;

    public void Awake()
    {
        _anim = GetComponent<Animator>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>()._hasKeyCard)
        {
            Debug.Log("You won.");
            _anim.SetTrigger("_open");
            boss.Stop();
            Destroy(GetComponent<BoxCollider>());
        }
    }
}

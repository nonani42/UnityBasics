using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    private Animator _anim;
    private GameObject player;
    public void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void Update()
    {
        if(player != null && Input.GetKey(KeyCode.E))
        {
            player.GetComponent<Player>()._hasKeyCard = true;
            _anim.SetTrigger("isPickedUp");
            Destroy(gameObject, 2f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    private Animator _anim;
    private bool isPlayerStay = false;
    public bool foundKeycard;
    public bool keycardIsHere;
    private GameObject keycard;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(keycard == null)
        {
            keycard = GameObject.FindGameObjectWithTag("Key");
            if(keycard != null)
            {
                foundKeycard = true;
                keycardIsHere = transform.position == keycard.transform.position;
            }
        }

        if (Input.GetKey(KeyCode.E) && isPlayerStay)
        {
            _anim.SetTrigger("_isMoved");
            if (keycardIsHere)
            {
                keycard.GetComponent<BoxCollider>().enabled = true;
            }
            //gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            isPlayerStay = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerStay = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerStay = false;
        }
    }
}

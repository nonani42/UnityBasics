using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>()._hasKeyCard)
        {
            Debug.Log("You won.");
            Destroy(GetComponent<BoxCollider>());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    GameObject player;
    Vector3 startPoint;
    void Awake()
    {
        startPoint = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        player.transform.position.Set(startPoint.x, startPoint.y, startPoint.x);
    }
}

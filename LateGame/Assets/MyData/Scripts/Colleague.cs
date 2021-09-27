using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Colleague : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private Transform finish;
    private NavMeshAgent agent;
    private Animator _anim;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        finish = GameObject.FindGameObjectWithTag("Finish").transform;
        _anim = GetComponent<Animator>();
    }
    void Start()
    {
        agent.SetDestination(finish.position);
        agent.speed = _speed;
    }
    public void Stop()
    {
        _anim.SetTrigger("_finished");
        agent.isStopped = true;
    }
}

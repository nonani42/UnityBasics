using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Colleague : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform finish;
    private NavMeshAgent agent;
    private Animator _anim;
    private AudioSource _audio;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        finish = GameObject.FindGameObjectWithTag("Finish").transform;
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        agent.SetDestination(finish.position);
        agent.speed = _speed;
        _audio.Play();
    }    
    void Update()
    {
        if (Time.deltaTime == 0)
        {
            _audio.Pause();
        }
        else
        {
            _audio.UnPause();
        }
    }

    public void Stop()
    {
        _anim.SetTrigger("_finished");
        agent.isStopped = true;
        _audio.Stop();
    }
}

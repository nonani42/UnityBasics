using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private Transform[] _waypoints;
    private NavMeshAgent agent;
    int count = 0;
    private bool _isAlert;
    public Animator _anim;
    public Vector3 _target;
    public bool IsAlert
    {
        set
        {
            _isAlert = value;
        }
    }
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }
    void Start()
    {
        agent.SetDestination(_waypoints[count].position);
        agent.speed = _speed;
        agent.autoTraverseOffMeshLink = false;
    }
    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            count = ++count % _waypoints.Length;
            agent.SetDestination(_waypoints[count].position);
        }
        if (agent.isOnOffMeshLink)
        {
            StartCoroutine(Parabola(agent, 5f, 0.75f));
            agent.CompleteOffMeshLink();
        }
    }
    void FixedUpdate()
    {
        if (_isAlert)
        {
            //agent.speed = _speed + 2f;
            agent.SetDestination(_target);
            _anim.SetBool("_alert", true);
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                Debug.Log("Back to pATROL");
                _isAlert = false;
                _anim.SetBool("_alert", false);
                agent.speed = _speed;
                agent.SetDestination(_waypoints[count].position);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<Player>().HasEgg)
            {
                _anim.SetTrigger("_caught");
                _anim.SetBool("_patrol", false);
                agent.isStopped = true;
                other.GetComponent<Player>().IsFound = true;
                Debug.Log("Game over");
            }
        }
    }
    public void Stop()
    {
        _anim.SetTrigger("_finished");
        _anim.SetBool("_patrol", false);
        agent.isStopped = true;
    }
    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        _anim.SetBool("_jump", true);
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        _anim.SetBool("_jump", false);
    }
}

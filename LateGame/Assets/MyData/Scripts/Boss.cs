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
    private Animator _anim;
    private Transform _target;
    public bool IsAlert
    {
        set
        {
            _isAlert = value;
        }
    }
    public Transform Target
    {
        set
        {
            _target = value;
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
            agent.speed = _speed * 2f;
            agent.SetDestination(_target.position);
            if(transform.position == _target.position && !_target.GetComponent<Player>().IsFound)
            {
                _isAlert = false;
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
                other.GetComponent<Player>().IsFound = true;
                Debug.Log("Game over");
            }
        }
    }
    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] GameObject _loseScreen;
    [SerializeField] AudioSource[] _sounds;
    private NavMeshAgent agent;
    int count = 0;
    public bool _isAlert;
    Animator _anim;
    AudioSource _audio;
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
        _audio = _sounds[0];
    }
    void Start()
    {
        agent.SetDestination(_waypoints[count].position);
        agent.speed = _speed;
        agent.autoTraverseOffMeshLink = false;
        _audio.Play();
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
            _audio.Stop();
            StartCoroutine(Parabola(agent, 5f, 0.75f));
            agent.CompleteOffMeshLink();
            _audio.Play();
        }
        if (Time.deltaTime == 0)
        {
            _audio.Pause();
        }
        else
        {
            _audio.UnPause();
        }
    }
    void FixedUpdate()
    {
        if (_isAlert)
        {
            //agent.speed = _speed + 2f;
            _audio = _sounds[1];
            agent.SetDestination(_target);
            _anim.SetBool("_alert", true);
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                Debug.Log("Back to pATROL");
                _isAlert = false;
                _anim.SetBool("_alert", false);
                agent.speed = _speed;
                agent.SetDestination(_waypoints[count].position);
                _audio = _sounds[0];
            }
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        _audio.Stop();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._hasLost = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _loseScreen.SetActive(true);
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
                _audio.Stop();
                GameOver();
            }
        }
    }
    public void Stop()
    {
        _anim.SetTrigger("_finished");
        _anim.SetBool("_patrol", false);
        agent.isStopped = true;
        _audio.Stop();
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

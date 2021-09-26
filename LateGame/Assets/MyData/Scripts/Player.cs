using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _buff { get; set; } = 0f;
    [SerializeField] private bool _hasEgg;
    public bool _hasLost = false;
    public bool _hasKeyCard;
    private Animator _anim;
    public float Buff
    {
        get
        {
            return _buff;
        }
        set
        {
            _buff = value;
        }
    }
    public bool HasEgg
    {
        get
        {
            return _hasEgg;
        }
    }
    public bool IsFound
    {
        get
        {
            return _hasLost;
        }
        set
        {
            _hasLost = value;
        }
    }
    public void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void Start()
    {
    }
    public void Update()
    {
        if (_hasLost)
        {
            _anim.Play("PlayerLose");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Buff":
                _buff = 1.5f;
                break;
            case "Debuff":
                _buff = -1.5f;
                break;
            case "Egg":
                _hasEgg = true;
                break;
            default:
                break;
        }
    }
}

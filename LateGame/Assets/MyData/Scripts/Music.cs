using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    AudioSource _audio;
    [SerializeField] AudioMixer _mixer;
    Boss _boss;
    Player _player;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        _audio = gameObject.GetComponent<AudioSource>();
        _audio.pitch = 1f;
    }
    void Start()
    {
        //_mixer.SetFloat("masterVolume", 20);
        //_mixer.SetFloat("fxVolume", 70);
        //_mixer.SetFloat("musicVolume", 60);
    }
    public void SetMasterVol(float value)
    {
        _mixer.SetFloat("masterVolume", Mathf.Log10(value) * 20);
    }
    public void SetFXVol(float value)
    {
        _mixer.SetFloat("fxVolume", Mathf.Log10(value) * 20);
    }
    public void SetMusicVol(float value)
    {
        _mixer.SetFloat("musicVolume", Mathf.Log10(value) * 20);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Colleague") != null)
        {
            _audio.pitch = 1.5f;
        }
        else
        {
            _audio.pitch = 1f;
        }
        if (_boss == null)
        {
            if (GameObject.FindGameObjectWithTag("Boss") != null)
            {
                _boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
            }
        }
        if (_player == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            }
        }
        if (_boss != null)
        {
            if (_boss._isAlert)
            {
                _audio.pitch = 1.5f;
            }
            else
            {
                _audio.pitch = 1f;
            }
        }
        if (_player != null && _player._hasLost)
        {
            _audio.pitch = 1f;
        }
    }
}

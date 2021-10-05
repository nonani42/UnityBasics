using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZone : MonoBehaviour
{
    [SerializeField] AudioReverbZone _zone;
    [SerializeField] AudioReverbPreset _effect;
    private void Awake()
    {
        _zone = GetComponent<AudioReverbZone>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _zone.reverbPreset = _effect;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _zone.reverbPreset = AudioReverbPreset.Off;
        }
    }
}

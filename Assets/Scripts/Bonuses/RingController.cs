using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public Action OnRingCollected;
    public Action OnAllRingsCollected;
    private int _ringsCount;
    private AudioSource _audioSource;


    private void Awake()
    {
        _ringsCount = transform.childCount;
        _audioSource = GetComponent<AudioSource>();
    }

    public void RingCollected()
    {
        OnRingCollected?.Invoke();
        _ringsCount--;

        if(_ringsCount == 0)
        {
            SoundManager.PlayMusic(_audioSource);
            OnAllRingsCollected?.Invoke();
        }
    }
}

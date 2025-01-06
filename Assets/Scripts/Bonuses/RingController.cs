using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public Action OnRingCollected;
    public Action OnAllRingsCollected;
    private int _ringsCount;


    private void Awake()
    {
        _ringsCount = transform.childCount;
    }

    public void RingCollected()
    {
        OnRingCollected?.Invoke();
        _ringsCount--;

        if(_ringsCount == 0)
            OnAllRingsCollected?.Invoke();
    }
}

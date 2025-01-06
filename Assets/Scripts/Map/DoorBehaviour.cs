using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IDisposable
{
    [SerializeField]
    private RingController _ringController;


    private void Awake()
    {
        _ringController.OnAllRingsCollected += OpenDoor;
    }

    private void OpenDoor()
    {
        transform.position = new(transform.position.x, transform.position.y + 2.5f, transform.position.z);
    }
    public void Dispose()
    {
        _ringController.OnAllRingsCollected -= OpenDoor;
    }
}

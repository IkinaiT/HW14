using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerBehaviour _playerBehaviour;

    private ParticleSystem _particleSystem;


    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _playerBehaviour.Dead();
            _particleSystem.Play();
        }
    }
}

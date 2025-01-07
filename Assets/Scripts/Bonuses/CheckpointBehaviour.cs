using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint;

    private GameObject _active;
    private GameObject _collected;
    private AudioSource _audioSource;
    private bool _isCollected = false;


    private void Awake()
    {
        _active = GetComponentsInChildren<Transform>().First(_ => _.gameObject.name == "Active").gameObject;
        _collected = GetComponentsInChildren<Transform>().First(_ => _.gameObject.name == "Collected").gameObject;
        _collected.SetActive(false);

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCollected && other.gameObject.tag == "Player")
        {
            _respawnPoint.position = transform.position;
            _active.SetActive(false);
            _collected.SetActive(true);
            _isCollected = true;

            SoundManager.PlayMusic(_audioSource);
        }
    }
}

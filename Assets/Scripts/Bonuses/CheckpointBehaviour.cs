using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint;
    [SerializeField]
    private GameObject _active;
    [SerializeField]
    private GameObject _collected;

    private AudioSource _audioSource;
    private bool _isCollected = false;


    private void Awake()
    {
        _collected.SetActive(false);

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCollected && other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatus>().SetLastSize();

            _respawnPoint.position = transform.position;
            _active.SetActive(false);
            _collected.SetActive(true);
            _isCollected = true;

            SoundManager.PlayMusic(_audioSource);
        }
    }
}

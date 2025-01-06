using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerStatus _playerStatus;

    private AudioSource _audioSource;
    private ParticleSystem _particleSystem;
    private bool _isCollected;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isCollected)
        {
            if (other.gameObject.tag == "Player")
            {
                _playerStatus.AddHealth();

                _audioSource.Play();

                gameObject.GetComponent<MeshRenderer>().enabled = false;

                _isCollected = true;

                _particleSystem.Play();

                StartCoroutine(DestroyCoroutine(_audioSource));
            }
        }
    }

    private IEnumerator DestroyCoroutine(AudioSource audio)
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
